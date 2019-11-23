using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;  

public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int columns;
    public int rows;
    public Count wallCount = new Count(5, 9);
    //public Count foodCount = new Count(1, 5);
    public GameObject[] floorTiles;                                
    public GameObject[] wallTiles;   
    public GameObject[] enemyTiles; 
    public GameObject[] outerWallTiles;

    public GameObject[] upperWalls;

    private GameObject m_Grille;
    private List<Vector3> m_gridPositions = new List<Vector3>();
    void InitialiseList()
    {
        m_gridPositions.Clear();

        for (int x = 1; x < columns - 2; x++)
        {
            for (int y = 1; y < rows - 4; y++)
            {
                m_gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void BoardSetup()
    {
        m_Grille = GameObject.Find("GrilleRandom");
        rows = (int)m_Grille.gameObject.GetComponent<Grille>().RowCount;
        columns = (int)m_Grille.gameObject.GetComponent<Grille>().ColumnCount;

        for (int x = 1; x < columns-1; x++)
        {
            for (int y = 1; y < rows - 4; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];

                /*
                if (x == 0)
                    toInstantiate = outerWallTiles[2];
                else if (x == columns-1)
                    toInstantiate = outerWallTiles[1];
                else if (y == 0)
                    toInstantiate = outerWallTiles[0];
                else if (y == rows-1)
                    toInstantiate = outerWallTiles[3];
                    */

                AjustTileToGrid(toInstantiate, new Vector3(x, y, 0f));
            }
        }
    }

    private Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, m_gridPositions.Count);
        Vector3 randomPosition = m_gridPositions[randomIndex];
        m_gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    private void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            if(tileChoice.name == "TopMurHaut")
            {
                AjustTileToGrid(upperWalls[0], new Vector3(randomPosition.x , randomPosition.y-1, randomPosition.z));
                AjustTileToGrid(upperWalls[1], new Vector3(randomPosition.x , randomPosition.y-2, randomPosition.z));
            }

            AjustTileToGrid(tileChoice, randomPosition);
        }
    }

    private void AjustTileToGrid(GameObject a_ToInstantiate, Vector3 a_TileWorldPosition)
    {
        Vector2Int t_GrillePos = m_Grille.GetComponent<Grille>().WorldToGrid(a_TileWorldPosition);
        Vector3 t_CellCenter = m_Grille.GetComponent<Grille>().GridToWorld(t_GrillePos);

        GameObject instance =
            Instantiate(a_ToInstantiate, t_CellCenter, Quaternion.identity) as GameObject;

        //m_Tuiles[t_GrillePos.x, t_GrillePos.y] = instance.GetComponent<Tuile>();
        //m_Tuiles[t_GrillePos.x, t_GrillePos.y].x = (uint)t_GrillePos.x;
        //m_Tuiles[t_GrillePos.x, t_GrillePos.y].y = (uint)t_GrillePos.y;

        Tuile t_TileScript = instance.GetComponent<Tuile>();
        t_TileScript.x = (uint)t_GrillePos.x;
        t_TileScript.y = (uint)t_GrillePos.y;

        float t_CellSize = m_Grille.GetComponent<Grille>().CellSize;
        Sprite t_Sprite = instance.GetComponent<SpriteRenderer>().sprite;
        float t_Scale = t_CellSize / (t_Sprite.rect.width / t_Sprite.pixelsPerUnit);
        instance.transform.localScale = new Vector3(t_Scale, t_Scale, t_Scale);

        instance.transform.SetParent(m_Grille.transform);
    }

    public void SetupScene()
    {
        BoardSetup();
        InitialiseList();
        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
        //int enemyCount = 5;
        //LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount);
    }
}