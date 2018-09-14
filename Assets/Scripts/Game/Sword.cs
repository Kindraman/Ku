using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {


	public float swingingSpeed;
	public float cooldownSpeed;
	public float cooldownDuration;
	public float attackDuration;

	private float cooldownTimer;
	private Quaternion targetRotation;
	private Quaternion initialRotation;

	private bool isAttacking;

	public bool IsAttacking {
		get{
			return isAttacking;
		}
	}


	// Use this for initialization
	void Start () {
		isAttacking = false;
		initialRotation = this.transform.localRotation;//Quaternion.Euler(0f,0f,0f); //igual a rotacion inicial ...
		


		//attackDuration = 0.4f; //twitch later
		//cooldownDuration =as 5f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localRotation = Quaternion.Lerp (transform.localRotation, targetRotation, (isAttacking ? swingingSpeed : cooldownSpeed) * Time.deltaTime);
		cooldownTimer -= Time.deltaTime;
		Debug.Log("initialRotation: "+initialRotation+"\ntargetRotation: "+targetRotation);
	}


	public void Attack(){
		if (cooldownTimer > 0f) {
			return;		
		}
		isAttacking = true;
		targetRotation = Quaternion.Euler (75f,-20f,0f);
		cooldownTimer = cooldownDuration;
		StartCoroutine (CooldownAttack());
	}

	//Espera el tiempo de ataque y luego devuelve la espadita xD
	private IEnumerator CooldownAttack(){
		yield return new WaitForSeconds (attackDuration);
		isAttacking = false;
		targetRotation = initialRotation;//Quaternion.Euler (0f, 0f, 0f);
	}
}
