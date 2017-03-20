using System.Collections.Generic;
using FieldObjects;
using Utility;

namespace Maps
{
    public class MapInfo
    {
        private MapChipInfo[,] _mapChipInfo;

        public MapInfo(int[,] mapChips, BaseMapChip[] baseMapChips)
        {
            _mapChipInfo = new MapChipInfo[mapChips.GetLength(0), mapChips.GetLength(1)];

            for (var x = 0; x < mapChips.GetLength(0); x++)
            {
                for (var y = 0; y < mapChips.GetLength(1); y++)
                {
                    _mapChipInfo[x, y] = new MapChipInfo(baseMapChips[mapChips[x, y]]);
                }
            }
        }

        public void Append(IntVector position, FieldObject fieldObject)
        {
            var info = GetMapChipInfo(position);
            info.FieldObjects.Add(fieldObject);
        }

        public void Remove(IntVector position, FieldObject fieldObject)
        {
            var info = GetMapChipInfo(position);
            info.FieldObjects.Remove(fieldObject);
        }

        public bool Movable(IntVector position, IntTransform intTransform)
        {
            var info = GetMapChipInfo(position);
            return info.MapChip.Movable(intTransform);
        }

        private MapChipInfo GetMapChipInfo(IntVector position)
        {
            return _mapChipInfo[position.X, position.Y];
        }

        private struct MapChipInfo
        {
            private readonly BaseMapChip _mapChip;
            private readonly List<FieldObject> _fieldObjects;

            public List<FieldObject> FieldObjects
            {
                get { return _fieldObjects; }
            }

            public BaseMapChip MapChip
            {
                get { return _mapChip; }
            }

            public MapChipInfo(BaseMapChip mapChip)
            {
                _mapChip = mapChip;
                _fieldObjects = new List<FieldObject>();
            }
        }

    }
}
