using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loaderGame : MonoBehaviour {

    // Use thi  public GameObject[] partida;
    public SQLCommands bdein;
    public GameObject[] partidasBox;
	
    void Start()
    {
        /*
        foreach(GameObject obj in partidasBox){
            obj.SetActive(false);
        }


        int i = 0;
        //establecer conexión a la base de datos y preguntar por todas las partidas (3 max)
        foreach (DbPartidas db in bdein.dbPartidas)
        {
            partidasBox[i].SetActive(true);
            partidasBox[i].GetComponentInChildren<Text>().text = "hola";
            Debug.Log("HIII entre aqui!");
        }*/
    }
}

