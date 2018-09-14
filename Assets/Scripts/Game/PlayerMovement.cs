using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float rotatingSpeed;
	public float moveSpeed;
	public float jumpForce;
	private bool canJump;
	private Transform lastSpawn;
	public Transform firstSpawn;

	public Transform obj;
	// Use this for initialization
	void Start () {
		canJump = true;
		lastSpawn = firstSpawn;
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space) && canJump) {
			obj.transform.GetComponent<Rigidbody> ().AddForce (Vector3.up * moveSpeed * jumpForce);
			canJump = false;

		}
		processInput ();


	}

	private void processInput(){

		
		if (Input.GetKey (KeyCode.LeftArrow))
			this.transform.RotateAround (transform.position, Vector3.up, -rotatingSpeed * Time.deltaTime);
		if (Input.GetKey (KeyCode.RightArrow))
			this.transform.RotateAround (transform.position, Vector3.up, rotatingSpeed * Time.deltaTime);
		if (Input.GetKey (KeyCode.UpArrow))
			this.transform.position += transform.forward* moveSpeed * Time.deltaTime;
		if (Input.GetKey(KeyCode.DownArrow))
			this.transform.position += transform.forward * -moveSpeed * Time.deltaTime;
	}

	public Vector3 respawn(){
		transform.position = lastSpawn.position;
		return lastSpawn.position;
	}
	public void jumpAble(){
		canJump = true;
	}

	public void renewSpawn(Vector3 newSpawn){
		lastSpawn.position = newSpawn;
	}

		
}


