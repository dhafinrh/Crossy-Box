using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    protected int horizontalSize;

    public virtual void Generate(int size)
    {
        /* for (int x = 0; x < size; x++)
        {
            for (int z = 0; z < size; z++)
            {
                var tile = Instantiate(tilePrefab, transform);
                tile.transform.localPosition = new Vector3(x, 0, z);
            }
        } */

        horizontalSize = size;
        if (size == 0)
        {
            return;
        }

        if ((float)size % 2 == 0)
        {
            size -= 1;
        }

        int limit = Mathf.FloorToInt((float)size / 2);

        for (int x = -limit; x <= limit; x++)
        {
            SpawnTile(x);
        }

        var leftBoundaryTile = SpawnTile(-limit - 1);
        var rightBoundaryTile = SpawnTile(limit + 1);
        DarkenObject(leftBoundaryTile);
        DarkenObject(rightBoundaryTile);
    }

    private GameObject SpawnTile(int xPos)
    {
        var tile = Instantiate(tilePrefab, transform);
        tile.transform.localPosition = new Vector3(xPos, 0, 0);
        return tile;
    }

    private void DarkenObject(GameObject tile)
    {
        var renderer = tile.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
        foreach (var rendLimit in renderer)
        {
            rendLimit.material.color = rendLimit.material.color * Color.grey;
        }
    }
}
