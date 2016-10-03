using UnityEngine;
using System.Collections;

public class DesktopTeleport : MonoBehaviour {

    public Transform pointer;
    Vector3? point;

    //desktopbools
    public bool mousedown = false;
    public bool mouseup = false;
    public bool holdingmouse = false;
    //desktopbools

    public Transform raycastpoint;
    public Transform playerHeadobj;

	// Update is called once per frame
	void Update () {

        mousedown = Input.GetMouseButtonDown(1);
        mouseup = Input.GetMouseButtonUp(1);
        holdingmouse = Input.GetMouseButton(1);

        if (holdingmouse)
        {
            RaycastHit hit;

            if (Physics.Raycast(raycastpoint.position, raycastpoint.forward, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Teleport")))
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
        else if (mouseup)
        {
            pointer.gameObject.SetActive(false);
            if (point != null)
            {
                playerHeadobj.position = new Vector3(point.Value.x, playerHeadobj.position.y, point.Value.z);
                point = null;
            }
        }


    }
}
