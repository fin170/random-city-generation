using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCity1 : MonoBehaviour
{
    public GameObject[] buildings;
    int[,] mapGrid;
    public int mapHeight = 20;
    public int mapWidth = 20;
    int buildingFootprint = 35;

    void Start()
    {
        mapGrid = new int[mapWidth, mapHeight];

        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                Vector3 pos = new Vector3(w * buildingFootprint, 0, h * buildingFootprint);
                int n = Random.Range(0, buildings.Length);
                Instantiate(buildings[n], pos, Quaternion.identity);
            }
        }
    }
}
