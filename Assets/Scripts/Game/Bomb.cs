using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	// Use this for initialization

	public float duration;
	public float radius;
	public float explosionDuration;
	public GameObject explosionModel;


	private float explosionTimer;
	private bool exploded;

	void Start () {
		explosionTimer = duration;
		explosionModel.SetActive(false);
		explosionModel.transform.localScale = Vector3.one * radius;
		exploded = false;
	}
	
	// Update is called once per frame
	void Update () {
		explosionTimer -= Time.deltaTime;
		if (explosionTimer <= 0f && !exploded) {
			exploded = true;
			Collider[] colliders =Physics.OverlapSphere (transform.position, radius);

			foreach (Collider c in colliders) {
				Debug.Log ("Ha chocado el tio con " + c.name+"\n");
				if (((c.tag == "Enemy") || (c.tag == "enemyWeakPoint")) && c.GetComponent<Enemy>() != null) {
					c.GetComponent<Enemy> ().Hit ();
				}
			}
			StartCoroutine (doExplosion ());
		}
	}


	private IEnumerator doExplosion(){
		explosionModel.SetActive(true);
		yield return new WaitForSeconds (explosionDuration);
		explosionModel.SetActive(false);
		Destroy (this.gameObject);
	}

}
