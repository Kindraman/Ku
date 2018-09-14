using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemy : Enemy {

	// Use this for initialization
	void Start () {
		health = 10;
		dmg = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Hit ()
	{
		base.Hit ();
		this.health--;
		Debug.Log ("Ouch!");
		if (health <= 0) {
			Destroy (gameObject);
		}
	}
}
