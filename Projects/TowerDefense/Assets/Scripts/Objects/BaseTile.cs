using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine;

public class BaseTile : MonoBehaviour, ISelectable
{
    bool m_Selected;
    
    SpriteRenderer m_Sprite;
    
    [SerializeField]
    Color m_DeselectedColour;
    
    [SerializeField]
    Color m_SelectedColour;
    void Awake()
    {
        //get the sprite renderer component
        m_Sprite = GetComponent<SpriteRenderer>();
        //call the deselect function so that the tile is in the correct state
        Deselect();
    }
    
    public void Select()
    {
        UIManager.Instance.ShowBuildMenu(this);
        m_Sprite.color = m_SelectedColour;
        m_Selected = true;
    }
    
    public void Deselect()
    {
        UIManager.Instance.HideBuildMenu();
        m_Sprite.color = m_DeselectedColour;
        m_Selected = false;
    }
    
    public bool Selected()
    {
        return m_Selected;
    }
    
    public Transform GetTransform()
    {
        return transform;
    }
}