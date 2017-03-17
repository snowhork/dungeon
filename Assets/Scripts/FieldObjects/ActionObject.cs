using Maps;
using Utility;

namespace FieldObjects
{
    public abstract class ActionObject : FieldObject
    {
        private IntVector _forward;

        public IntVector Forward
        {
            get { return _forward; }
            set { _forward = value; }
        }

        public abstract void Action(MapInfo mapInfo);
    }
}