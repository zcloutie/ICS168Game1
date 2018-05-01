using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Cannon : NetworkBehaviour {
	public GameObject cannonball;
	public float shot_speed = 10f;
	//public int bullets = 10;

	public void Fire(){
		//if (bullets > 0) {
		GameObject ballClone = Instantiate (cannonball, transform.position, transform.rotation);
		Rigidbody ballClone_rb = ballClone.GetComponent<Rigidbody> ();
		ballClone_rb.AddForce (this.gameObject.transform.forward * shot_speed);
		NetworkServer.Spawn (ballClone);
			//bullets--;
		//}
	}

}
