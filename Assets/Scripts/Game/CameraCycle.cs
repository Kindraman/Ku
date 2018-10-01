using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCycle : MonoBehaviour {

	//Hice un cambito.
	public Camera[] cameraArr;
	private int index;
	// Use this for initialization
	void Start () {
		this.index = 0;
		usingCamera (this.index);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (this.index > 2) {
			this.index = 0;
		}
		if (Input.GetKeyDown (KeyCode.Return) && this.index <=2) {
			usingCamera (this.index++);
		}


		
	}

	private void usingCamera(int index){
		for (int i = 0; i < cameraArr.Length; i++) {
			cameraArr [i].gameObject.SetActive (i == index);
		}
	
	}
}
