using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private int[,] _mapChips;
    [SerializeField] private BaseMapChip[] _baseMapChips;

    public int MapXMax { get { return _mapChips.GetLength(0);} }
    public int MapYMax { get { return _mapChips.GetLength(1);} }
    public static float MapChipWidth = 5.8f;


	// Use this for initialization
	void Start ()
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
	}

    private void SetMapChip(int x, int y)
    {
        var mapChip = Instantiate(_baseMapChips[_mapChips[x, y]]);
        mapChip.transform.position = new Vector3(x*MapChipWidth, 0f, y*MapChipWidth);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
