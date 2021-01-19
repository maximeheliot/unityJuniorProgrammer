using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable] public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> { }
 
public class GameManager : Singleton<GameManager>
{
    // Keep track of the game state
    
    // PREGAME, RUNNING, PAUSED
    public enum GameState
    {
        PREGAME,
        RUNNING,
        PAUSED
    }
    
    public GameObject[] systemPrefabs;
    public EventGameState onGameStateChanged;

    private List<GameObject> _instancedSystemPrefabs;
    private List<AsyncOperation> _loadOperations;
    private string _currentLevelName = string.Empty;

    public GameState currentGameState { get; private set; } = GameState.PREGAME;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        _instancedSystemPrefabs = new List<GameObject>();
        _loadOperations = new List<AsyncOperation>();

        InstanciateSystemPrefabs();
    }

    #region Load and Unload game levels

    private void OnLoadOperationComplete(AsyncOperation ao)
    {
        if (_loadOperations.Contains(ao))
        {
            _loadOperations.Remove(ao);

            if (_loadOperations.Count == 0)
            {
                UpdateState(GameState.RUNNING);
            }
        }
        
        Debug.Log("Load Complete.");
    }

    private void OnUnloadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("Unload Complete.");
    }

    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.Log("[GameManager] Unable to load level " + levelName);
            return;
        }
        
        ao.completed += OnLoadOperationComplete;
        _loadOperations.Add(ao);
        
        _currentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.Log("[GameManager] Unable to unload level " + levelName);
            return;
        }
        
        ao.completed += OnUnloadOperationComplete;
    }

    #endregion

    private void InstanciateSystemPrefabs()
    {
        foreach (var obj in systemPrefabs)
        {
            var prefabInstance = Instantiate(obj);
            _instancedSystemPrefabs.Add(prefabInstance);
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        foreach (var obj in _instancedSystemPrefabs)
        {
            Destroy(obj);
        }
        _instancedSystemPrefabs.Clear();
    }

    private void UpdateState(GameState state)
    {
        var previousGameState = currentGameState;
        currentGameState = state;

        switch (currentGameState)
        {
            case GameState.PREGAME:
                break;
            
            case GameState.RUNNING:
                break;
            
            case GameState.PAUSED:
                break;
            
            default:
                break;
        }

        onGameStateChanged.Invoke(currentGameState, previousGameState);
    }

    public void StartGame()
    {
        LoadLevel("Main");
    }
}
