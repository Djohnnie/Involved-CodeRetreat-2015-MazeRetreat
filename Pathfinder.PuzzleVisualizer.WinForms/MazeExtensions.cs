using PathFinder.DataModel;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Pathfinder.PuzzleVisualizer.WinForms
{
    public static class MazeExtensions
    {
        public static void SaveMazeToFile(this Maze maze, String filePath)
        {
            var simpleMazeData = "";
            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    simpleMazeData += GetSimpleData(maze[x, y]);
                }
                simpleMazeData += Environment.NewLine;
            }
            using (var fileWriter = new StreamWriter(filePath))
            {
                var xmlWriter = new XmlSerializer(typeof(Maze));
                xmlWriter.Serialize(fileWriter, maze);
            }
            File.WriteAllText(filePath + ".simple", simpleMazeData);
        }

        private static string GetSimpleData(Cell cell)
        {
            if (cell is Empty) return ".";
            if (cell is Wall) return "#";
            if (cell is Teleport) return ((Teleport)cell).Address.ToString();
            if (cell is Start) return "S";
            if (cell is Finish) return "F";
            return " ";
        }

        public static Maze LoadMazeFromFile(String filePath)
        {
            using (var fileReader = new StreamReader(filePath))
            {
                var xmlWriter = new XmlSerializer(typeof(Maze));
                return xmlWriter.Deserialize(fileReader) as Maze;
            }
        }

        public static Maze ConvertPathFinderPuzzleToMaze(this PuzzleVisualizer.BlockKind[,] puzzleBlocks, Int32 width, Int32 height)
        {
            var mazeToReturn = new Maze(width, height);
            for (Int32 x = 0; x < width; x++)
            {
                for (Int32 y = 0; y < height; y++)
                {
                    switch (puzzleBlocks[x, y])
                    {
                        case PuzzleVisualizer.BlockKind.Empty:
                            mazeToReturn[x, y] = new Empty(x, y);
                            break;
                        case PuzzleVisualizer.BlockKind.Wall:
                            mazeToReturn[x, y] = new Wall(x, y);
                            break;
                        case PuzzleVisualizer.BlockKind.Start:
                            mazeToReturn[x, y] = new Start(x, y);
                            break;
                        case PuzzleVisualizer.BlockKind.Finish:
                            mazeToReturn[x, y] = new Finish(x, y);
                            break;
                        case PuzzleVisualizer.BlockKind.Teleport1:
                            mazeToReturn[x, y] = new Teleport(x, y, 1);
                            break;
                        case PuzzleVisualizer.BlockKind.Teleport2:
                            mazeToReturn[x, y] = new Teleport(x, y, 2);
                            break;
                        case PuzzleVisualizer.BlockKind.Teleport3:
                            mazeToReturn[x, y] = new Teleport(x, y, 3);
                            break;
                    }
                }
            }
            return mazeToReturn;
        }

        public static PuzzleVisualizer.BlockKind[,] ConvertMazeToPathFinderPuzzle(this Maze maze)
        {
            var puzzleBlocks = new PuzzleVisualizer.BlockKind[maze.Width, maze.Height];
            for (var x = 0; x < maze.Width; x++)
            {
                for (var y = 0; y < maze.Height; y++)
                {
                    if (maze[x, y] is Empty)
                    {
                        puzzleBlocks[x, y] = PuzzleVisualizer.BlockKind.Empty;
                    }
                    if (maze[x, y] is Wall)
                    {
                        puzzleBlocks[x, y] = PuzzleVisualizer.BlockKind.Wall;
                    }
                    if (maze[x, y] is Start)
                    {
                        puzzleBlocks[x, y] = PuzzleVisualizer.BlockKind.Start;
                    }
                    if (maze[x, y] is Finish)
                    {
                        puzzleBlocks[x, y] = PuzzleVisualizer.BlockKind.Finish;
                    }
                    var teleport = maze[x, y] as Teleport;
                    if (teleport != null)
                    {
                        switch (teleport.Address)
                        {
                            case 1:
                                puzzleBlocks[x, y] = PuzzleVisualizer.BlockKind.Teleport1;
                                break;
                            case 2:
                                puzzleBlocks[x, y] = PuzzleVisualizer.BlockKind.Teleport2;
                                break;
                            case 3:
                                puzzleBlocks[x, y] = PuzzleVisualizer.BlockKind.Teleport3;
                                break;
                            default:
                                puzzleBlocks[x, y] = PuzzleVisualizer.BlockKind.Empty;
                                break;
                        }
                    }
                }
            }
            return puzzleBlocks;
        }
    }
}