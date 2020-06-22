using System;
using System.Drawing;
using System.Windows.Forms;
using PathFinder.DataModel;

namespace Pathfinder.PuzzleVisualizer.WinForms
{
    public partial class PuzzleVisualizer : UserControl
    {
        #region [ BlockKind Enumeration ]
        
        public enum BlockKind
        {
            Empty,
            Wall,
            Start,
            Finish,
            Teleport1,
            Teleport2,
            Teleport3,
        }

        #endregion

        #region [ Private Members ]

        private readonly Pen _borderPen = new Pen(Color.FromArgb(0, 0, 0));
        private readonly Bitmap _emptyImage = new Bitmap(Properties.Resources.empty);
        private readonly Bitmap _wallImage = new Bitmap(Properties.Resources.wall);
        private readonly Bitmap _startImage = new Bitmap(Properties.Resources.start);
        private readonly Bitmap _finishImage = new Bitmap(Properties.Resources.finish);
        private readonly Bitmap _teleport1Image = new Bitmap(Properties.Resources.teleport1);
        private readonly Bitmap _teleport2Image = new Bitmap(Properties.Resources.teleport2);
        private readonly Bitmap _teleport3Image = new Bitmap(Properties.Resources.teleport3);

        private BlockKind[,] _puzzleBlocks;

        private Int32 _gridWidth;
        private Int32 _gridHeight;

        #endregion

        #region [ Public Properties ]

        public Int32 GridWidth
        {
            get
            {
                return _gridWidth;
            }
            set
            {
                _gridWidth = value;
                _puzzleBlocks = new BlockKind[_gridWidth, _gridHeight];
                Invalidate();
            }
        }

        public Int32 GridHeight
        {
            get
            {
                return _gridHeight;
            }
            set
            {
                _gridHeight = value;
                _puzzleBlocks = new BlockKind[_gridWidth, _gridHeight];
                Invalidate();
            }
        }

        public BlockKind EditBlockKind { get; set; }

        public Boolean EditMode { get; set; }

        #endregion

        #region [ Construction ]

        public PuzzleVisualizer()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            _puzzleBlocks = new BlockKind[1, 1];
        }

        #endregion

        #region [ Public Methods ]

        public Maze GetMaze()
        {
            return _puzzleBlocks.ConvertPathFinderPuzzleToMaze(this.GridWidth, this.GridHeight);
        }

        public void FromMaze(Maze maze)
        {
            this.GridWidth = maze.Width;
            this.GridHeight = maze.Height;
            _puzzleBlocks = maze.ConvertMazeToPathFinderPuzzle();
        }

        #endregion

        #region [ Event Handlers ]

        private void PathFinderPuzzleControl_Paint(object sender, PaintEventArgs e)
        {
            IterateBlocks((x, y) =>
            {
                Rectangle blockRectangle = CalculateBlockRectangle(x, y);
                switch (_puzzleBlocks[x, y])
                {
                    case BlockKind.Empty:
                        e.Graphics.DrawImage(_emptyImage, blockRectangle);
                        break;
                    case BlockKind.Wall:
                        e.Graphics.DrawImage(_wallImage, blockRectangle);
                        break;
                    case BlockKind.Start:
                        e.Graphics.DrawImage(_emptyImage, blockRectangle);
                        e.Graphics.DrawImage(_startImage, blockRectangle);
                        break;
                    case BlockKind.Finish:
                        e.Graphics.DrawImage(_emptyImage, blockRectangle);
                        e.Graphics.DrawImage(_finishImage, blockRectangle);
                        break;
                    case BlockKind.Teleport1:
                        e.Graphics.DrawImage(_emptyImage, blockRectangle);
                        e.Graphics.DrawImage(_teleport1Image, blockRectangle);
                        break;
                    case BlockKind.Teleport2:
                        e.Graphics.DrawImage(_emptyImage, blockRectangle);
                        e.Graphics.DrawImage(_teleport2Image, blockRectangle);
                        break;
                    case BlockKind.Teleport3:
                        e.Graphics.DrawImage(_emptyImage, blockRectangle);
                        e.Graphics.DrawImage(_teleport3Image, blockRectangle);
                        break;
                }
                e.Graphics.DrawRectangle(_borderPen, blockRectangle);
            });
        }

        private void PathFinderPuzzleControl_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void PathFinderPuzzleControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.EditMode)
            {
                DrawBlock(e);
            }
        }

        private void PathFinderPuzzleControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.EditMode)
            {
                DrawBlock(e);
            }
        }

        #endregion

        #region [ Helper Methods ]

        private void DrawBlock(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IterateBlocks((x, y) =>
                {
                    Rectangle blockRectangle = CalculateBlockRectangle(x, y);
                    if (blockRectangle.Contains(e.Location))
                    {
                        BlockKind oldKind = _puzzleBlocks[x, y];
                        if (oldKind != EditBlockKind)
                        {
                            _puzzleBlocks[x, y] = EditBlockKind;
                            Invalidate();
                        }
                    }
                });
            }
        }

        private Int32 CalculateBlockWidth()
        {
            return (this.Width - 1) / (this.GridWidth < 1 ? 1 : this.GridWidth);
        }

        private Int32 CalculateBlockHeight()
        {
            return (this.Height - 1) / (this.GridHeight < 1 ? 1 : this.GridHeight);
        }

        private Rectangle CalculateBlockRectangle(Int32 x, Int32 y)
        {
            Int32 blockWidth = CalculateBlockWidth();
            Int32 blockHeight = CalculateBlockHeight();
            return new Rectangle(x * blockWidth, y * blockHeight, blockWidth, blockHeight);
        }

        private void IterateBlocks(Action<Int32, Int32> action)
        {
            for (Int32 x = 0; x < GridWidth; x++)
            {
                for (Int32 y = 0; y < GridHeight; y++)
                {
                    action(x, y);
                }
            }
        }

        #endregion
    }
}