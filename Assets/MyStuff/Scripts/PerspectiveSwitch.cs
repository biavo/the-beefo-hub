using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveSwitch : MonoBehaviour
{
    public GameObject PS2D;
    public GameObject PS3D;
    public Vector3 V3D;
    public Vector3 V2D;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        V3D = PS3D.transform.position;
        V2D = PS2D.transform.position;

        if (Input.GetKeyDown("f"))
        {
            if (PS2D.activeSelf)
            {
                PS3D.SetActive(true);
                PS3D.transform.position = PS2D.transform.position;
                PS2D.SetActive(false);
            }
            else
            {
                PS2D.SetActive(true);
                PS2D.transform.position = PS3D.transform.position;
                PS3D.SetActive(false);
            }
        }
    }
}