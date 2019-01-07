using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    /// <summary>
    /// Template for the current level
    /// </summary>
    LevelTemplate m_Level;
    /// <summary>
    /// Prefab button used for the build menu
    /// </summary>
    [SerializeField]
    GameObject m_BuildButtonPrefab;
    /// <summary>
    /// reference to the build menu object
    /// </summary>
    [SerializeField]
    GameObject m_BuildMenu;

    /// <summary>
    /// reference to the content menu which is a child of the build menu
    /// </summary>
    RectTransform m_BuildMenuContent;
    /// <summary>
    /// which object is currently selected by the player
    /// </summary>
    ISelectable m_SelectedObject;

    public void Init(LevelTemplate level)
    {
        LevelTemplate m_Level = level;

        GameObject m_BuildMenu = GameObject.Find("Build Menu");

        //loop through each board piece in the level loadout and create a button for them
        for (int i = 0; i < m_Level.LevelLoadout.BoardPieces.Length; i++)
        {
            //instantiate the button
            Button temp = Instantiate(m_BuildButtonPrefab).GetComponent<Button>();
            //assign the parent
            temp.transform.SetParent(m_BuildMenuContent, false);
            //give it an appropriate name
            temp.name = m_Level.LevelLoadout.BoardPieces[i].DisplayName + " Button";
            //set up the on click event
            int index = i;
            temp.onClick.AddListener(() => BuildObject(index));
            //set the properties of the button
            temp.transform.Find("Name").GetComponent<Text>().text = m_Level.LevelLoadout.BoardPieces[i].DisplayName;
            temp.transform.Find("Cost").GetComponent<Text>().text = m_Level.LevelLoadout.BoardPieces[i].BuildCost.ToString();
            temp.transform.Find("Image").GetComponent<Image>().sprite = m_Level.LevelLoadout.BoardPieces[i].BuildUISprite;
        }
    }

    public void ShowBuildMenu(ISelectable selectedObject) {
        m_SelectedObject = selectedObject;
        m_BuildMenu.SetActive(true);
    }

    public void HideBuildMenu() {
        m_SelectedObject = null;
        m_BuildMenu.SetActive(false);
    }

    private void BuildObject(int index)
    {
        //spawns the board piece
        m_Level.LevelLoadout.BoardPieces[index].SpawnBoardPiece(m_SelectedObject.GetTransform());
        //deselects the current selected object
        m_SelectedObject.Deselect();
    }
}
