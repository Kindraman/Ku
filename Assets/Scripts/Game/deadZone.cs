using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadZone : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag =="Player")
		{
			other.GetComponent<pepeplayer> ().respawn ();
		}
	}
}
