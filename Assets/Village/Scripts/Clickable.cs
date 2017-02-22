using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour {

	Material mat;
	private Color originalColor;
	// Use this for initialization
	void Start () {
		mat = GetComponent<Renderer> ().material;
		originalColor = mat.color;
	}
	

	public void HandleMouseEnter()
	{
		mat.color = Color.red;
	}

	public void HandleMouseExit()
	{
		mat.color = originalColor;
	}

	public void HandleClick()
	{
		StartCoroutine (HandleClick_Private ());
	}


	private IEnumerator HandleClick_Private()
	{
		mat.color = Color.cyan;
		yield return new WaitForSeconds (.2f);
		mat.color = originalColor;
	}
}
