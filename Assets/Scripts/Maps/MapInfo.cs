using System.Collections.Generic;
using FieldObjects;

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

        private struct MapChipInfo
        {
            private BaseMapChip _mapChip;
            private List<FieldObject> _fieldObjects;

            public MapChipInfo(BaseMapChip mapChip)
            {
                _mapChip = mapChip;
                _fieldObjects = new List<FieldObject>();
            }
        }

    }
}