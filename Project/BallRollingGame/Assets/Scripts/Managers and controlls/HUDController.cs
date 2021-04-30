using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    
    [SerializeField] private GameObject moveRightButton;

    [SerializeField] private GameObject moveLeftButton;
        
    [SerializeField] private Text pauseButtonText;

    [SerializeField] private GameObject pauseButton;

    [SerializeField] private GameObject menuButton;

    [SerializeField] private GameObject menuWindow;

    [SerializeField] private GameObject continueButton;

    [SerializeField] private Text scoreLabel;

    private int _score;

    public int Score
    {
        get => _score;
        set => _score = value;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        moveLeftButton.SetActive(false);
        moveRightButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = _score.ToString();
    }
    
    public void OnStartButtonClick()
    {
        GameManager.Instance.StartGame();
        pauseButtonText.text = "Pause";
        moveLeftButton.SetActive(true);
        moveRightButton.SetActive(true);
        startButton.SetActive(false);
    }
    
    public void OnMenuButtonClick()
    {
        GameManager.Instance.Pause();
        moveRightButton.SetActive(false);
        moveLeftButton.SetActive(false);
        pauseButton.SetActive(false);
        menuButton.SetActive(false);
        menuWindow.SetActive(true);
    }

    public void OnPauseButtonClick()
    {
        if (!GameManager.Instance.IsPaused)
        {
            GameManager.Instance.Pause();
            pauseButtonText.text = "Unpause";
            moveRightButton.SetActive(false);
            moveLeftButton.SetActive(false);
        }
        else
        {
            pauseButtonText.text = "Pause";
            moveRightButton.SetActive(true);
            moveLeftButton.SetActive(true);
            GameManager.Instance.UnPause();
        }
    }

    public void OnContinueButtonClick()
    {
        moveRightButton.SetActive(true);
        moveLeftButton.SetActive(true);
        pauseButton.SetActive(true);
        menuButton.SetActive(true);
        menuWindow.SetActive(false);
        pauseButtonText.text = "Pause";
        GameManager.Instance.UnPause();
    }

    public void OnRestartButtonClick()
    {
        moveRightButton.SetActive(true);
        moveLeftButton.SetActive(true);
        pauseButton.SetActive(true);
        menuButton.SetActive(true);
        startButton.SetActive(true);
        continueButton.SetActive(true);
        menuWindow.SetActive(false);
        pauseButtonText.text = "Pause";    
        GameManager.Instance.Restart();
        GameManager.Instance.UnPause();
    }

    public void GameEndWindow()
    {
        moveRightButton.SetActive(false);
        moveLeftButton.SetActive(false);
        pauseButton.SetActive(false);
        menuButton.SetActive(false);
        menuWindow.SetActive(true);
        continueButton.SetActive(false);
    }
}
