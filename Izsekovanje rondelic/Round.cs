using System;
using System.ComponentModel;

namespace Izsekovanje_rondelic
{
    public class Round : IShape, IDataErrorInfo
    {
        public int R { get; set; }
        public int Distance { get; set; }

        public Round() { }

        public Round(int r, int distance)
        {
            R = r;
            Distance = distance;
        }

        public int Area =>
            int.Parse((Math.PI * R * R).ToString());

        int IShape.NetArea => throw new NotImplementedException();
        int IShape.NetWidth => throw new NotImplementedException();
        int IShape.NetLength => throw new NotImplementedException();

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "R":
                        if (this.R < 0)
                            return "Negativne vrednosti niso dovoljene.";
                        break;
                    case "Distance":
                        if (this.Distance < 0)
                            return "Negativne vrednosti niso dovoljene.";
                        break;
                }
                return string.Empty;
            }
        }
    }
}
