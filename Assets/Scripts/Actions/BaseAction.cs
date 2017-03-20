using Maps;
using Utility;

namespace Actions
{
    public abstract class BaseAction
    {
        protected MapInfo MapInfo;
        protected IntTransform IntTransform;

        protected BaseAction(IntTransform intTransform, MapInfo mapInfo)
        {
            MapInfo = mapInfo;
            IntTransform = intTransform;
        }

        public abstract bool Execute();
    }
}
