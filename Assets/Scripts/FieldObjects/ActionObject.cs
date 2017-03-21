using System;
using Maps;
using Utility;

namespace FieldObjects
{
    public abstract class ActionObject : FieldObject
    {
        protected MapInfo MapInfo;
        protected BaseActor Actor;

        public virtual void Action(MapInfo mapInfo)
        {
            MapInfo = mapInfo;
            Actor.TurnStart();
        }

        public virtual void Initialize(IntVector position, MapInfo mapInfo)
        {
            base.Initialize(position);
            MapInfo = mapInfo;
        }
    }
}
