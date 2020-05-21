namespace Izsekovanje_rondelic
{
    class Tape : System.ComponentModel.IDataErrorInfo
    {
        public int width { get; set; }
        public int length { get; set; }
        public int xDistance { get; set; }
        public int yDistance { get; set; }
        public int r { get; set; }
        public int distance { get; set; }

        public Tape()
        {
            this.width = 200;
            this.length = 500;
            this.xDistance = 10;
            this.yDistance = 10;
            this.r = 25;
            this.distance = 5;
        }

        public int GetArea()
        {
            return width * length;
        }

        public int GetNetArea()
        {
            return (width - 2 * yDistance) * (length - 2 * xDistance);
        }

        public int NetWidth()
        {
            return width - 2 * yDistance;
        }

        public int NetLength()
        {
            return length - 2 * xDistance;
        }

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
                    case "length":
                        if (this.length < 1 || this.length > 100000)
                            return "Dolžina ne sme presegati 100m.";
                        if (this.length < this.width)
                            return "Širina ne sme presegati dolžine.";
                        break;
                    case "width":
                        if (this.width < 1 || this.width > 10000)
                            return "Širina ne sme presegati 10m.";
                        if (this.width > this.length)
                            return "Širina ne sme presegati dolžine.";
                        break;
                    case "xDistance":
                        if (this.xDistance < 1 || this.xDistance > this.length / 5)
                            return "Najmanj 1mm in max 20% dolžine traku.";
                        break;
                    case "yDistance":
                        if (this.yDistance < 1 || this.yDistance > this.width / 5)
                            return "Najmanj 1mm in max 20% širine traku.";
                        break;
                    case "r":
                        if (this.r < 1 || this.r > (this.width - this.yDistance*2) / 2)
                            return "Najmanj 1mm in max polovica širine traku, upoštevajoč robove.";
                        break;
                    case "distance":
                        if (this.distance < 1)
                            return "Najmanj 1mm.";
                        break;
                }
                return string.Empty;
            }
        }
    }
}
