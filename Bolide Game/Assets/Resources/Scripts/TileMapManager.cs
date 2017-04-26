using UnityEngine;
using System.Collections;

public class TileMapManager : MonoBehaviour {

    public int MAP_HEIGHT = 5;
    public int MAP_WIDTH = 5;
    private float TILE_HEIGHT;
    private float TILE_WIDTH;
    private GameObject tile;

    private int[,] mapData = new int[,] { {1,1,1,1,1 },
                                          {1,0,0,0,1 },
                                          {1,0,0,0,1 },
                                          {1,0,0,0,1 },
                                          {1,1,1,1,1 }
                                        };


    // load prefab tiles from prefab folder
    

	// Use this for initialization
	void Start () {
        
        CreateLevel();
	}

    private void CreateLevel()
    {

        

        for (int i = 0; i < MAP_HEIGHT; i++)
        {
            for (int j = 0; j < MAP_WIDTH; j++)
            {
                var x = TILE_WIDTH * j;
                var y = TILE_HEIGHT * i;

                int tileType = mapData[i,j];
                
                PlaceTile(tileType,new Vector2(x, y));


            }
        }
    }

    private void PlaceTile( int tileType, Vector2 tilePlacement)
    {
        
        switch (tileType)
        {
            case 0:
                tile = Resources.Load<GameObject>("Prefabs/grassTile");
                TILE_HEIGHT = 1;
                TILE_WIDTH = 1;
                break;
            case 1:
                tile = Resources.Load<GameObject>("Prefabs/waterTile");
                TILE_HEIGHT = 1f;
                TILE_WIDTH = 1;
                break;
            default:
                tile = Resources.Load<GameObject>("Prefabs/voidTile");
                TILE_HEIGHT = 1;
                TILE_WIDTH = 1;
                break;
        }
        

        GameObject newTile = Instantiate(tile);
        newTile.transform.position = tilePlacement;
    }
    
   

}
