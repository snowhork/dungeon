using FieldObjects;
using Utility;

namespace Maps
{
    public abstract class BaseMapChip : StaticObject
    {
        public abstract bool Movable(IntTransform intTransform);
    }
}
