using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {
	public GameObject cardboardObj;
	public int yVelocity;
	public int zVelocity;
	public bool mode;
	
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
			Debug.Log("Brrrt");
		}
	}
}