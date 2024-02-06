using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GameMode : MonoBehaviour
{
    // Start is called before the first frame update
    int score = 0;
    int life;
    int maxLife = 3;

    public GameObject HUD;
    void Start()
    {
        Time.timeScale = 1;
        score = 0;
        life = maxLife;
        HUD.gameObject.GetComponent<S_HUD>().setLife(life);
        HUD.gameObject.GetComponent<S_HUD>().gameMode = gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void incrementScore()
    {
        score++;
        HUD.GetComponent<S_HUD>().setScore(score);
    }
    public void decrementLife()
    {
        life--;
        HUD.GetComponent<S_HUD>().setLife(life);

        //Game Over
        if (life <= 0)
        {
            gameOver();
        }
    }

    public void gameOver()
    {
        HUD.GetComponent<S_HUD>().gameOver();
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }
}
