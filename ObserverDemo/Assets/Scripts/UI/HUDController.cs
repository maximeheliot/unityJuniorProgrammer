using System;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour, IEndGameObserver
{
	#region Field Declarations

	[Header("UI Components")]
    [Space]
	public Text scoreText;
    public StatusText statusText;
    public Button restartButton;

    [Header("Ship Counter")]
    [SerializeField]
    [Space]
    private Image[] shipImages;

    private GameSceneController _gameSceneController;
    
    #endregion

    #region Startup
    
    private void Awake()
    {
        statusText.gameObject.SetActive(false);
    }

    private void Start()
    {
        _gameSceneController = FindObjectOfType<GameSceneController>();
        
        _gameSceneController.AddObserver(this);
        
        _gameSceneController.ScoreUpdatedOnKill += GameSceneControllerOnScoreUpdatedOnKill;
        _gameSceneController.LifeLost += HideShip;
    }

    private void GameSceneControllerOnScoreUpdatedOnKill(int pointvalue)
    {
        UpdateScore(pointvalue);
    }

    #endregion

    #region Public methods

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString("D5");
    }

    public void ShowStatus(string newStatus)
    {
        statusText.gameObject.SetActive(true);
        StartCoroutine(statusText.ChangeStatus(newStatus));
    }

    public void HideShip(int imageIndex)
    {
        shipImages[imageIndex].gameObject.SetActive(false);
    }

    public void ResetShips()
    {
        foreach (Image ship in shipImages)
            ship.gameObject.SetActive(true);
    }

    public void Notify()
    {
        ShowStatus("Game Over");
    }

    #endregion
}
