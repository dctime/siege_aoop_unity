using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class JsonMapBuilder : MonoBehaviour
{
    [SerializeField]
    private TextAsset mapJson;

    [SerializeField] private GameObject basePlane;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject window;
    [SerializeField] private GameObject softWall;
    [SerializeField] private GameObject entrance;
    [SerializeField] private GameObject barrier;

    private class MapList
    {
        public List<List<int>> map;
        public List<string> mapping;

    }

    private MapList mapList = new MapList();

    private int xSize;
    private int ySize;

    private List<string> windowSideAllowed = new List<string>()
    {
        "window",
        "wall"
    };

    private List<string> signAllowFacing = new List<string>()
    {
        "barrier",
    };

    


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
        if (x >= this.xSize || x < 0 || y >= this.ySize || y < 0)
        {
            return null;
        }
        else
        {
            Debug.Log(mapList.mapping[mapList.map[y][x]]);
            return mapList.mapping[mapList.map[y][x]];
        }
        
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
                else if (GetMapObjectFromMap(xIndex, yIndex) == "door")
                {
                    Instantiate(door, new Vector3(yIndex, 0, xIndex), Quaternion.identity, gameObject.transform);
                }
                else if (GetMapObjectFromMap(xIndex, yIndex) == "window")
                {
                    ExtendDirection.ExtendDirectionEnum extendDirectionEnum;
                    if (windowSideAllowed.Contains(GetMapObjectFromMap(xIndex-1, yIndex))
                        && windowSideAllowed.Contains(GetMapObjectFromMap(xIndex + 1, yIndex)))
                    {
                        extendDirectionEnum = ExtendDirection.ExtendDirectionEnum.XDirection;
                    }
                    else if (windowSideAllowed.Contains(GetMapObjectFromMap(xIndex, yIndex-1))
                        && windowSideAllowed.Contains(GetMapObjectFromMap(xIndex, yIndex + 1)))
                    {
                        extendDirectionEnum = ExtendDirection.ExtendDirectionEnum.YDirection;
                    }
                    else
                    {
                        extendDirectionEnum = ExtendDirection.ExtendDirectionEnum.Null;
                    }

                    
                    GameObject windowObject = Instantiate(window, new Vector3(yIndex, 0, xIndex), Quaternion.identity, gameObject.transform);
                    windowObject.GetComponent<ExtendDirection>().SetExtendDirectionEnum(extendDirectionEnum);
                        
                }
                else if (GetMapObjectFromMap(xIndex, yIndex) == "softWall")
                {
                    Instantiate(softWall, new Vector3(yIndex, 0, xIndex), Quaternion.Euler(0, Random.Range(0, 360), 0), gameObject.transform);
                }
                else if (GetMapObjectFromMap(xIndex, yIndex) == "entrance")
                {
                    List<SignRandomer.Direction> allowedDirections = new List<SignRandomer.Direction>();

                    if (this.signAllowFacing.Contains(GetMapObjectFromMap(xIndex + 1, yIndex)))
                    {
                        allowedDirections.Add(SignRandomer.Direction.PositiveX);
                    }

                    if (this.signAllowFacing.Contains(GetMapObjectFromMap(xIndex - 1, yIndex)))
                    {
                        allowedDirections.Add(SignRandomer.Direction.NegativeX);
                    }

                    if (this.signAllowFacing.Contains(GetMapObjectFromMap(xIndex, yIndex + 1)))
                    {
                        allowedDirections.Add(SignRandomer.Direction.PositiveY);
                    }

                    if (this.signAllowFacing.Contains(GetMapObjectFromMap(xIndex, yIndex - 1)))
                    {
                        allowedDirections.Add(SignRandomer.Direction.NegativeY);
                    }

                    GameObject entranceObject = Instantiate(entrance, new Vector3(yIndex, 0, xIndex), Quaternion.identity, gameObject.transform);
                    int lenAllowDirections = allowedDirections.Count;
                    
                    entranceObject.GetComponent<SignRandomer>().SetRotation(allowedDirections.ElementAt(Random.Range(0, lenAllowDirections)));

                }
                else if (GetMapObjectFromMap(xIndex, yIndex) == "barrier")
                {
                    Instantiate(barrier, new Vector3(yIndex, 0, xIndex), Quaternion.identity, gameObject.transform);
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
