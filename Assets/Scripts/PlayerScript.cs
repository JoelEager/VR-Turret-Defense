using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public GameObject myBack;
	public GameObject myGunL;
	public GameObject myGunR;
	public MainScript main;
	
	private Vector3 initalPos;
	private int currentTurret = -1;
	
	void Start() {
		initalPos = transform.position;
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Turret")) {
			myBack.SetActive(true);
			myGunL.SetActive(true);
			myGunR.SetActive(true);
			
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			other.gameObject.GetComponent<TurretScript>().Activate(transform);
			currentTurret = other.gameObject.GetComponent<TurretScript>().id;
			main.mode = 1;
		}
	}
	
	public void Fly(int id) {
		if (id == currentTurret) {
			myBack.SetActive(false);
			myGunL.SetActive(false);
			myGunR.SetActive(false);
			main.mode = 0;
		}
	}
	
	void Update() {
		if (transform.position.x > 75) {
			transform.position = new Vector3(75, transform.position.y, transform.position.z);
		} else if (transform.position.x < -75) {
			transform.position = new Vector3(-75, transform.position.y, transform.position.z);
		} else if (transform.position.z > 75) {
			transform.position = new Vector3(transform.position.x, transform.position.y, 75);
		} else if (transform.position.z < -75) {
			transform.position = new Vector3(transform.position.x, transform.position.y, -75);
		}
	}
}