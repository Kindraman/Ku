using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SceneController : MonoBehaviour {


	[Header("Game")]
    public Player_FPS player;
    public GameObject gameMenu;
    public GameObject gameOver;

    [Header("UI")]
	public GameObject[] hearts;
	public Text arrowText;
	public Text bombText;
    public Text expText;

  

	// Use this for initialization
	void Start () {
        //gameMenu.SetActive(false);
       
          


        /* if (!player)
         {
             player = GameObject.FindWithTag("Player").GetComponent<Player_FPS>();
             if (GameObject.FindGameObjectWithTag("loadedData").GetComponent<DbPartidas>())
             { //si encuentra el objetop
               //Debug.Log("He podido encontrar la data guardada: " + data.nombrePartida);
               // player
                 player.loadData(GameObject.FindGameObjectWithTag("loadedData").GetComponent<DbPartidas>());

             }
         }
         else
         {
             if (GameObject.FindGameObjectWithTag("loadedData").GetComponent<DbPartidas>())
             { //si encuentra el objetop
               //Debug.Log("He podido encontrar la data guardada: " + data.nombrePartida);
               // player
                 player.loadData(GameObject.FindGameObjectWithTag("loadedData").GetComponent<DbPartidas>());

             }
         }*/





    }
	
	// Update is called once per frame
	void Update () {

		if(player != null){
			
			for(int i=0;i<hearts.Length;i++){
				hearts[i].SetActive(i<player.health);
			}

			arrowText.text = "Arrows: "+player.arrowAmount;
			bombText.text = "Bombs: "+player.bombAmount;
            expText.text = "EXP: " + player.exp;
		} else {
			for(int i=0;i<hearts.Length;i++){
				hearts[i].SetActive(false);
			}
		}
        if(player.health <= 0){
            gameOverOn();
        }
		
		
	}

    public void gameMenuOn(){
        gameMenu.SetActive(true);
    }

    public void gameMenuOff()
    {
        gameMenu.SetActive(false);
    }

    public void gameOverOn(){
        gameOver.SetActive(true);
    }
}
