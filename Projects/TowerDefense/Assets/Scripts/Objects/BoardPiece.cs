using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoardPiece : MonoBehaviour {

    protected MeshRenderer m_Renderer;

    protected MeshFilter m_Filter;

    BoardPieceTemplate m_Template;

    public BoardPieceTemplate Template { get { return m_Template; } }

    public void Init(BoardPieceTemplate template)
    {
        m_Template = template;

        m_Renderer = GetComponent<MeshRenderer>();
        m_Filter = GetComponent<MeshFilter>();
        PlaceObject();
    }

    public void PlaceObject()
    {
        transform.localPosition = Vector3.zero;
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
