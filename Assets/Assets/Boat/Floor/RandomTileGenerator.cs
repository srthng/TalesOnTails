using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTileGenerator : MonoBehaviour
{
    public GameObject[] floorTiles;
    public Vector2 gridSize;
    public Vector2 tileSize;

    void Start()
    {
        GenerateFloor();
    }

    void GenerateFloor()
    {
        Vector3 startPosition = transform.position - new Vector3(gridSize.x / 2, gridSize.y / 2, 0);

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector3 spawnPosition = startPosition + new Vector3(x * tileSize.x, y * tileSize.y, 0);
                int randomIndex = Random.Range(0, floorTiles.Length);
                Instantiate(floorTiles[randomIndex], spawnPosition, Quaternion.identity);
            }
        }
    }
}

