using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class S_HUD : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;

    public TextMeshProUGUI gameOverScoreText;

    public GameObject gameOverCanva;

    public GameObject gameMode;
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanva.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void setLife(int life)
    {
        lifeText.text = life.ToString();
    }

    public void gameOver()
    {
        gameOverCanva.SetActive(true);
        gameOverScoreText.text = scoreText.text;
        gameMode.GetComponent<S_GameMode>().pauseGame();
    }

    public void restartGame()
    {
        SceneManager.LoadScene("level1");
    }

    public void quitGame()
    {
        //Nothing
    }
}
