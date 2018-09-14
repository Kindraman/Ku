using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy {


	// Use this for initialization
	void Start () {
		this.health = 3;
		this.dmg = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Hit ()
	{
		base.Hit ();
		this.health--;
		Debug.Log ("Auch!");
		if (health <= 0) {
            Player_FPS player = GameObject.FindWithTag("Player").GetComponent<Player_FPS>();
            player.exp += 100;
			Destroy (gameObject);
		}
	}

}
