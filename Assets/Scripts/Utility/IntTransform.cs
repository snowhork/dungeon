namespace Utility
{
    public class IntTransform
    {
        private IntVector _position;

        public IntVector Position
        {
            get { return _position; }
            set { _position = value; }
        }

        private IntVector _forward;

        public IntVector Forward
        {
            get { return _forward; }
            set { _forward = value; }
        }
    }
}