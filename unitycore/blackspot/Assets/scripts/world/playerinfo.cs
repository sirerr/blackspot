using UnityEngine;
using System.Collections;

public class playerinfo : MonoBehaviour
{

    public GameObject playerheadobj;
    public GameObject controllerobj1;
    public GameObject controllerobj2;

    public Transform playerheight;
    public Transform controller1;
    public Transform controller2;


    void Awake()
    {
        GameObject camrig = GameObject.FindGameObjectWithTag("Player");
        controllerobj1 = camrig.transform.GetChild(0).gameObject;
        controllerobj2 = camrig.transform.GetChild(1).gameObject;
        playerheadobj = camrig.transform.GetChild(2).gameObject;

        playerheight = playerheadobj.transform;
        controller1 = controllerobj1.transform;
        controller2 = controllerobj2.transform;


    }



    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}