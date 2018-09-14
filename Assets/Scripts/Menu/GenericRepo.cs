using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericRepo : MonoBehaviour {

    //public DbPartidas partida;
    public abstract void load();
    public abstract void save();
    
}
