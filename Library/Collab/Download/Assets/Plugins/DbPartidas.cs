using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DbPartidas : MonoBehaviour {

    // Use this for initialization
    int id;
    string nombrePartida;
    string playerState;
    string fecha;

    //Vector3 position;
    string position;
    int exp;
    int lifes;
    int nArrows;
    int nBombs;
    string achievements;

    public DbPartidas(int id, string nombrePartida, string playerState, string fecha){
        this.id = id;
        this.nombrePartida = nombrePartida;
        this.playerState = playerState;
        this.fecha = fecha;

        parsePlayerState();



    }

    private void parsePlayerState(){
        //string myString = "12,Apple,20";
        Debug.Log(playerState);
        string[] subStrings = playerState.Split(':');
        /*
        this.position = subStrings[0];
        this.exp = int.Parse(subStrings[1]); 
        this.lifes = int.Parse(subStrings[2]);
        this.nArrows = int.Parse(subStrings[3]);
        this.nBombs = int.Parse(subStrings[4]);
        this.achievements = subStrings[5];*/
    }


	
	//sabe leer sus datos...

}
