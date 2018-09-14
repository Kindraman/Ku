using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

	public GameObject arrowPrefab;
    //public Transform arrowPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Attack(){
        var a = Instantiate (arrowPrefab);
		a.transform.position = transform.position + transform.forward;
		a.transform.rotation = transform.rotation;

	}
}
