using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovRB : MonoBehaviour {

		[Header("Visuals")]
		public GameObject modelPlayer;

		[Header("Attributes")]	
		public int health = 5;

		[Header("Movement")]
		public float moveVelocity;
		public float jumpVelocity;
		public float rotatingSpeed;
		public float throwingSpeed;
		public float knockbackForce;
		public float knockbackTime;
		public float upForce;
		private float knockbackTimer;


		
		[Header("Equipment")]
		public Sword sword;
		public Bow bow;
		public int arrowAmount = 15;
		public GameObject bombPrefab;
		public int bombAmount;

		[Header("Others")]
		private bool canJump;
		private Quaternion playerModelRotation;
		private Transform lastSpawn;
		public Transform firstSpawn;
		private Rigidbody rb;



		// Use this for initialization
		void Start () {
			canJump = true;
			lastSpawn = firstSpawn;
			rb = transform.GetComponent<Rigidbody> ();
			playerModelRotation = modelPlayer.GetComponent<Transform> ().rotation;
			bow.gameObject.SetActive (false);
		}

		void Update(){
			
			RaycastHit hit;
			if(Physics.Raycast(transform.position,Vector3.down,out hit,1.01f)){
				if (hit.collider.tag == "floor") {
					this.canJump = true;
				}
			}
			modelPlayer.transform.rotation = Quaternion.Lerp (modelPlayer.transform.rotation, playerModelRotation, rotatingSpeed * Time.deltaTime);
			if(knockbackTimer>0f){
				knockbackTimer-=Time.deltaTime;
			} else{
				processInput ();
			}
			


		}

		private void processInput(){

		rb.velocity = new Vector3 (0f,rb.velocity.y,0f);

			if (Input.GetKey (KeyCode.LeftArrow)) {
				rb.velocity = new Vector3 (-moveVelocity, rb.velocity.y, rb.velocity.z);
				playerModelRotation = Quaternion.Euler (0f, 270f, 0f);
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				rb.velocity = new Vector3 (moveVelocity, rb.velocity.y, rb.velocity.z);
				playerModelRotation = Quaternion.Euler (0f, 90f, 0f);
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, moveVelocity);
				playerModelRotation = Quaternion.Euler (0f, 0f, 0f);
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, -moveVelocity);
				playerModelRotation = Quaternion.Euler (0f, 180f, 0f);
			}

			if (Input.GetKeyDown (KeyCode.Space) && canJump) {
				rb.velocity = new Vector3 (rb.velocity.x, jumpVelocity, rb.velocity.z);
				canJump = false;


			}


			//Checking for equipment interaction

			if (Input.GetKeyDown (KeyCode.X)) {
				sword.Attack ();
				sword.gameObject.SetActive (true);
				bow.gameObject.SetActive (false);
			}
			if (Input.GetKeyDown (KeyCode.Z)) {
				throwBomb ();
			}
			if (Input.GetKeyDown (KeyCode.C)) {
				if (arrowAmount <= 0) {
					return;
				}
				bow.Attack ();
				bow.gameObject.SetActive (true);
				sword.gameObject.SetActive (false);
				arrowAmount--;
			}
		}
		
		private void throwBomb(){
		if (bombAmount <= 0) {
			return;
		}
			var b = Instantiate (bombPrefab);
			b.transform.position = transform.position + modelPlayer.transform.forward; //* throwingSpeed;
			Vector3 throwingDir = (modelPlayer.transform.forward + Vector3.up).normalized;
			b.GetComponent<Rigidbody> ().AddForce (throwingDir * throwingSpeed);
			bombAmount--;
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

		

	public void OnTriggerEnter(Collider col){
		if (col.tag == "EnemyProyectile") {
			int dmg = col.GetComponent<Proyectile>().dmg;
			Vector3 knockback = (transform.position - col.transform.position).normalized;
			Vector3 knockbackDir = (knockback + Vector3.up*upForce).normalized;
			rb.velocity = new Vector3 (0f,0f,0f);

			Hit (dmg,knockbackDir);
			Destroy(col.gameObject);
		}
	}

	public void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Enemy") {
			int dmg = col.gameObject.GetComponent<Enemy>().dmg;
			Vector3 knockback = (transform.position - col.transform.position).normalized;
			Vector3 knockbackDir = (knockback + Vector3.up*upForce).normalized;
			rb.velocity = new Vector3 (0f,0f,0f);

			Hit (dmg,knockbackDir);
		}
	}

	public void Hit(int dmg, Vector3 knockbackDir){

		
		this.rb.AddForce(knockbackDir * knockbackForce);
		knockbackTimer = knockbackTime;
		Debug.Log("OMG");
		health-=dmg;
		if (health <= 0) {
			Destroy (gameObject);
		}
	}

}
