using UnityEngine;
using System.Collections;

public class EnemyBulletKill : MonoBehaviour {
	private float timer;
	public float killtime;

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			Destroy (this.gameObject);
		}
	}
	void OnCollisionEnter (Collision col){
	//	Destroy(this.gameObject);
	}
	void Update () {
		timer += 1.0F * Time.deltaTime;
		if (timer >= killtime) {
			GameObject.Destroy (gameObject);
		}
	}
}
