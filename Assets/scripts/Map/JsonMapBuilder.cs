using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class JsonMapBuilder : MonoBehaviour
{
    [SerializeField]
    private TextAsset mapJson;

    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject basePlane;

    private class MapList
    {
        public List<List<int>> map;
        public List<string> mapping;

    }

    private MapList mapList = new MapList();

    private int xSize;
    private int ySize;

    


    // Start is called before the first frame update
    void Start()
    {
        mapList = JsonConvert.DeserializeObject<MapList>(mapJson.ToString());

        ySize = mapList.map.Count;
        xSize = mapList.map[0].Count;

        BuildMap();
    }

    string GetMapObjectFromMap(int x, int y)
    {
        Debug.Log(mapList.mapping[mapList.map[y][x]]);
        return mapList.mapping[mapList.map[y][x]];
    }

    void BuildMap()
    {
        GameObject baseObject = Instantiate(basePlane, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
        baseObject.GetComponent<BaseSizeModifier>().SetBaseSize(xSize, ySize);

        for (int yIndex = 0; yIndex < ySize; yIndex++) 
        {
            for (int xIndex = 0; xIndex < xSize; xIndex++) 
            {
                if (GetMapObjectFromMap(xIndex, yIndex) == "wall")
                {
                    Instantiate(wall, new Vector3(yIndex, 0, xIndex), Quaternion.identity, gameObject.transform);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
