using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour {

	// Use this for initialization
	public void newGame () {
		SceneManager.LoadScene("Terrainy");
	}

    public void loadGame(){
        SceneManager.LoadScene("Loading");
    }

    public void loadGameFromGame(){
        //cerrarDb_ins();
        SceneManager.LoadScene("Loading");
    }

    public void mainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void testing(){
        Debug.Log("works");
    }

    public void exitGame(){
        Application.Quit();
    }
	
	
}
