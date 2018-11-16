using UnityEngine;

/// <summary>
/// Game Manager that controls the update calls to the game mode
/// inherits from MonoSingleton to implement the singleton pattern
/// </summary>
public class GameManager : MonoSingleton<GameManager>
{
    /// <summary>
    /// current game mode for the scene
    /// </summary>
    IGameMode m_GameMode;

    protected override bool Awake()
    {
        //base call to MonoSingleton
        if (base.Awake())
        {
            // makes it so that this object doesn't get destroyed when a scene is changed.
            DontDestroyOnLoad(gameObject);
        }

        //update the current game mode
        Instance.UpdateGameMode();

        return true;
    }

    /// <summary>
    /// finds the game mode object in the scene
    /// </summary>
    public void UpdateGameMode()
    {
        GameObject gameMode = GameObject.Find("Game Mode");
        if (gameMode == null)
            Debug.LogError("No object in the scene called Game Mode");
        else
        {
            m_GameMode = gameMode.GetComponent<IGameMode>();
            if (m_GameMode == null)
                Debug.LogError("The Game Mode object doesn't implement IGameMode");
        }
    }

    /// <summary>
    /// Only update call needed
    /// </summary>
    void Update()
    {
        if (m_GameMode != null)
            m_GameMode.Iterate();
    }
}
