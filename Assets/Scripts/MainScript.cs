using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {
	public GameObject cardboardObj;
	public int yVelocity;
	public int zVelocity;
	public bool mode;
	public PlayerScript player;
	public Transform bullet;
	public Transform target;
	public TurretScript turret0;
	public TurretScript turret1;
	public TurretScript turret2;
	public TextMesh HUDText;
	public int lives;
	
	private int score = 0;
	private Rigidbody cardboardObjRB;
	
	void Start() {
		Cardboard.Create();
		Cardboard.SDK.OnTrigger += TriggerPulled;
		
		cardboardObjRB = cardboardObj.GetComponent<Rigidbody>();
		
		UpdateHUD();
		Invoke("SpawnTarget", 5);
	}
	
	void SpawnTarget() {
		Transform newTarget = (Transform) Instantiate(target, new Vector3(0, 20, 75), Quaternion.identity);
		newTarget.GetComponent<TargetScript>().main = this;
		Invoke("SpawnTarget", 3);
	}

	void TriggerPulled() {
		if (mode) {
			Vector3 acc = new Vector3(0, 0, zVelocity);
			acc = transform.rotation * acc;
			acc.y += yVelocity;
			cardboardObjRB.velocity = acc;
		} else {
			Vector3 offsetL = transform.position + new Vector3(0, -0.2f, 0) + (transform.rotation * new Vector3(-0.5f, 0, 2));
			Vector3 offsetR = transform.position + new Vector3(0, -0.2f, 0) + (transform.rotation * new Vector3(0.5f, 0, 2));
			Quaternion bulletRotation = transform.rotation * Quaternion.Euler(90, 0, 0);
			Instantiate(bullet, offsetL, bulletRotation);
			Instantiate(bullet, offsetR, bulletRotation);
		}
	}
	
	public void LoseLife() {
		lives--;
		UpdateHUD();
		
		if (lives == 10) {
			turret0.Deactivate();
			player.Fly(0);
		} else if (lives == 5) {
			turret1.Deactivate();
			player.Fly(1);
		} else if (lives == 0) {
			Application.LoadLevel(0);
		}
	}
	
	public void Score() {
		score++;
		UpdateHUD();
	}
	
	void UpdateHUD() {
		if (HUDText != null) {
			HUDText.text = "Lives: " + lives + "\nKills: " + score;
		}
	}
}