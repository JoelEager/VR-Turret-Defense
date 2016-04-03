using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public GameObject myBack;
	public GameObject myGunL;
	public GameObject myGunR;
	public MainScript main;
	TurretScript LastTurret;
	
	private Vector3 initalPos;
	
	void Start() {
		initalPos = transform.position;
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Ground")) {
			transform.position = initalPos;
		} else if (other.gameObject.CompareTag("Turret")) {
			myBack.SetActive(true);
			myGunL.SetActive(true);
			myGunR.SetActive(true);
			
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			LastTurret = other.gameObject.GetComponent<TurretScript>();
			LastTurret.Activate(transform);
			main.mode = false;
		}
	}
	
	public void Fly() {
		myBack.SetActive(false);
		myGunL.SetActive(false);
		myGunR.SetActive(false);
		LastTurret.Deactivate();
	}
}