using UnityEngine;

public class Manipulation : MonoBehaviour
{
	public static GameObject selectedObject;

	// how fast mouse rotates the object
	public float rotationRate = 10f;
	// are we rotating (dragging) the object?
	private bool dragging = true;
	// scale variables. currentScale always tries to lerp to targetScale at resizeRate.
	private float currentScale = 1f;
	private float targetScale = 1f;
	public float resizeRate = .5f;
	// player adjust the targetScale by scaleMouseRate per scroll wheel tick.
	public float scaleMouseRate = .1f;
	// target scale is clamped between min and max values
	private float minScale = .3f;
	private float maxScale = 5f;
	
	// left click to hold and drag, right click to toggle free-drag
	private void DragFunctions ()
	{
		// hold and drag with left click
		if (Input.GetMouseButton (0))
		{
			dragging = true;
		}
		if (Input.GetMouseButtonUp (0))
		{
			dragging = false;
		}
		
		// toggle with right click - don't allow when dragging with left click
		if (Input.GetMouseButtonDown (1) && !Input.GetMouseButton (0))
		{
			dragging = !dragging;
		}
	}
	
	private void MoveObject ()
	{
		if (dragging)
		{
			// TODO: edit this to lerp to a target, like scaling? this may be choppy
			// Y axis rotation
			transform.RotateAround (renderer.bounds.center, Vector3.down, Input.GetAxis ("Horizontal") * rotationRate);
			// X axis rotation
			transform.Rotate (Vector3.right * Input.GetAxis ("Vertical") * rotationRate);
		}
	}
	
	private void ScaleObject ()
	{
		// enlarge
		if (Input.GetAxis ("Mouse ScrollWheel") < 0)
		{
			targetScale += scaleMouseRate;
		}
		// shrink
		if (Input.GetAxis ("Mouse ScrollWheel") > 0)
		{
			targetScale -= scaleMouseRate;
		}
		
		// min-max the target scale value
		targetScale = Mathf.Clamp (targetScale, minScale, maxScale);
		
		// lerp to target scale
		if (currentScale != targetScale)
		{
			currentScale = Mathf.Lerp (currentScale, targetScale, resizeRate * Time.deltaTime);
		}
		
		// min-max the current scale value (just to be safe)
		currentScale = Mathf.Clamp (currentScale, minScale, maxScale);
		
		// apply current scale to model
		transform.localScale = Vector3.one * currentScale;
	}
	
	private void Update ()
	{
		// alpha purposes only
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
		DragFunctions();
		MoveObject();
		ScaleObject();
	}
	
}