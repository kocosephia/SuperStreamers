using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour {


	void OnEnable()
	{
		MouseCaster.MouseClickObject += HandleClickOnClickableObject;
		MouseCaster.MouseEnterObject += HandleEnterOnClickableObject;
		MouseCaster.MouseExitObject += HandleExitOnClickableObject;
	}
	void OnDisable()
	{
		MouseCaster.MouseClickObject -= HandleClickOnClickableObject;
		MouseCaster.MouseEnterObject -= HandleEnterOnClickableObject;
		MouseCaster.MouseExitObject -= HandleExitOnClickableObject;
	}


	public void HandleEnterOnClickableObject(Clickable clickable)
	{
		clickable.HandleMouseEnter ();
	}

	public void HandleClickOnClickableObject(Clickable clickable)
	{
		clickable.HandleClick ();
	}

	public void HandleExitOnClickableObject(Clickable clickable)
	{
		clickable.HandleMouseExit ();
	}
}
