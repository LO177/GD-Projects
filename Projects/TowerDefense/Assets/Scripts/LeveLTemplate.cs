﻿using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

[CreateAssetMenu(fileName = "Level Template", menuName = "Tower Defense/Level Template")]
public class LevelTemplate : ScriptableObject
{
    [SerializeField]
    LevelLoadoutTemplate m_LevelLoadout;

    public int m_Health = 10;

    /// <summary>
    /// Loadout for the level
    /// </summary>
    public LevelLoadoutTemplate LevelLoadout { get { return m_LevelLoadout; } }

    #region Grid

    [SerializeField]
    int m_GridRows;

    public int GridRows { get { return m_GridRows; } }

    [SerializeField]
    int m_GridColumns;

    public int GridColumns { get { return m_GridColumns; } }

    #endregion
}