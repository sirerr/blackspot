using UnityEngine;
using System.Collections;
using Gvr.Internal;

public class GVRTeleport : MonoBehaviour {

	public Transform pointer;
	Vector3? point;

	//gvr controller bools
	public bool touchdownpad = false;
	public bool touchuppad = false;
	public bool touchingpad = false;
	//gvr controller bools
 
	public Transform raycastpoint;
	public Transform GVRheadobj;
	// Update is called once per frame
	void Update () {

		touchingpad = GvrController.IsTouching;
		touchuppad =GvrController.TouchUp;

		if(touchingpad)
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
		else if(touchuppad)
		{
			pointer.gameObject.SetActive(false);
			if (point != null)
			{
				GVRheadobj.position = new Vector3(point.Value.x,GVRheadobj.position.y,point.Value.z);
				point = null;
			}
		}
	}
}
