using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PathFinder.DataModel;
using System.Windows.Data;

namespace PathFinder.PuzzleVisualizer
{
    /// <summary>
    /// Interaction logic for PuzzleVisualizer.xaml
    /// </summary>
    public partial class PuzzleVisualizer : UserControl
    {

        private Maze _maze;

        public Maze Maze
        {
            get { return _maze; }
            set
            {
                _maze = value;
                FullRefresh();
            }
        }

        public PuzzleVisualizer()
        {
            InitializeComponent();
        }

        private void FullRefresh()
        {
            mainGrid.Children.Clear();
            mainGrid.ColumnDefinitions.Clear();
            mainGrid.RowDefinitions.Clear();
            for (Int32 x = 0; x < _maze.Width; x++) { mainGrid.ColumnDefinitions.Add(new ColumnDefinition()); }
            for (Int32 y = 0; y < _maze.Height; y++) { mainGrid.RowDefinitions.Add(new RowDefinition()); }
            for (Int32 x = 0; x < _maze.Width; x++)
            {
                for (Int32 y = 0; y < _maze.Height; y++)
                {
                    var cell = _maze[x, y];
                    var imageElement = new ElementFactory<Image>().Create().SetGridLocation(x, y);
                    var backImageElement = new ElementFactory<Image>().Create().SetImageSource("images/empty.jpg").SetGridLocation(x, y);
                    var empty = cell as Empty;
                    if (empty != null)
                    {
                        imageElement.SetImageSource("images/empty.jpg");
                    }
                    var wall = cell as Wall;
                    if (wall != null)
                    {
                        imageElement.SetImageSource("images/wall.jpg");
                    }
                    var start = cell as Start;
                    if (start != null)
                    {
                        imageElement.SetImageSource("images/start.png");
                        backImageElement.AddToParent(mainGrid.Children);
                    }
                    var finish = cell as Finish;
                    if (finish != null)
                    {
                        imageElement.SetImageSource("images/finish.png");
                        backImageElement.AddToParent(mainGrid.Children);
                    }
                    var teleport = cell as Teleport;
                    if (teleport != null)
                    {
                        imageElement.SetImageSource(String.Format("images/teleport{0}.png", teleport.Address));
                        backImageElement.AddToParent(mainGrid.Children);
                    }
                    imageElement.AddToParent(mainGrid.Children);
                    if (cell.Step.HasValue)
                    {
                        var stepTextBlockElement = new ElementFactory<TextBlock>().Create()
                            .SetGridLocation(x, y)
                            .CenterInParent()
                            .SetText(cell.Step.Value.ToString())
                            //.BindCell(cell)
                            .SetFont(40, 400, Brushes.White)
                            .AddToParent(mainGrid.Children);
                    }
                }
            }
        }

        public void Refresh()
        {

        }

        private class ElementFactory<TElement> where TElement : FrameworkElement
        {
            private TElement _element;


            public ElementFactory<TElement> Create()
            {
                _element = Activator.CreateInstance<TElement>();
                return this;
            }

            public ElementFactory<TElement> LinkCell(Cell cell)
            {
                if (_element != null)
                {
                    _element.Tag = cell;
                }
                return this;
            }

            public ElementFactory<TElement> AddToParent(UIElementCollection childrenCollection)
            {
                if (_element != null)
                {
                    childrenCollection.Add(_element);
                }
                return this;
            }

            public ElementFactory<TElement> SetGridLocation(Int32 column, Int32 row)
            {
                if (_element != null)
                {
                    Grid.SetColumn(_element, column);
                    Grid.SetRow(_element, row);
                }
                return this;
            }

            public ElementFactory<TElement> CenterInParent()
            {
                if (_element != null)
                {
                    _element.HorizontalAlignment = HorizontalAlignment.Center;
                    _element.VerticalAlignment = VerticalAlignment.Center;
                }
                return this;
            }

            public ElementFactory<TElement> SetText(String text)
            {
                var textBlock = _element as TextBlock;
                if (textBlock != null)
                {
                    textBlock.Text = text;
                }
                return this;
            }

            public ElementFactory<TElement> BindCell(Cell cell)
            {
                var textBlock = _element as TextBlock;
                if (textBlock != null)
                {
                    textBlock.DataContext = cell;
                    textBlock.SetBinding(TextBlock.TextProperty, new Binding("Step") { Mode = BindingMode.TwoWay, TargetNullValue = "" });
                }
                return this;
            }

            public ElementFactory<TElement> SetFont(Int32 fontSize, Int32 fontWeight, Brush foreground)
            {
                var textBlock = _element as TextBlock;
                if (textBlock != null)
                {
                    textBlock.FontSize = fontSize;
                    textBlock.FontWeight = FontWeight.FromOpenTypeWeight(fontWeight);
                    textBlock.Foreground = foreground;
                }
                return this;
            }

            public ElementFactory<TElement> SetImageSource(String uri)
            {
                var image = _element as Image;
                if (image != null)
                {
                    image.Stretch = Stretch.Fill;
                    image.Source = new BitmapImage(new Uri(uri, UriKind.Relative));
                }
                return this;
            }
        }
    }
}