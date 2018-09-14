using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dataManagerPartidaUI : dataManager {

    public GenericRepo repo; //aqui ocupa el generico!!!
    public GameObject[] partidasBox;

    void Start () {
       // setUp();
        repo.load();
    }

    public override void loadHelper()
    {
        //establecer conexión a la base de datos y preguntar por todas las partidas (3 max)
        for (int i = 0; i < 3; i++)
        {


            if (partidasBox[i].GetComponent<DbPartidas>().ready)
            {
                partidasBox[i].gameObject.SetActive(true);
                //Debug.Log(partidasBox.ToString());
                Debug.Log("Active Self: " + partidasBox[i].activeSelf);
                Debug.Log("Active in Hierarchy" + partidasBox[i].activeInHierarchy);
                partidasBox[i].GetComponentInChildren<Text>().text = partidasBox[i].GetComponent<DbPartidas>().infoPartida();
                Debug.Log("HIII entre aqui!");
            }
        }
    }

    public override void saveHelper()
    {
        throw new System.NotImplementedException();
    }


}
