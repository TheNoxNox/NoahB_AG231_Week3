using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ChaseGameManager : MonoBehaviour
{
    public static ChaseGameManager main;

    [SerializeField]
    public GameObject _player;

    public TMP_Text remaining;

    public TMP_Text timerDisplay;

    public GameObject gameOverScreen;

    public GameObject gameWinScreen;

    public GameObject activeScreen;

    public FixedJoystick movementJoystick;
    public FixedJoystick boostJoystick;

    public int numberOfEnemies = 5;

    protected float timer = 30f;

    public bool gameOn = false;

    public Vector3 PlayerPosition { get { return _player.transform.position; } }

    public GameObject ChaseGamePrefab;

    private GameObject ChaseGameRef;

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
        activeScreen.SetActive(false);
    }

    void GameWin()
    {
        gameOn = false;
        gameWinScreen.SetActive(true);
        activeScreen.SetActive(false);
    }

    public void NewGame()
    {
        Destroy(ChaseGameRef);
        gameWinScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        activeScreen.SetActive(false);
        timer = 30f;
        numberOfEnemies = 5;
        gameOn = false;
    }

    public void InstantiateGame(Transform contentPos)
    {
        ChaseGameRef = Instantiate(ChaseGamePrefab, contentPos);
        activeScreen.SetActive(true);
        gameOn = true;
    }
}
