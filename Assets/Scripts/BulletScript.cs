using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	public int bulletSpeed;
	public int cullingDistance;
	private Vector3 initalPos;
	
	void Start() {
		initalPos = transform.position;
	}
	
	void Update() {
		transform.Translate(new Vector3(0, bulletSpeed, 0) * Time.deltaTime);
		if ((initalPos - transform.position).magnitude > cullingDistance) {
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Target")) {
			Destroy(other.gameObject);
		}
	}
}