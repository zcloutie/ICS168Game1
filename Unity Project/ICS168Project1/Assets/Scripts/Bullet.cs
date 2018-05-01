using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour {

	public float end = 4f;
	private float timer;
	private bool isgrounded = false;
	void Update () {
		if (isgrounded)
			timer += 1.0F * Time.deltaTime;
		if (transform.position.y < 0)
			timer += 1.0F * Time.deltaTime;
		if (timer >= end)
			GameObject.Destroy (gameObject);
	}

	void OnCollisionEnter(Collision theCollision) {
		if (theCollision.gameObject.name == "Terrain")
			isgrounded = true;
	}
		
	void OnCollisionExit(Collision theCollision) {
		if (theCollision.gameObject.name == "Terrain")
			isgrounded = false;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Enemy")) {
			other.gameObject.SetActive (false);
			Debug.Log ("Target Hit");
		}
	}
}
