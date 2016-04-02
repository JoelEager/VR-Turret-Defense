using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {
	public GameObject cardboardObj;
	public int yAcc;
	public int zAcc;
	
	private Rigidbody cardboardObjRB;
	
	void Start() {
		Cardboard.Create();
		Cardboard.SDK.OnTrigger += TriggerPulled;
		
		cardboardObjRB = cardboardObj.GetComponent<Rigidbody>();
	}

	void TriggerPulled() {
		Vector3 acc = new Vector3(0, 0, zAcc);
		acc = transform.rotation * acc;
		acc.y = yAcc;
		Debug.Log(acc);
		cardboardObjRB.AddForce(acc);
	}
	
	void Update() {
		if (cardboardObj.transform.position.y < 1) {
			cardboardObj.transform.position = new Vector3(0, 3, 0);
		}
	}
}