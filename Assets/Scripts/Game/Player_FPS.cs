using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player_FPS : MonoBehaviour {


		[Header("Visuals")]
		public GameObject modelPlayer;

		[Header("Attributes")]	
		public int health = 5;
        public int exp=0;
        public string achievements;

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
        private bool gameFlag = false;
        private bool isGrounded = false;
        private GameObject sceneController;



		// Use this for initialization
		void Start () {
			canJump = true;
			lastSpawn = firstSpawn;
			rb = transform.GetComponent<Rigidbody> ();
			//playerModelRotation = modelPlayer.GetComponent<Transform> ().rotation;
			bow.gameObject.SetActive (false);
            sceneController = GameObject.FindWithTag("SceneController");
            


        }

		void Update(){
			
			RaycastHit hit;
			if(Physics.Raycast(transform.position,Vector3.down,out hit,1.01f)){
				if (hit.collider.tag == "floor") {
					this.canJump = true;
                    this.isGrounded = true;
				}
			}
			

			//modelPlayer.transform.rotation = Quaternion.Lerp (modelPlayer.transform.rotation, playerModelRotation, rotatingSpeed * Time.deltaTime);
			if(knockbackTimer>0f){
				knockbackTimer-=Time.deltaTime;
			} else{
				processInput ();
			}
			


		}
    /*
        public void loadData(DbPartidas dbp){

        string[] subStrings = dbp.playerState.Split(':');
        this.transform.position = dbp.obtainPos(subStrings[0]);
        this.exp = int.Parse(subStrings[1]);
        Debug.Log("Cargando EXP: " + subStrings[1]);
        this.health = int.Parse(subStrings[2]);
        this.arrowAmount = int.Parse(subStrings[3]);
        this.bombAmount = int.Parse(subStrings[4]);
        this.achievements = subStrings[5];
    }*/

		private void processInput(){
			

		rb.velocity = new Vector3 (0f,rb.velocity.y,0f);
        /*
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * (Vertical * speed);
        }
        if (Input.GetKey("s"))
        {
            rb.velocity = transform.forward * (Vertical * speed);
        }
        if (Input.GetKey("a"))
        {
            rb.velocity = transform.right * (Horizontal * speed);
        }
        if (Input.GetKey("d"))
        {
            rb.velocity = transform.right * (Horizontal * speed);
        }*/

        if(Input.GetKeyDown(KeyCode.Escape)){
            //llama un prepareSave del datamanagerplayer
            //GameObject.FindWithTag("SceneController")
            sceneController.GetComponent<dataManagerPlayer>().prepareSave();
            if (gameFlag)
            {
                sceneController.GetComponent<SceneController>().gameMenuOff();
                gameFlag = false;
            }
            else
            {
                sceneController.GetComponent<SceneController>().gameMenuOn();
                gameFlag = true;
            }
        }

			if (Input.GetKey (KeyCode.A)) {
            //rb.velocity = new Vector3 (-moveVelocity, rb.velocity.y, rb.velocity.z);
            //playerModelRotation = Quaternion.Euler (0f, 270f, 0f);
            rb.velocity += -transform.right * moveVelocity;
			}
			if (Input.GetKey (KeyCode.D)) {
            //rb.velocity = new Vector3 (moveVelocity, rb.velocity.y, rb.velocity.z);
            //playerModelRotation = Quaternion.Euler (0f, 90f, 0f);
            rb.velocity += transform.right * moveVelocity;
			}
			if (Input.GetKey (KeyCode.W)) {
            //rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, moveVelocity);
            //playerModelRotation = Quaternion.Euler (0f, 0f, 0f);
            rb.velocity += transform.forward * moveVelocity;
        }
			if (Input.GetKey (KeyCode.S)) {
            rb.velocity -= transform.forward * moveVelocity;
            //playerModelRotation = Quaternion.Euler (0f, 180f, 0f);
        }

        if(isGrounded){
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            Debug.Log("Is grounded");
            //Vector fixY = 
        }

			if (Input.GetKeyDown (KeyCode.Space) && canJump) {
            ///rb.velocity = new Vector3 (rb.velocity.x, jumpVelocity, rb.velocity.z);
                rb.velocity += transform.up * jumpVelocity;
				canJump = false;
                isGrounded = false;


			}


        //Checking for equipment interaction

        if (Input.GetKeyDown (KeyCode.E)) {
				sword.Attack ();
				sword.gameObject.SetActive (true);
				bow.gameObject.SetActive (false);
			}
			if (Input.GetKeyDown (KeyCode.R)) {
				throwBomb ();
                bow.gameObject.SetActive(false);
        }
			if (Input.GetKeyDown (KeyCode.Q)) {
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
            Debug.Log("Entre al trigger");

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
            Debug.Log("Entre al collider!!!");
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

//}

}
