﻿using UnityEngine;
using System.Collections;

public class CreateAndShootAction : MonoBehaviour {

    SteamVR_TrackedObject trackedobj;
    public GameObject ballobj;
    public bool ballmade = false;
  //  public bool neednewball = false;

    private bool triggerpull = false;
    private bool triggerletgo = false;
    private bool triggerholding = false;

    public float ballspeed = 0;
    public Transform spotlocation;

    private GameObject currentball;

    private float holdballtime =0;
    public float holdballtimelimit = 10;

    void Awake()
    {
        trackedobj = GetComponent<SteamVR_TrackedObject>();

    }

    void Update()
    {
        var device = SteamVR_Controller.Input((int)trackedobj.index);
        triggerpull = device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger);
        triggerletgo = device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger);
        triggerholding = device.GetPress(SteamVR_Controller.ButtonMask.Trigger);

        if (triggerpull && !ballmade)
        {
         //   print("trigger pulled");
            GameObject newball = Instantiate(ballobj, spotlocation.position, Quaternion.identity) as GameObject;
            newball.GetComponent<Rigidbody>().isKinematic = true;
            newball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            newball.transform.parent = transform;
            ballmade = true;
            currentball = newball;
        }

        if (triggerholding && ballmade)
        {

            holdballtime += Time.deltaTime;

            if (holdballtime > holdballtimelimit)
            {
                Rigidbody rbody = currentball.GetComponent<Rigidbody>();
                currentball.transform.parent = null;
              rbody.isKinematic = false;
               rbody.constraints = RigidbodyConstraints.None;
                float speed = ballspeed * (10 * holdballtime);
                rbody.AddForce(transform.forward *speed);
                holdballtime = 0;
            }
        }

        if (triggerletgo && ballmade)
        {
            Rigidbody rbody = currentball.GetComponent<Rigidbody>();
            currentball.transform.parent = null;
            rbody.isKinematic = false;
            rbody.constraints = RigidbodyConstraints.None;
            float speed = ballspeed * (10 * holdballtime);
            rbody.AddForce(transform.forward * speed);
            holdballtime = 0;
            ballmade = false;
        }
    }
}
