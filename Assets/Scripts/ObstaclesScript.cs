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

        Transform tile = Instantiate(allTiles[tileNum], new Vector3((x*offset) - desplX,-2.6f, (y*offset) - desplX), Quaternion.identity) as Transform;

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
    }

}

