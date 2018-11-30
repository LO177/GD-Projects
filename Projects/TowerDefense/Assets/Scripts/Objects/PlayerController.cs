using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoSingleton<PlayerController> {

    LevelTemplate m_level;

    ISelectable m_SelectedObject;

    int m_SelectableLayerMask;

    // Use this for initialization
    public void Init(LevelTemplate template)
    {
        m_level = template;

        m_SelectableLayerMask = LayerMask.GetMask("Selectable");
    }
    
	// Update is called once per frame
	public void Iterate () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f, m_SelectableLayerMask))
        {
            ISelectable hitBoardPiece = hit.collider.GetComponent<ISelectable>();
            if (hitBoardPiece != null)
            {
                //If there is a currently selected board piece ... deselect it
                if (m_SelectedObject != null)
                {
                    m_SelectedObject.Deselect();
                }
                //set the hit piece to be the selected object
                m_SelectedObject = hitBoardPiece;
                //Call select method on the selected object
                m_SelectedObject.Select();
            }
        }
        else
        {
            if (m_SelectedObject != null)
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    m_SelectedObject.Deselect();
                }
            }
        }
	}
}
