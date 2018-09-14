using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour {

	// Use this for initialization
	public float proyectileSpeed = 700f;
	public float proyectileDuration = 7f;
	public int dmg;

	protected void starting () {
		GetComponent<Rigidbody> ().velocity = transform.forward * proyectileSpeed;
		Destroy (gameObject, proyectileDuration);
	}
}
