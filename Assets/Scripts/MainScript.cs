using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {
	public GameObject cardboardObj;
	public int yAcc;
	public int zAcc;
	public bool mode;
	
	private Rigidbody cardboardObjRB;
	
	void Start() {
		Cardboard.Create();
		Cardboard.SDK.OnTrigger += TriggerPulled;
		
		cardboardObjRB = cardboardObj.GetComponent<Rigidbody>();
	}

	void TriggerPulled() {
		if (mode) {
			Vector3 acc = new Vector3(0, 0, zAcc);
			acc = transform.rotation * acc;
			acc.y = yAcc;
			cardboardObjRB.AddForce(acc);
		} else {
			Debug.Log("Brrrt");
		}
	}
}