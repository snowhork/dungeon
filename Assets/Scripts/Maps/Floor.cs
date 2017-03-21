using Utility;

namespace Maps
{
    public class Floor : BaseMapChip
    {
        public override bool Movable(IntTransform intTransform)
        {
            return true;
        }
    }
}
