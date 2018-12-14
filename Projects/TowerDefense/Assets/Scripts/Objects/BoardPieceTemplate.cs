using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoardPiece Template", menuName = "Tower Defence/Board Piece Template")]
public class BoardPieceTemplate : ScriptableObject {

    [SerializeField]
    string m_DisplayName;
    
    public string DisplayName { get { return m_DisplayName; } }

    [SerializeField]
    int m_BuildCost;

    public int BuildCost { get { return m_BuildCost; } }

    [SerializeField]
    Sprite m_BuildUISprite;

    public Sprite BuildUISprite { get { return m_BuildUISprite; } }

    [SerializeField]
    BoardPiece m_BoardPiece;

    public BoardPiece SpawnBoardPiece(Transform parent)
    {
        BoardPiece temp = Instantiate(m_BoardPiece);

        temp.transform.SetParent(parent);

        temp.Init(this);

        return temp;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
