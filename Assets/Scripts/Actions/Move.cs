using Maps;
using UnityEngine;
using Utility;

namespace Actions
{
    public class Move : BaseAction
    {
        private IntVector _direction;
        public Move(IntTransform intTransform, MapInfo mapInfo, IntVector direction) : base(intTransform, mapInfo)
        {
            _direction = direction;
        }

        public override bool IsValid
        {
            get { return MapInfo.Movable(IntTransform.Position + _direction, IntTransform); }
        }

        public override bool Execute()
        {
            if(!IsValid) return false;
            IntTransform.Position += _direction;
            return true;
        }
    }
}
