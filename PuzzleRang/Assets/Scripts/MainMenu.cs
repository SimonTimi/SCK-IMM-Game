using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    private Button button;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(Clicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Clicked(){
        Debug.Log(button.gameObject.name + " was clicked");

        if (button.gameObject.name == "Play"){
            gameManager.StartGame();
        }

        else if (button.gameObject.name == "Settings"){
            gameManager.Settings();
        }

        else if (button.gameObject.name == "Exit"){
            gameManager.Exit();
        }

        else if (button.gameObject.name == "Back"){
            gameManager.Back();
        }
    }   
}
