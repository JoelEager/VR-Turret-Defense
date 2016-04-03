using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {
	public int Speed;
	public MainScript main;
	
	private bool active = true;
	
	void Update () {
		transform.Translate(new Vector3(0, 0, -Speed) * Time.deltaTime);
		
		if (transform.position.z < -75) {
			main.LoseLife();
			active = false;
			Destroy(gameObject);
		}
	}
	
	void OnDestroy() {
		if (active) {
			main.Score();
		}
    }
}