using System;
using System.Windows.Forms;
using PathFinder.DataModel;
using Pathfinder.PuzzleVisualizer.WinForms;

namespace PathFinder.PuzzleMaker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void emptyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ToggleCurrentEditBlock(emptyRadioButton, PuzzleVisualizer.BlockKind.Empty);
        }

        private void wallRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ToggleCurrentEditBlock(wallRadioButton, PuzzleVisualizer.BlockKind.Wall);
        }

        private void startRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ToggleCurrentEditBlock(startRadioButton, PuzzleVisualizer.BlockKind.Start);
        }

        private void finishRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ToggleCurrentEditBlock(finishRadioButton, PuzzleVisualizer.BlockKind.Finish);
        }

        private void teleport1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ToggleCurrentEditBlock(teleport1RadioButton, PuzzleVisualizer.BlockKind.Teleport1);
        }

        private void teleport2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ToggleCurrentEditBlock(teleport2RadioButton, PuzzleVisualizer.BlockKind.Teleport2);
        }

        private void teleport3RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ToggleCurrentEditBlock(teleport3RadioButton, PuzzleVisualizer.BlockKind.Teleport3);
        }

        private void widthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            pathFinderPuzzleControl.GridWidth = (Int32)widthNumericUpDown.Value;
        }

        private void heightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            pathFinderPuzzleControl.GridHeight = (Int32)heightNumericUpDown.Value;
        }

        private void storeButton_Click(object sender, EventArgs e)
        {
            var maze = pathFinderPuzzleControl.GetMaze();
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "(*.maz) Maze Files|*.maz";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    maze.SaveMazeToFile(saveFileDialog.FileName);
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "(*.maz) Maze Files|*.maz";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var maze = MazeExtensions.LoadMazeFromFile(openFileDialog.FileName);
                    pathFinderPuzzleControl.FromMaze(maze);
                }
            }
        }

        private void ToggleCurrentEditBlock(RadioButton radioButton, PuzzleVisualizer.BlockKind blockKind)
        {
            if (radioButton.Checked)
            {
                pathFinderPuzzleControl.EditBlockKind = blockKind;
            }
        }
    }
}