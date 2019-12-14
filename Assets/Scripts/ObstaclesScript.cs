using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;


public class ObstaclesScript : MonoBehaviour
{
    public Transform tileBlock;
    public Transform tileEmpty;
    public Transform tileCoin;
    public Transform tileCylinder;
    public Transform tileChampi;
    public Transform tileSpikeBall;
    public Transform tileStar;
    public Transform tileSpikes;
    public Transform tileMultiple;
    public TextAsset textMap;
    public List<Transform> allTiles = new List<Transform>();

    

    // Start is called before the first frame update
    void Start()
    {
        initListOfTiles();
        //llegir el document de tiles i cridar funció per cada tile
        readAndInitTiles();
        
    }

    void initTile(string type, int x, int y) {
        float offset = 1.5f;
        float desplX = 0.20f;
        int tileNum = 0;
        int.TryParse(type, out tileNum);

        // empty or block
        if( tileNum == 0 ||  tileNum == 1 ) {
             Transform tile = Instantiate(allTiles[tileNum], new Vector3((x*offset) - desplX,-2.6f, (y*offset)), Quaternion.identity) as Transform;
        }
        //spike
        else if (tileNum == 5){
            Transform tile = Instantiate(allTiles[tileNum], new Vector3(x, 1f , y *1.48f), Quaternion.identity) as Transform;
        }
        else if (tileNum == 2) // moneda
        {
            Transform tile = Instantiate(allTiles[tileNum], new Vector3((x * offset) - 0.8f, 0, (y * offset) - 0.8f), Quaternion.identity) as Transform;
            tile.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        else if (tileNum == 7)
        {
            Transform tile = Instantiate(allTiles[tileNum], new Vector3((x * offset) -0.8f, -1.5f, (y * offset)-0.8f), Quaternion.identity) as Transform;
            tile.localScale = new Vector3(1.8f, 1.8f, 1.8f);

        }
        else if (tileNum == 6) //star
        {
            Transform tile = Instantiate(allTiles[tileNum], new Vector3((x * offset) - 0.8f, 0, (y * offset) - 0.8f), Quaternion.identity) as Transform;
            tile.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (tileNum == 4){ //champi
            Transform tile = Instantiate(allTiles[tileNum], new Vector3(x * 1.4f, -2f , y * 1.45f), Quaternion.identity) as Transform;
        }
        else if (tileNum == 3){
            Transform tile = Instantiate(allTiles[tileNum], new Vector3(x + 0.25f, 7 , y * 1.45f), Quaternion.identity) as Transform;
        }
        else if (tileNum == 8){
            Transform tile = Instantiate(allTiles[tileNum], new Vector3((x*offset) - desplX,-2.6f, (y*offset) - 0.20f), Quaternion.identity) as Transform;
        }
        else {
            Transform tile = Instantiate(allTiles[tileNum], new Vector3(x+0.25f, 1 , y), Quaternion.identity) as Transform;
        }
       

        //GameObject newTile = Instantiate(tilePrefabs[tileNum]);

        //newTile.Transform.position = new Vector3(worldStart.x + (Tile));
    }

    private void readAndInitTiles(){
        
        string sMap = textMap.text;
        string[] mapLines = Regex.Split(sMap, "-");

        for(int y = 0; y < mapLines.Length; y++) {
            string line = mapLines[y];
            string[] values = Regex.Split(line, ",");

            for(int x = 0; x < values.Length; x++) {
                initTile(values[x], x, y);
            }
        }

    }

    private void initListOfTiles() {
        allTiles.Add(tileEmpty);
        allTiles.Add(tileBlock);
        allTiles.Add(tileCoin);
        allTiles.Add(tileCylinder);
        allTiles.Add(tileChampi);
        allTiles.Add(tileSpikeBall);
        allTiles.Add(tileStar);
        allTiles.Add(tileSpikes);
        allTiles.Add(tileMultiple);
    }

}

