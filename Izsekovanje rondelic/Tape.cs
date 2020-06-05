using System.ComponentModel;

namespace Izsekovanje_rondelic
{
    public class Tape : IShape, IDataErrorInfo
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public int XDistance { get; set; }
        public int YDistance { get; set; }

        public Tape() {
        }

        public Tape(int length, int width, int xDistance, int yDistance)
        {
            Width = width;
            Length = length;
            XDistance = xDistance;
            YDistance = yDistance;
        }

        public int Area =>
            Width * Length;

        public int NetArea =>
            (Width - 2 * YDistance) * (Length - 2 * XDistance);

        public int NetWidth =>
            Width - 2 * YDistance;

        public int NetLength =>
            Length - 2 * XDistance;

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
                    case "Length":
                        if (this.Length < 0 || this.Length > 100000)
                            return "Dolžina mora biti pozitivna in ne presegati 100m.";
                        if (this.Length < this.Width)
                            return "Širina ne sme presegati dolžine.";
                        break;
                    case "Width":
                        if (this.Width < 0 || this.Width > 10000)
                            return "Širina mora biti pozitivna in ne sme presegati 10m.";
                        if (this.Width > this.Length)
                            return "Širina ne sme presegati dolžine.";
                        break;
                    case "XDistance":
                        if (this.XDistance < 0 || this.XDistance > this.Length / 5)
                            return "Najmanj 1mm in max 20% dolžine traku.";
                        break;
                    case "YDistance":
                        if (this.YDistance < 0 || this.YDistance > this.Width / 5)
                            return "Najmanj 1mm in max 20% širine traku.";
                        break;
                }
                return string.Empty;
            }
        }
    }
}
