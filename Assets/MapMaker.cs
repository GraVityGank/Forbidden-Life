using UnityEngine;

public class MapMaker : MonoBehaviour
{
    public GameObject tilePrefab;

    [SerializeField]
    int mapWidth = 8;

    [SerializeField]
    int mapHeight = 5;

    [SerializeField]
    float tileOffset = 5f;


    void Start()
    {
        CreateQuadTileMap();
    }

    void CreateQuadTileMap()
    {
        for (int x = 0; x <= mapWidth; x++)
        {
            for (int y = 0; y <= mapHeight; y++)
            {
                GameObject TempGO = Instantiate(tilePrefab);
                TempGO.transform.position = new Vector2(x * tileOffset, y * tileOffset);
                SetTileInfo(TempGO, x, y);
            }
        }
    }

    void SetTileInfo(GameObject GO, int x, int y)
    {
        GO.transform.parent = transform;
        GO.name = x.ToString() + ", " + y.ToString();
    }
}
   
