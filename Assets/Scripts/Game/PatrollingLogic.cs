using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingLogic : MonoBehaviour {


	public Vector3[] directions;
	public float movingSpeed;
	public int timeToChange;

	public int directionIndex;
	public float directionTimer;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		directionIndex =0;
		directionTimer = timeToChange;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		directionTimer -= Time.deltaTime;
		if(directionTimer<=0){
			directionTimer =timeToChange;
			directionIndex++;

			if(directionIndex >= directions.Length){
				directionIndex=0;
			}
		}

		rb.velocity = new Vector3 (
			directions[directionIndex].x * movingSpeed,
			rb.velocity.y,
			directions[directionIndex].z * movingSpeed

		);
		
	}
}
