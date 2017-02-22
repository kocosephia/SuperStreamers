using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour {

	Material mat;
	private Color originalColor;
	private Vector3 originalPosition;

	private bool interactable = true;

	// Use this for initialization
	void Start () {
		mat = GetComponent<Renderer> ().material;
		originalColor = mat.color;
		originalPosition = transform.position;
	}
	

	public void HandleMouseEnter()
	{
		if (!interactable) {
			return;
		}
		mat.color = Color.red;
		transform.position += new Vector3(0f, transform.localScale.y/3 , 0f);
	}

	public void HandleMouseExit()
	{
		if (!interactable) {
			return;
		}
		StartCoroutine (HandleExit_Private ());
	}

	public void HandleClick()
	{
		if (!interactable) {
			return;
		}

		StartCoroutine (HandleClick_Private ());
	}


	private IEnumerator HandleExit_Private()
	{
		interactable = false;
		mat.color = originalColor;
		Vector3 startPos = transform.position;
		Vector3 endPos = originalPosition;
		float p = 0.0f;
		float startTime = Time.time;
		float duration = .5f;
		AnimationCurve curve = AnimationCurve.EaseInOut (0, 0, 1, 1);

		while (true) {
			if (p >= 1.0f) {
				transform.position = endPos;
				break;
			}
			p = (Time.time - startTime) / duration;
			transform.position = Vector3.Lerp (startPos, endPos, curve.Evaluate(p));
			yield return null;
		}
		interactable = true;
	}

	private IEnumerator HandleClick_Private()
	{
		interactable = false;
		mat.color = Color.cyan;
		transform.position = originalPosition;
		yield return new WaitForSeconds (.2f);
		mat.color = originalColor;

		interactable = true;
	}
}
