using UnityEngine;
using System.Collections;

public class Enemyshoot : MonoBehaviour
{

    public float fireRate = 0.5f;
    public float Stray;
	public float pelletSpeed = 150f;
	private float nextFire= 0.0f;
    public int pelletCount = 5;
	public Rigidbody pelletPrefab;
	public GameObject pelletPrefabGO;
    public AudioClip Gunshot;
    private AudioSource source;
	public bool shouldshoot;
	public GameObject Player;
    public bool allowedtoshoot;

	void Start(){
		Player = GameObject.Find("FPSController");
		pelletPrefab = pelletPrefabGO.GetComponent<Rigidbody>();
	}
    void Update()
	{
		if (shouldshoot)
        {
            Player = GameObject.Find("FPSController");
            transform.LookAt (Player.transform);
		}
		if (shouldshoot && Time.time > nextFire && allowedtoshoot) {
			Rigidbody pellet;
			for (var i = 0; i < pelletCount; i++) {
				var randomNumberX = Random.Range (-Stray, Stray);
				var randomNumberY = Random.Range (-Stray, Stray);
				pellet = (Rigidbody)Instantiate (pelletPrefab, transform.position, transform.rotation);
				pellet.transform.Rotate (randomNumberX, randomNumberY, 0.0f);
				pellet.AddForce (pellet.transform.forward * pelletSpeed);
			}
			nextFire = Time.time + fireRate;
		}
	}
}
