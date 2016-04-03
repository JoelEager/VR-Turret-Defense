using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {
	public GameObject cardboardObj;
	public int yVelocity;
	public int zVelocity;
	public bool mode;
	public PlayerScript player;
	public Transform bullet;
	
	private Rigidbody cardboardObjRB;
	
	void Start() {
		Cardboard.Create();
		Cardboard.SDK.OnTrigger += TriggerPulled;
		
		cardboardObjRB = cardboardObj.GetComponent<Rigidbody>();
	}

	void TriggerPulled() {
		if (mode) {
			Vector3 acc = new Vector3(0, 0, zVelocity);
			acc = transform.rotation * acc;
			acc.y = yVelocity;
			cardboardObjRB.velocity = acc;
		} else {
			if (Vector3.Angle(transform.rotation * Vector3.forward, Vector3.down) < 50) {
				LeaveTurret();
			} else {
				Vector3 offsetL = transform.position + new Vector3(0, -0.2f, 0) + (transform.rotation * new Vector3(-0.5f, 0, 1));
				Vector3 offsetR = transform.position + new Vector3(0, -0.2f, 0) + (transform.rotation * new Vector3(0.5f, 0, 1));
				Quaternion bulletRotation = transform.rotation * Quaternion.Euler(90, 0, 0);
				Instantiate(bullet, offsetL, bulletRotation);
				Instantiate(bullet, offsetR, bulletRotation);
			}
		}
	}
	
	void LeaveTurret() {
		player.Fly();
		mode = true;
		TriggerPulled();
	}
}