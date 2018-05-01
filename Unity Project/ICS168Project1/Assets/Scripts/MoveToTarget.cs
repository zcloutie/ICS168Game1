using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour {

	public Transform goal;

	// Use this for initialization
	void Update () {
		goal = GameObject.FindGameObjectWithTag ("Ship").transform;
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.destination = goal.position;
	}

}
