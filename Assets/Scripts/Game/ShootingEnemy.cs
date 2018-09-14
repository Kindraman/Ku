using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy {

	// Use this for initialization

	//Este enemigo tiene una pequeña inclinación hacia adelante cuando se mueve (smooth)
	//Sigue al player y cuando está a R distancia de el se detiene, le apunta ( dirección en ese instante) y se demora t segundos en hacer el disparo (charging shoot)
	//luego espera t2 segundos y vuelve a empezar el ciclo de ataque(sigue al player)

	public Transform[] cannonPos;
	public GameObject bulletPrefab;
	public GameObject model;
	public float timeToShoot=3f;
	private float shootTimer;
    public Player_FPS player;


    void Start () {
		shootTimer=timeToShoot;
		dmg = 1;
        player = GameObject.FindWithTag("Player").GetComponent<Player_FPS>();
        Debug.Log("PlayerBombs: " + player.bombAmount);

    }
	
	// Update is called once per frame
	void Update () {
		shootTimer-= Time.deltaTime;
		if(shootTimer<=0f){
			shootTimer = timeToShoot;
				var bullet =Instantiate(bulletPrefab);
				bullet.transform.position = cannonPos[1].position + model.transform.forward;
				bullet.transform.forward = model.transform.forward;
			
		}
	}
	public override void Hit ()
	{

        base.Hit ();
		this.health--;
		Debug.Log ("Dush!");
		if (health <= 0) {

            player.exp += 100;
            Debug.Log("Playerexp: "+player.exp);
            Destroy (gameObject);
		}
	}
}
