using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NewTestAI : MonoBehaviour
{

    public Transform destinationPoint;
    public float distance;
    public float fleedistance;
    public bool shooting;
    public bool fleeing;
    public bool advancing;
    public Vector3 fleedir;
    public GameObject Player;
    public float navspeed;
    public GameObject Gun;
    public float startflee;
    public float stopflee;
    public float startshoot;
    public Vector3 targetdir;
    private NavMeshAgent agent;
    public Transform[] points;
    public float remaindist;
    public int randomIndex;

    // Use this for initialization
    void Start()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0;
        agent = GetComponent<NavMeshAgent>();
    }
    void Awake()
    {
        destinationPoint = Player.transform;
        if (fleedistance == 0)
        {
            fleedistance = 5;
        }
        shooting = true;
        navspeed = GetComponent<UnityEngine.AI.NavMeshAgent>().speed;
    }
    
    
    void Update()
    {
        remaindist = agent.remainingDistance;
        if (Player.gameObject.activeSelf)
        {
            targetdir = Player.transform.position;
            fleedir = (transform.position - Player.transform.position).normalized;
            distance = Vector3.Distance(transform.position, Player.transform.position);
            if (distance >= startshoot)
            {
                shooting = false;
                advancing = true;
                fleeing = false;
            }
            if (distance >= stopflee && distance <= startshoot)
            {
                shooting = true;
                fleeing = false;
                advancing = false;
            }
            if (distance < startflee)
            {
                fleeing = true;
                shooting = false;
                advancing = false;
            }
            if (shooting)
            {
                destinationPoint = transform;
                transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = transform.position;
                transform.LookAt(Player.transform, Vector3.up);
                GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0;
                Gun.GetComponent<Enemyshoot> ().shouldshoot = true;
            }
            if (fleeing)
            {
                destinationPoint = Player.transform;
                fleedir = (transform.position - destinationPoint.position).normalized;
                transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = destinationPoint.position;
                transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = transform.position + fleedir * fleedistance;
                GetComponent<UnityEngine.AI.NavMeshAgent>().speed = navspeed * 2;
                Gun.GetComponent<Enemyshoot> ().shouldshoot = false;
            }
            if (advancing)
            {
                transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = destinationPoint.position;
                destinationPoint = Player.transform;
                GetComponent<UnityEngine.AI.NavMeshAgent>().speed = navspeed;
                Gun.GetComponent<Enemyshoot> ().shouldshoot = false;
            }
        } else
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                Gun.GetComponent<Enemyshoot>().shouldshoot = false;
                randomIndex = Random.Range(0, points.Length);
                destinationPoint = points[randomIndex];
                transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = destinationPoint.position;
                destinationPoint = Player.transform;
                GetComponent<UnityEngine.AI.NavMeshAgent>().speed = navspeed;
                Debug.Log("cool fort");
            }
        }
    }
    
}