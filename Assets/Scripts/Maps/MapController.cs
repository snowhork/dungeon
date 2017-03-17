using Players;
using UnityEngine;
using Utility;

namespace Maps
{
    public class MapController : MonoBehaviour
    {
        private int[,] _mapChips;
        private MapInfo _mapInfo;

        public MapInfo MapInfo
        {
            get { return _mapInfo; }
        }

        [SerializeField] private BaseMapChip[] _baseMapChips;

        public int MapXMax { get { return _mapChips.GetLength(0); } }
        public int MapYMax { get { return _mapChips.GetLength(1); } }

        public MapController Initialize()
        {
            _mapChips = new int[,]
            {
                {1, 1, 1, 1},
                {1, 0, 0, 1},
                {1, 0, 1, 1},
                {1, 0, 0, 1},
                {1, 1, 1, 1}
            };

            for (var x = 0; x < MapXMax; x++)
            {
                for (var y = 0; y < MapYMax; y++)
                {
                    SetMapChip(x, y);
                }
            }
            _mapInfo = new MapInfo(_mapChips, _baseMapChips);
            return this;
        }

        private void SetMapChip(int x, int y)
        {
            var mapChip = Instantiate(_baseMapChips[_mapChips[x, y]]);
            mapChip.IntTransform.Position = new IntVector(x, y);
            mapChip.SetTransform();
        }
    }
}
