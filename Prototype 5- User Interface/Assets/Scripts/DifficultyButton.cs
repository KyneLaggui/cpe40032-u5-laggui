using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;//The button for the difficulty
    private GameManager gameManager;//Access the script of the game manager
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        //Get and access the components 
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //If the button is clicked the function inside of it will run
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");//To display on the console what diffulty the user will play
        gameManager.StartGame(difficulty);//Start the game depending on what the user wants to play
    }
}
