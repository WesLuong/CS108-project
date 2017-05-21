using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] enemies;
    public GameObject[] obstacles;
    public Vector3 spawnValuesForEnemies;
    public Vector3 spawnValuesForObstacles;

    public int enemyCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public int obstacleCount;
    public float spawnWait2;
    public float startWait2;
    public float waveWait2;

    private bool restart;
    private bool gameOver;

    public TextMesh scoreText;
    public TextMesh gameOverText;
    private int score;

    private float[] zValues = {-21, 21};
    void Start()
    {
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnObstacles());
    }

    void Update()
    {
        UpdateScore();
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene("Main");
                
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {

                GameObject enemy = enemies[Random.Range(0, enemies.Length)];

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValuesForEnemies.x, spawnValuesForEnemies.x), spawnValuesForEnemies.y, zValues[Random.Range(0, zValues.Length)]);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restart = true;
                break;
            }

        }
            
    }

    IEnumerator SpawnObstacles()
    {
        yield return new WaitForSeconds(startWait2);
        while (true)
        {
            for (int i = 0; i < obstacleCount; i++)
            {

                GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValuesForObstacles.x, spawnValuesForObstacles.x), spawnValuesForObstacles.y, spawnValuesForObstacles.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(obstacle, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait2);
            }
            yield return new WaitForSeconds(waveWait2);

            if (gameOver)
            {
                restart = true;
                break;
            }

        }

    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
