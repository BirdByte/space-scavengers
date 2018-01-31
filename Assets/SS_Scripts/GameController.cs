/*
 * Handles enemies spawning.
 * Updates score.
 * Handles Game Over.
 */


using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text currencyText;
    //public Text restartText;
    public Text gameOverText;
    public GameObject restartButton;

    private bool gameOver;
    private bool restart;
    private int score;
    private int currency;

    void Start()
    {
        gameOver = false;
        restartButton.SetActive(false); //hide restart button
        gameOverText.text = "";
        currency = 0;
        score = 0;
        UpdateScore();
        UpdateCurrency();
        StartCoroutine(SpawnWaves());
    }

     IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        //spawn waves until game is over
        while (!gameOver)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
    
            if (gameOver)
            {
                restartButton.SetActive(true);
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void AddCurrency(int newCurrencyValue)
    {
        currency += newCurrencyValue;
        UpdateCurrency();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateCurrency()
    {
        currencyText.text = "" + currency;    
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Start");
    }
}