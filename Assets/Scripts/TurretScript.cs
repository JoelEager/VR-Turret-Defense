using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {
	public GameObject myBack;
	public GameObject myGunL;
	public GameObject myGunR;
	public GameObject myStand;
	public int id;
	
	public void Activate(Transform player) {
		player.position = transform.position + new Vector3(0, 0.5f, 0);
		myBack.SetActive(false);
		myGunL.SetActive(false);
		myGunR.SetActive(false);
		myStand.SetActive(false);
	}
	
	public void Deactivate() {
		gameObject.SetActive(false);
		myBack.SetActive(false);
		myGunL.SetActive(false);
		myGunR.SetActive(false);
		myStand.SetActive(false);
	}
}