using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour {

	// Use this for initialization
	public void newGame () {
		SceneManager.LoadScene("ZendaGame");
	}

    public void loadGame(){
        SceneManager.LoadScene("LoadGame");
    }

    public void mainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void testing(){
        Debug.Log("works");
    }
	
	
}
