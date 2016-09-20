using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
    SteamVR_TrackedObject trackedObj;
    public Transform pointer;
    Vector3? point;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        Debug.Log(trackedObj);
    }

    void Update()
    {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Teleport")))
            {
                pointer.gameObject.SetActive(true);
                point = hit.point;
                pointer.position = (transform.position + point.Value) / 2f;
                pointer.localScale = new Vector3(pointer.localScale.x, pointer.localScale.y, Vector3.Distance(transform.position, point.Value));
            }
            else
            {
                pointer.gameObject.SetActive(false);
                point = null;
            }
        }
        else if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            pointer.gameObject.SetActive(false);
            if (point != null)
            {
                SteamVR_Camera top = SteamVR_Render.Top();
                Vector3 headPosOnGround = new Vector3(top.head.position.x, 0.0f, top.head.position.z);
                top.origin.position = point.Value + new Vector3(top.origin.position.x, 0f, top.origin.position.z) - headPosOnGround;
                point = null;
            }
        }
        else
        {
            //  pointer.gameObject.SetActive(false);
        }
    }
}
