using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class dataManager : MonoBehaviour
{
    protected DbPartidas dbp;

    public void setUp(){
        if (GameObject.FindGameObjectWithTag("loadedData"))
        { //esto va para el script padre loaderData
            dbp = GameObject.FindGameObjectWithTag("loadedData").GetComponent<DbPartidas>();
           // player.loadData(dbp); //no es el player el que carga sus datos si no el "loaderDataPlayer":loaderData
        }
    }

    public abstract void saveHelper();
    public abstract void loadHelper();
}
