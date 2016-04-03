using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {
	public int Speed;
	public MainScript main;
	
	private bool active = true;
	
	void Start() {
		transform.Translate(new Vector3(0, Random.Range(-5, 5), 0));
		transform.Translate(new Vector3(Random.Range(-50, 50), 0, 0));
		Speed += Random.Range(-10, 10);
	}
	
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