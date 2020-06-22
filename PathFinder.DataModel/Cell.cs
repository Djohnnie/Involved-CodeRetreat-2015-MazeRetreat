using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace PathFinder.DataModel
{
    [XmlInclude(typeof(Empty))]
    [XmlInclude(typeof(Wall))]
    [XmlInclude(typeof(Start))]
    [XmlInclude(typeof(Finish))]
    [XmlInclude(typeof(Teleport))]
    public class Cell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private Int32? _step;

        #region [ Public Properties ]

        public Int32 X { get; set; }

        public Int32 Y { get; set; }

        public Int32? Step
        {
            get { return _step; }
            set { _step = value; RaisePropertyChanged("Step"); }
        }

        #endregion

        #region [ Construction ]

        public Cell() { }

        public Cell(Int32 x, Int32 y)
        {
            this.X = x;
            this.Y = y;
        }

        #endregion
    }
}