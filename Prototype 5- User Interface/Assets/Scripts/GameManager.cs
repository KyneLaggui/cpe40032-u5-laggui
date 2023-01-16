using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;//List of targets
    //For the Texts
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;//For the button of the restart
    public GameObject titleScreen;//The whole title screen
    public bool isGameActive;//Boolean expression to distuingish if the game is running
    private int score;//The score of the game
    private float spawnRate = 1.0f;//How fast it will spawn
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)//If the game is still running it will continue to do the line of code below
        {
            yield return new WaitForSeconds(spawnRate);//Timer of the obstacles in spawning
            int index = Random.Range(0, targets.Count);//Randomize the obstacles starting from zero and the length of the targets
            Instantiate(targets[index]);//Spawn the targets with random index
            
        }
        
    }
    public void UpdateScore(int scoreToAdd)//To update score every time you click the objects
    {
       score += scoreToAdd;//To get the points depending on the point value and then add it
       scoreText.text = "Score: " + score;//To display the scores 
    }
    public void GameOver()//When the game is over the lines of code below will run
    {
        gameOverText.gameObject.SetActive(true);//It will display the game over
        restartButton.gameObject.SetActive(true);//It will display the restart button
        isGameActive = false;//It will not spawn objects and the while loop will not run
    }
    public void RestartGame()
    {
        //It will reload the active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        isGameActive = true;//The while loop will run
        score = 0;//Scores will start at zero
        spawnRate /= difficulty;//Divide the spawn rate depending on the difficulty that the user wants
        StartCoroutine(SpawnTarget());//To start the Ienumerator to spawn targets
        UpdateScore(0);//Begin the scores and the parameter with zero
        titleScreen.gameObject.SetActive(false);//The title screen will disappear or be hidden
    }
}
