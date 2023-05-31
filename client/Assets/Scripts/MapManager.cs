using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // public GameObject plane;
    public GameObject terrain;
    public Renderer rend;
    const float PLANE_DEFAULT_SIZE = 15f;

    public PlacementManager placementManager;
    public GameObject blueHighlightPrefab;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateGridSize(int size)
    {
        var scale = size / 2f;
        rend.material.mainTextureScale = new Vector2(scale, scale);
        terrain.transform.localScale = new Vector3(size / PLANE_DEFAULT_SIZE, 1, size / PLANE_DEFAULT_SIZE);
        terrain.transform.localPosition = new Vector3(scale - 0.5f, 0, scale - 0.5f);
    }

    public void highlightOwnedLands(Land[] landOwnedIndexes, int perSize)
    {
        foreach (var land in landOwnedIndexes)
        {
            int x1 = (int)land.xIndex * perSize;
            int y1 = (int)land.yIndex * perSize;
            int x2 = x1 + perSize - 1;
            int y2 = y1 + perSize - 1;
            int tmpY1 = y1;
            while (x1 <= x2)
            {
                while (y1 <= y2)
                {
                    placementManager.PlaceObjectOnTheMapHighlight(new Vector3Int(x1, 0, y1), blueHighlightPrefab);
                    y1++;
                }
                y1 = tmpY1;
                x1++;
            }
        }
    }
}
