using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pepeplayer : MonoBehaviour {

	public PlayerMovRB parent_obj;

	public void respawn(){
		//parent_obj.respawn ();
		//avisar al gc que corrija la camara
		transform.position = parent_obj.respawn ();
	}
	public void renewSpawn(Vector3 pos){
		parent_obj.renewSpawn (pos);
	}
	public void endlvl(){
		//hacer algo xD
	}

	void OnCollisionEnter(Collision hit)
	{
		if (hit.collider.tag == "floor") {
			parent_obj.jumpAble ();
		}else if (hit.collider.tag == "endZone") {
			endlvl ();
			Debug.Log ("Lvl finalizado");
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "deadZone") {
			respawn ();
		} else if (other.tag == "checkPoint") {
			renewSpawn (other.transform.position);
			Debug.Log ("Entrando al new check");
		} 
	}
}
