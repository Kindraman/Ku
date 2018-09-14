using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	protected int health;
	public int dmg;
	//public GameObject enemyWeakPoint;
	public virtual void Hit(){}

	public void OnTriggerEnter(Collider col){
		if (col.tag == "Sword") {
			if(col.GetComponent<Sword>() != null && col.GetComponent<Sword>().IsAttacking){
				Hit ();
			}
			
		} else if (col.tag == "Arrow") {
			Hit ();
			Destroy (col.gameObject);
		}

	}
}
