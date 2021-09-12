using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject endScreen;
    private SpawnManager spawnManager;
    private PlayerController playerController;
    public Button restartButton;
    [SerializeField] TextMeshProUGUI scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        restartButton.onClick.AddListener(Restart);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        endScreen.gameObject.SetActive(true);
        spawnManager.SpawnOff();
        playerController.stopMovement();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void addScore(int points)
    {
        score += points;
        Debug.Log(points);
        scoreText.SetText("Score: " + score);
    }
}
