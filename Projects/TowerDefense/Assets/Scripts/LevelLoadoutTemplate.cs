using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Loadout Template", menuName = "Tower Defence/Level Loadout Template")]
public class LevelLoadoutTemplate : ScriptableObject
{
    [SerializeField]
    BoardPieceTemplate[] m_BoardPieces;

    public BoardPieceTemplate[] BoardPieces { get { return m_BoardPieces; } }
}
