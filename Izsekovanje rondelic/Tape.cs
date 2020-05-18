namespace Izsekovanje_rondelic
{
    class Tape
    {
        public int width { get; set; }
        public int length { get; set; }
        public int xDistance { get; set; }
        public int yDistance { get; set; }

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
    }
}
