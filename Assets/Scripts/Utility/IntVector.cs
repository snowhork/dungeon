namespace Utility
{
    public struct IntVector
    {
        private int _x;
        private int _y;

        public IntVector(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public IntVector RotateRight
        {
            get { return new IntVector(-Y, X); }
        }

        public IntVector RotateLeft
        {
            get { return new IntVector(Y, -X); }
        }

        public IntVector RotateBack
        {
            get { return new IntVector(-X, -Y); }
        }

        public static IntVector operator +(IntVector a, IntVector b)
        {
            return new IntVector(a.X + b.X, a.Y + b.Y);
        }

        public static IntVector operator -(IntVector a, IntVector b)
        {
            return new IntVector(a.X - b.X, a.Y - b.Y);
        }
    }
}