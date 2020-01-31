using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public Button restartButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameOver;
    public GameObject titleScreen;

    public bool isGameActive;
    private int score;
    private float SpawnRate = 1.0f;




 
    void Start()
    {
          

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(SpawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

            UpdateScore(0);
        }
    }



    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void Game_Over()
    {
        restartButton.gameObject.SetActive(true);
        GameOver.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void restartGame()
    {       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        SpawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
    }


}