using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameboard : MonoSingleton<Gameboard> {

    public GameObject[] m_Tiles { get; private set; }

    public GameObject m_TilePrefab;

    private int m_GridRows;

    private int m_GridColumns;

    private void Awake()
    {
        
    }

    // Use this for initialization
    public void Init(LevelTemplate template)
    {

        m_GridRows = template.GridRows;//5;
        m_GridColumns = template.GridColumns;//5;
        GenerateBoard();

        float averageSize = (m_GridRows + m_GridColumns) * 0.5f;
        Camera.main.transform.position = new Vector3(0, averageSize, -(averageSize * 0.1f));
        Camera.main.transform.LookAt(Vector3.zero);
    }

    void GenerateBoard()
    {
        m_Tiles = new GameObject[m_GridRows * m_GridColumns];

        for (int row = 0; row < m_GridRows; row++)
        {
            for (int col = 0; col < m_GridColumns; col++)
            {
                GameObject emptyTile = Instantiate(m_TilePrefab);
                emptyTile.name = row + " - " + col;
                emptyTile.transform.position = new Vector3(row - ((m_GridRows - 1f) / 2f), 0, -col + ((m_GridColumns - 1f) / 2f));
                m_Tiles[(m_GridColumns * row) + col] = emptyTile;
            }
        }
    }

    public GameObject GetTileFromVector(Vector2 gridCoords)
    {
        return m_Tiles[(m_GridColumns * (int)gridCoords.x) + (int)gridCoords.y];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
