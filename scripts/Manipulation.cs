using UnityEngine;

public class Manipulation : MonoBehaviour
{
	public static GameObject selectedObject;
	// deselect
	public KeyCode deselectKey = KeyCode.Space;

	// how fast mouse rotates the object
	public float rotationRate = 10f;
	// scale variables. currentScale always tries to lerp to targetScale at resizeRate.
	private float currentScale = 1f;
	private float targetScale = 1f;
	public float resizeRate = .5f;
	// player adjust the targetScale by scaleMouseRate per scroll wheel tick.
	public float scaleMouseRate = .1f;
	// target scale is clamped between min and max values
	private float minScale = .3f;
	private float maxScale = 5f;
	// constrict rotations and scale
	public bool allowXRotate = true;
	public bool allowYRotate = true;
	public bool allowScale = true;

	public enum Mode
	{
		Move,
		Rotate
	}
	private Mode currentMode = Mode.Move;
	// switch between manipulation types - START HERE

	// select this gameObject, allowing it to be manipulated
	private void OnMouseDown ()
	{
		selectedObject = gameObject;
	}

	private void RotateObject ()
	{
		// Y axis rotation
		if (allowYRotate)
			transform.Rotate (Vector3.down * Input.GetAxis ("Horizontal") * rotationRate);
		// X axis rotation
		if (allowXRotate)
			transform.Rotate (Vector3.right * Input.GetAxis ("Vertical") * rotationRate);
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
		if (selectedObject == gameObject)
		{
			RotateObject();
			if (allowScale) { ScaleObject(); }
		}

		// clear movement selection
		if (Input.GetKeyDown (deselectKey))
			selectedObject = null;
	}
	
}