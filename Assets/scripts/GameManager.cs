using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] int timeToEnd;
    private int defaultTimeToEnd = 100;
    private bool gamePaused = false;
    [SerializeField] int points = 0;
    bool endGame = false;
    bool win = false;

    [SerializeField] int redkeys = 0;
    [SerializeField] int greenkeys = 0;
    [SerializeField] int goldkeys = 0;

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }

        if (timeToEnd <= 0)
        {
            timeToEnd = defaultTimeToEnd;
        }

        InvokeRepeating("TimerTick", 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck();
    }

    void TimerTick()
    {
        timeToEnd--;
        Debug.Log("Time" + timeToEnd + " s");

        if (timeToEnd <= 0)
        {
            EndGame();
        }
    }

    void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0;
        gamePaused = true;
    }

    void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1;
        gamePaused = false;
    }

    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void EndGame()
    {
        CancelInvoke("TimerTick");
        if (win)
        {
            Debug.Log("You win!!! Reload?");
        }
        else
        {
            Debug.Log("You lose!!! Reload?");
        }
    }

    public void AddPoints(int points)
    {
        Debug.Log("dodaje"+points);
        
        this.points += points;
        Debug.Log(this.points);
    }

    public void AddTime(int timeToAdd)
    {
        timeToEnd += timeToAdd;
    }

    public void FreezeTime(float freezeTime)
    {
        CancelInvoke("TimerTick");
        InvokeRepeating("TimerTick", freezeTime, 1);
    }

    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.Gold)
        {
            goldkeys++;
        }
        else if (color == KeyColor.Red)
        {
            redkeys++;
        }
        else if (color == KeyColor.Green)
        {
            greenkeys++;
        }
    }
}
