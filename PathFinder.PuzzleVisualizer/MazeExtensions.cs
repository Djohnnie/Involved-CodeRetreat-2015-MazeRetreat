using PathFinder.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PathFinder.PuzzleVisualizer
{
   public static class MazeExtensions
    {
        public static void SaveMazeToFile(this Maze maze, String filePath)
        {
            using (var fileWriter = new StreamWriter(filePath))
            {
                var xmlWriter = new XmlSerializer(typeof(Maze));
                xmlWriter.Serialize(fileWriter, maze);
            }
        }

        public static Maze LoadMazeFromFile(String filePath)
        {
            using (var fileReader = new StreamReader(filePath))
            {
                var xmlWriter = new XmlSerializer(typeof(Maze));
                return xmlWriter.Deserialize(fileReader) as Maze;
            }
        }
    }
}
