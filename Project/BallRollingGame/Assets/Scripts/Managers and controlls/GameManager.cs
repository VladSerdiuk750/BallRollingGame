using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject ballPrefab;

    [SerializeField] private GameObject obstaclePrefab;

    [SerializeField] private GameObject fieldPrefab;

    [SerializeField] private Transform spawnPoint;

    [SerializeField] private SmoothFollow smoothFollowCamera;

    private bool _isPaused;
    public bool IsPaused => _isPaused;

    private PlayerController _playerController;

    [SerializeField] private HUDController hudController;

    private List<GameObject> fields;
    
    
    // Start is called before the first frame update
    void Start()
    {
        fields = new List<GameObject>();
        NewField();
        _isPaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        var player = Instantiate(ballPrefab);
        player.transform.position = spawnPoint.position;
        smoothFollowCamera.target = player.transform;
        _playerController = player.GetComponent<PlayerController>();
        _isPaused = false;
    }

    public void OnMoveRightButtonClick()
    {
        _playerController.MoveToSide(new Vector3(0, 0, -2));
    }

    public void OnMoveLeftButtonClick()
    {
        _playerController.MoveToSide(new Vector3(0, 0, 2));
    }

    public void AddScore(int score)
    {
        hudController.Score += score;
    }

    public void Restart()
    {
        for (int i = fields.Count - 1; i > 0; i--)
        {
            Destroy(fields[i]);
            fields.RemoveAt(i);
            hudController.Score = 0;
        }
        
        Destroy(_playerController.gameObject);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        _isPaused = true;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        _isPaused = false;
    }

    public void BonusReceive()
    {
        AddScore(50);
        _playerController.BonusReceived();
    }

    public void GameEnd()
    {
        Time.timeScale = 0;
        hudController.GameEndWindow();
    }

    public void NewField()
    {
        int numberOfFields = fields.Count;
        int xPosition = 12 + (numberOfFields * 25);
        var newField = Instantiate(fieldPrefab, new Vector3(xPosition, 0, 0), Quaternion.identity);
        var fieldController = newField.GetComponent<Field>();
        fields.Add(newField);
        fieldController.GenerateObstacle(numberOfFields);
        fieldController.GenerateBonus(numberOfFields);
    }
}
