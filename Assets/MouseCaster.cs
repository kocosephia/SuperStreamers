using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCaster : MonoBehaviour {

	public delegate void MouseEnterEventDelegate (Clickable objReference);
	public delegate void MouseClickEventDelegate (Clickable objReference);
	public delegate void MouseExitEventDelegate (Clickable objReference);

	public static event MouseEnterEventDelegate MouseEnterObject;
	public static event MouseClickEventDelegate MouseClickObject;
	public static event MouseExitEventDelegate MouseExitObject;

	public Camera castCamera;

	private int lastHitID;
	private Clickable currentRef;

	void Start()
	{
		castCamera = Camera.main;
	}

	// Update is called once per frame
	void LateUpdate () {
		
		RaycastHit hit;
		Ray mouseRay = castCamera.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (mouseRay, out hit)) {
			if (hit.collider.GetInstanceID () != lastHitID && hit.collider.GetComponent<Clickable> ()) {
				if (currentRef != null && MouseExitObject != null) {
					MouseExitObject (currentRef);
				}
				lastHitID = hit.collider.GetInstanceID ();
				currentRef = hit.collider.GetComponent<Clickable> ();
				if (MouseEnterObject != null) {
					MouseEnterObject (currentRef);
				}
			}
		} else {
			if (MouseExitObject != null && currentRef != null) {
				MouseExitObject (currentRef);
			}
			lastHitID = 0;
			currentRef = null;
		}

		if (Input.GetMouseButtonDown (0)) {
			if (currentRef != null) {
				if (MouseClickObject != null) {
					MouseClickObject (currentRef);
				}
			}
		}
	}
}
