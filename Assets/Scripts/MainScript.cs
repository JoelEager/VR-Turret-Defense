using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {
	public GameObject cardboardObj;
	public int yVelocity;
	public int zVelocity;
	public bool mode;
	public PlayerScript player;
	
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
			}
		}
	}
	
	void LeaveTurret() {
		player.Fly();
		mode = true;
		TriggerPulled();
	}
}