using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ChaseGameManager : MonoBehaviour
{
    public static ChaseGameManager main;

    [SerializeField]
    protected GameObject _player;

    public TMP_Text remaining;

    public TMP_Text timerDisplay;

    public GameObject gameOverScreen;

    public GameObject gameWinScreen;

    public int numberOfEnemies = 5;

    protected float timer = 30f;

    public bool gameOn = true;

    public Vector3 PlayerPosition { get { return _player.transform.position; } }

    private void Awake()
    {
        if (!main)
        {
            main = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    private void Update()
    {
        if (gameOn)
        {
            timer -= Time.deltaTime;

            TimeSpan tSpan = TimeSpan.FromSeconds(timer);

            timerDisplay.text = tSpan.ToString(@"ss\:ff");

            remaining.text = "Remaining: " + numberOfEnemies;

            if (timer <= 0f)
            {
                GameOver();
            }
            else if (numberOfEnemies <= 0)
            {
                GameWin();
            }
        }
        
    }

    void GameOver()
    {
        gameOn = false;
        gameOverScreen.SetActive(true);
    }

    void GameWin()
    {
        gameOn = false;
        gameWinScreen.SetActive(true);
    }

    public void NewGame()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("TI_Scene2");
    }
}
