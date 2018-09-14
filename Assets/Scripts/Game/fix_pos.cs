using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fix_pos : MonoBehaviour {

	public Transform parent_obj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = parent_obj.position;
	}
}
