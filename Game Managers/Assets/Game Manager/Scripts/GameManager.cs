using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject[] systemPrefabs;

    private List<GameObject> _instancedSystemPrefabs;
    private string _currentLevelName = string.Empty;
    private List<AsyncOperation> _loadOperations;

    // What level the game is currently in
    
    // Keep track of the game state
    
    // Generate other persistent systems

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        _instancedSystemPrefabs = new List<GameObject>();
        _loadOperations = new List<AsyncOperation>();

        InstanciateSystemPrefabs();
        
        LoadLevel("Main");
    }

    #region Load and Unload game levels

    void OnLoadOperationComplete(AsyncOperation ao)
    {
        if (_loadOperations.Contains(ao))
        {
            _loadOperations.Remove(ao);
            
            // dispatch message
            // transition between scenes
        }
        
        Debug.Log("Load Complete.");
    }

    void OnUnloadOperationComplete(AsyncOperation ao)
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

    void InstanciateSystemPrefabs()
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
}
