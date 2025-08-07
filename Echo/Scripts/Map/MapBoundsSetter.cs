using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapBoundsSetter : MonoBehaviour
{
    // Start is called before the first frame update

    public Tilemap tilemap; // Reference to the Tilemap component
    public CamFollow cameraFollow; // Reference to the camera follow script
    void Start()
    {
        Vector3Int minCell = tilemap.cellBounds.min;
        Vector3Int maxCell = tilemap.cellBounds.max;

        Vector3 minWorld = tilemap.CellToWorld(minCell);
        Vector3 maxWorld = tilemap.CellToWorld(maxCell);

        cameraFollow.minBounds = new Vector2(minWorld.x, minWorld.y);
        cameraFollow.maxBounds = new Vector2(maxWorld.x, maxWorld.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
