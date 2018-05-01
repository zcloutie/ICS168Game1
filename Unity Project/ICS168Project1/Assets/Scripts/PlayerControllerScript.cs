using UnityEngine;
using UnityEngine.Networking;

public class PlayerControllerScript : NetworkBehaviour
{
	public float speed = 3.0F;
	public float rotateSpeed = 3.0F;
	public Camera cam;

	private bool isdriving = false;
	private bool intriggerwheel = false;
	private bool intriggergun = false;
	public GameObject ship;
	private ShipController shipscript;
	private Cannon guncode;
	private Camera shipcam;

	void Start(){
		ship = GameObject.FindGameObjectWithTag ("Ship");
		shipscript = ship.GetComponent<ShipController>();
		shipcam = ship.GetComponentInChildren<Camera> ();
		this.transform.parent = ship.transform;
		if (!isLocalPlayer)
		{
			cam.enabled = false;
		}
	}

	void Update()
	{
		if (!isLocalPlayer)
		{
			cam.enabled = false;
			return;
		}

		if (!isdriving) {
			cam.enabled = true;
		}
		if (intriggerwheel) {
			if (Input.GetKeyUp ("e")) {
				if (!shipscript.driven) {
					isdriving = true;
					shipscript.driven = true;
					cam.enabled = false;
					shipcam.enabled = true;

				} else if (isdriving) {
					isdriving = false;
					shipscript.driven = false;
					cam.enabled = true;
					shipcam.enabled = false;
				}
			}
		}

		if (intriggergun) {
			if (Input.GetKeyUp ("e")) {
				guncode.Fire ();
			}
		}

		if (!isdriving) {
			CharacterController controller = GetComponent<CharacterController> ();
			transform.Rotate (0, Input.GetAxis ("Horizontal") * rotateSpeed, 0);
			Vector3 forward = transform.TransformDirection (Vector3.forward);
			float curSpeed = speed * Input.GetAxis ("Vertical");
			controller.SimpleMove (forward * curSpeed);
		}
		else{
			shipscript.Drive ();
		}
	}

	public override void OnStartLocalPlayer()
	{
		GetComponent<Renderer>().material.color = Color.blue;
		cam.enabled = true;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Ship") {
			intriggerwheel = true;
		} else if (other.tag == "Cannon") {
			intriggergun = true;
			guncode = other.GetComponent<Cannon> ();
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Ship") {
			intriggerwheel = false;
		} else if (other.tag == "Cannon") {
			intriggergun = false;
		}
	}
}