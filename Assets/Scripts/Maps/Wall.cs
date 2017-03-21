using Utility;

namespace Maps
{
    public class Wall : BaseMapChip
    {
        public override bool Movable(IntTransform intTransform)
        {
            return false;
        }
    }
}
