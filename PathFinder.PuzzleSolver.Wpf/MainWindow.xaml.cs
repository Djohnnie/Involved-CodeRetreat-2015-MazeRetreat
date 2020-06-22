using Microsoft.Win32;
using PathFinder.DataModel;
using PathFinder.PuzzleVisualizer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System;
using System.Diagnostics;

namespace PathFinder.PuzzleSolver.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Maze _maze;
        private Boolean _slowmotionSolving;
        private Int32 _steps;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog().Value)
            {
                _maze = MazeExtensions.LoadMazeFromFile(dlg.FileName);
                puzzleVisualizer.Maze = _maze;
            }
        }

        private void slowmotionCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            _slowmotionSolving = true;
        }

        private void slowmotionCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            _slowmotionSolving = false;
        }

        private async void solveButton_Click(object sender, RoutedEventArgs e)
        {
            solveButton.IsEnabled = false;
            _maze.Cells.ForEach(x => x.Step = null);
            _steps = 0;
            Stopwatch sw = Stopwatch.StartNew();
            var startCell = _maze.Cells.SingleOrDefault(x => x is Start);
            if (startCell != null)
            {
                await Step(startCell, step: 1);
            }
            var finishCell = _maze.Cells.SingleOrDefault(x => x is Finish);
            if (finishCell != null)
            {
                await Backtrack(finishCell);
            }
            sw.Stop();
            if (sw.ElapsedMilliseconds > 0)
            {
                timeToSolutionTextBlock.Text = String.Format("{0}ms", sw.ElapsedMilliseconds);
            }
            else
            {
                timeToSolutionTextBlock.Text = String.Format("{0} ticks", sw.ElapsedTicks);
            }
            stepsToSolutionTextBlock.Text = String.Format("{0} steps", _steps);
            puzzleVisualizer.Maze = _maze;

            solveButton.IsEnabled = true;
        }

        private async Task Step(Cell startCell, Int32 step)
        {
            await Step(new List<Cell> { startCell }, step);
        }

        private async Task Step(IEnumerable<Cell> cells, Int32 step)
        {
            var finishFound = false;
            List<Cell> nextCells = new List<Cell>();
            foreach (var cell in cells)
            {
                var neighbourCells = FindNeighbours(cell);
                var found = neighbourCells.Any(x => x is Finish);
                if (found)
                {
                    neighbourCells.Single(x => x is Finish).Step = step;
                }
                else
                {
                    foreach (var nextCell in neighbourCells)
                    {
                        if (nextCell.Step == null || nextCell.Step > step)
                        {
                            nextCell.Step = step;
                            nextCells.Add(nextCell);
                            var teleportedCell = FindCorrespondingTeleportCell(nextCell);
                            if (teleportedCell != null) { teleportedCell.Step = step; }
                            _steps++;
                        }
                    }
                }
                finishFound = finishFound || found;
            }
            if (_slowmotionSolving)
            {
                await Task.Delay(100);
                puzzleVisualizer.Maze = _maze;
            }
            if (!finishFound && nextCells.Count > 0)
            {
                await Step(nextCells, step + 1);
            }
        }

        private List<Cell> FindNeighbours(Cell cell)
        {
            List<Cell> neighbours = new List<Cell>();
            var currentCell = FindCorrespondingTeleportCell(cell) ?? cell;
            AddNeighbourCell(neighbours, currentCell.X - 1, currentCell.Y);
            AddNeighbourCell(neighbours, currentCell.X, currentCell.Y - 1);
            AddNeighbourCell(neighbours, currentCell.X + 1, currentCell.Y);
            AddNeighbourCell(neighbours, currentCell.X, currentCell.Y + 1);
            return neighbours;
        }

        private void AddNeighbourCell(List<Cell> neighbours, Int32 x, Int32 y)
        {
            if (x >= 0 && x < _maze.Width && y >= 0 && y < _maze.Height)
            {
                var neighbourCell = _maze[x, y];
                if (neighbourCell != null && (neighbourCell is Empty || neighbourCell is Teleport || neighbourCell is Finish))
                {
                    neighbours.Add(neighbourCell);
                }
            }
        }

        private async Task Backtrack(Cell cell)
        {
            List<Cell> shortestPathCells = new List<Cell>();
            await Backtrack(cell, shortestPathCells);
            _maze.Cells.ForEach(c => { if (!shortestPathCells.Contains(c)) { c.Step = null; } });
        }

        private async Task Backtrack(Cell cell, List<Cell> history)
        {
            if (!(cell is Start))
            {
                history.Add(cell);
                var previousCellInPath = FindPreviousCellInPath(cell);
                if (previousCellInPath != null)
                {
                    await Backtrack(previousCellInPath, history);
                }
            }
        }

        private Cell FindPreviousCellInPath(Cell cell)
        {
            var neighbourCells = FindNeighbours(cell);
            var previousCells = neighbourCells.Where(x => x.Step.HasValue && x.Step == cell.Step - 1);
            var previousCell = previousCells.FirstOrDefault(x => !(x is Teleport)) ?? previousCells.FirstOrDefault();
            return previousCell;
        }

        private Cell FindCorrespondingTeleportCell(Cell cell)
        {
            var teleportCell = cell as Teleport;
            if (teleportCell != null)
            {
                return _maze.Cells
                    .Where(x => x is Teleport && x != teleportCell)
                    .Cast<Teleport>()
                    .SingleOrDefault(x => x.Address == teleportCell.Address);
            }
            return null;
        }
    }
}