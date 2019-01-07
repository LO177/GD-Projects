using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_GameState
{
    BEGINNING,
    WAITING_TO_START,
    PLAYING,
    LEVEL_FINISHED,
    END
};

/// <summary>
/// game mode script for the standard game mode
/// implement the IGameMode interface
/// </summary>
public class GameMode_StandardLevel : MonoBehaviour, IGameMode
{
    /// <summary>
    /// used to observe if the player has triggered the game over condition
    /// </summary>
    bool m_GameOver;

    /// <summary>
    /// controls whether the game has started (will be used to allow the player setup time)
    /// </summary>
    bool m_GameStarted;

    /// <summary>
    /// amount of time that has passed since the game started
    /// </summary>
    float m_GameTime;

    /// <summary>
    /// Current state of the game
    /// </summary>
    E_GameState m_State;

    /// <summary>
    /// Level template of the current level
    /// </summary>
    public LevelTemplate m_Level { get; private set; }
    

    /// <summary>
    /// Processes the game in its current state
    /// </summary>
    public void Iterate()
    {
        switch (m_State)
        {
            case E_GameState.BEGINNING:
                m_State = Beginning();
                break;
            case E_GameState.WAITING_TO_START:
                m_State = WaitingToStart();
                break;
            case E_GameState.PLAYING:
                m_State = Playing();
                break;
            case E_GameState.LEVEL_FINISHED:
                m_State = LevelFinished();
                break;
            case E_GameState.END:
                End();
                break;
        }
    }

    #region Game Flow

    /// <summary>
    /// First method that is called in the game state
    /// used to initialise values
    /// </summary>
    /// <returns>WaitingToStart state</returns>
    E_GameState Beginning()
    {
        m_GameTime = 0.0f;
        m_GameOver = false;
        m_GameStarted = false;

        m_Level = GameManager.Instance.LevelSet.Level(GameManager.Instance.m_LevelIndex);

        UIManager.Instance.Init(m_Level);

        //initialise the Gameboard
        Gameboard.Instance.Init(m_Level);

        PlayerController.Instance.Init(m_Level);

        return E_GameState.WAITING_TO_START;
    }

    /// <summary>
    /// Second method that is called in the game state
    /// </summary>
    /// <returns>Playing state</returns>
    E_GameState WaitingToStart()
    {
        return E_GameState.PLAYING;
    }

    /// <summary>
    /// Third method that is called in the game state (Main game loop)
    /// </summary>
    /// <returns>LevelFinished state</returns>
    E_GameState Playing()
    {
        PlayerController.Instance.Iterate();

        m_GameTime += Time.deltaTime;

        if (m_GameOver)
            return E_GameState.LEVEL_FINISHED;
        else
            return E_GameState.PLAYING;
    }

    /// <summary>
    /// Forth method that is called in the game state
    /// </summary>
    /// <returns>End state</returns>
    E_GameState LevelFinished()
    {
        return E_GameState.END;
    }

    /// <summary>
    /// Final method that is called in the game state repeats until instructed to do otherwise 
    /// (i.e. reloading the scene or reinitializing the level)
    /// </summary>
    /// <returns>End state</returns>
    E_GameState End()
    {
        return E_GameState.END;
    }

    #endregion
}
