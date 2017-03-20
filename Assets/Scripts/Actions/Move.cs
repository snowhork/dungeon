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

        public override bool Execute()
        {
            if(!MapInfo.Movable(IntTransform.Position + _direction, IntTransform)) return false;
            IntTransform.Position += _direction;
            return true;
        }
    }
}
