using UnityEngine;
using System.Collections;

public class WorldPortal : MonoBehaviour
{

    public GameObject ThisDoor;
    public GameObject OtherDoor;
    public GameObject Player;
    public Transform target;

    void Start()
    {
        ThisDoor = this.gameObject;
        Player = GameObject.Find("FPSController");
        target = OtherDoor.gameObject.transform;
    }

    void OnTriggerEnter(Collider other)
    {
        other.transform.position = target.position;
    }
}