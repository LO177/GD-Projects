using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

[CreateAssetMenu(fileName = "Level Set", menuName = "Tower Defense/Level Set")]
public class LevelSet : ScriptableObject
{
    [SerializeField]
    LevelTemplate[] m_Levels;

    public int LevelCount { get { return m_Levels.Length; } }

    public LevelTemplate Level(int index)
    {
        if (m_Levels != null && m_Levels.Length != 0)
        {
            return m_Levels[Mathf.Clamp(index, 0, m_Levels.Length - 1)];
        }
        Debug.LogError("No levels exist");
        return new LevelTemplate();
    }
}