namespace Quiz1
{
    public class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal int[] GetXYPair()
        {
            int[] result = new int[2];
            result[0] = x;
            result[1] = y;
            return result;
        }
        protected internal double Distance(int x, int y)
        {
            return Math.Sqrt(Math.Pow(this.x - x, 2) + Math.Pow(this.y - y, 2));
        }

        protected internal double Distance(Point p)
        {
            return Math.Sqrt(Math.Pow(this.x - p.x, 2) + Math.Pow(this.y - p.y, 2));
        }

        public static explicit operator double(Point p)
        {
            double result = p.Distance(0, 0);
            return result;
        }

    }
}
