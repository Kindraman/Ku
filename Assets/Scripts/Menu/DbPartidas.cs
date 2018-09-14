using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DbPartidas : MonoBehaviour {

    // Use this for initialization
    public GameObject loadedData;

    public int id;
    public string nombrePartida;
    public string playerState; //statePlayer= pos:exp:vidas:flechas:bombas:logros
    //-> 0f,0f,0f:120:3:10:4:ninguno -> 6 campiños
    public  string fecha;

    public bool ready;

    //Vector3 position;

    public Vector3 position;
    public int exp;
    public int health;
    public int nArrows;
    public int nBombs;
    public string achievements;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void construct(int id, string nombrePartida, string playerState, string fecha)
    {
        this.id = id;
        this.nombrePartida = nombrePartida;
        this.playerState = playerState;
        this.fecha = fecha;

       
        // parsePlayerState();




    }

    public void parsePlayerState(){
        //string myString = "12,Apple,20";
        Debug.Log(playerState);


       

    }

    public Vector3 obtainPos(string pos_str){
        string[] subStrings = pos_str.Split(',');
        return new Vector3(float.Parse(subStrings[0]),float.Parse(subStrings[1]),float.Parse(subStrings[2]));
    }
    public void debug(string datitos){

        Debug.Log(/*"Mi id es: " + this.id +*/ "\n" +
                  "Mi nombre partida es: " + this.nombrePartida + "\n" +
                  "Mi player state es: " + this.playerState + "\n" +
                  "Mi fecha es: " + this.fecha +"\n"+
                  "y mis datos extraidos son"+datitos);

    }

    public string infoPartida(){
        return /*this.id + "-" */ this.nombrePartida + "-" + this.fecha;
    }

    public void saveData(){
        DbPartidas dbp = loadedData.GetComponent<DbPartidas>();
        //dbp.id = this.id;
        dbp.nombrePartida = "PartidaY";//this.nombrePartida;
        dbp.playerState = this.playerState;
        dbp.fecha = this.fecha;
        //parsePlayerState();
    }




	
	//sabe leer sus datos...

}
