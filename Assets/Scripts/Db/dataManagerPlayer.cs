using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataManagerPlayer : dataManager {

    // Use this for initialization
    private Player_FPS player;
	void Start () {
        setUp();
        //loadData();
        player = GameObject.FindWithTag("Player").GetComponent<Player_FPS>();
        if(player){
            loadHelper();
        }
	}


    public override void loadHelper()//Carga los datos de la partida en player.
    {
        string[] subStrings = dbp.playerState.Split(':');
        player.transform.position = dbp.obtainPos(subStrings[0]);
        player.exp = int.Parse(subStrings[1]);
        player.health = int.Parse(subStrings[2]);
        player.bombAmount = int.Parse(subStrings[4]);
        player.arrowAmount = int.Parse(subStrings[3]);
        player.achievements = subStrings[5];


        //player.loadData(dbp); //no es el player el que carga sus datos si no el "loaderDataPlayer":loaderData
    }

    public override void saveHelper()
    {
        string state = player.transform.position.x + "," + player.transform.position.y + "," + player.transform.position.z + ":"
                           + player.exp + ":" + player.health + ":" + player.arrowAmount + ":" + player.bombAmount + ":" + "ninguno";
        dbp.playerState = state;
        dbp.nombrePartida = "Partida nº" + dbp.id;
        dbp.fecha = "10/09/2018";

        dbp.exp = player.exp;
        dbp.health = player.health;
        dbp.nArrows = player.arrowAmount;
        dbp.nBombs = player.bombAmount;
        dbp.achievements = player.achievements;
    }

    public void prepareSave(){
        if (!GameObject.FindWithTag("loadedData")) //si no hay partida cargada... se crea una "memoria"
        {
            GameObject obj = new GameObject();
            obj.tag = "loadedData";
            dbp = obj.AddComponent<DbPartidas>();

        }
        else
        {
            dbp = GameObject.FindWithTag("loadedData").GetComponent<DbPartidas>(); //si la hay se carga
        }

        saveHelper();
        // dbp.id = 1;


       
    }

}
