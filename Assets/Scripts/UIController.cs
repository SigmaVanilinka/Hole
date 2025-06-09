using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private float gameDuration;
    [SerializeField] private float timeLeft;
    [SerializeField] private GameObject menuLose;
    [SerializeField] private GameObject menuWin;
    [SerializeField] private Transform level;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private TextMeshProUGUI timer;
    private float playerRecordScore;
    public bool IsPaused;

    private void OnEnable()
    {
        if(PlayerPrefs.HasKey("RecordScore"))
        {
            playerRecordScore = PlayerPrefs.GetFloat("RecordScore");
        }
    }
    private void Start()
    {
        timeLeft = gameDuration;
        menuLose.SetActive(false);
        menuWin.SetActive(false);
        timer.text = System.Convert.ToInt32(gameDuration/60) + ":" + gameDuration%60;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameIsPaused();
        }
    }

    private void FixedUpdate()
    {
       if (IsPaused) return;
        timeLeft -= Time.fixedDeltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeLeft);
        timer.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        if (timeLeft <= 0)
        {
            LoseGame();
        }
    }

    public void WinGame()
    {
        IsPaused = true;
        var playerMaxScore = player.GetComponent<Hole>().MaxFoodScore; // MAX SCORE
        menuWin.SetActive(true);
        menuWin.transform.GetChild(0).GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "SCORE • " + Mathf.Floor(playerMaxScore);
        if (playerMaxScore > playerRecordScore)
        {
            PlayerPrefs.SetFloat("RecordScore", (float)playerMaxScore);
            PlayerPrefs.Save();
            playerRecordScore = PlayerPrefs.GetFloat("RecordScore");
            menuWin.transform.GetChild(0).GetChild(4).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "RECORD • " + Mathf.Floor(playerRecordScore);
        }
    }

    public void LoseGame()
    {
        // Implement lose game logic here
        Debug.Log("You lose!");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        menuLose.SetActive(false);
        menuWin.SetActive(false);
    }

    public void IsGameOver()
    {
        if (level.childCount == 0)
        {
            Debug.Log("Huray");
            WinGame();
        }
    }

    public void GameIsPaused()
    {
        PauseMenu.SetActive(true);
        IsPaused = true;
    } 

    public void GameIsntPaused()
    {
        PauseMenu.SetActive(false);
        IsPaused = false;
    }
}
