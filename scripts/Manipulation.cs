using UnityEngine;

public class Manipulation : MonoBehaviour
{
	public static GameObject selectedObject;

	// hint - rotate object toward correct value
	public KeyCode hintKey = KeyCode.E;
	public KeyCode zRotateKey = KeyCode.LeftShift;
	// how fast mouse rotates the object
	public float rotationRate = 10f;
	// are we rotating (dragging) the object?
	private bool dragging = true;

	/*
	// scale variables. currentScale always tries to lerp to targetScale at resizeRate.
	private float currentScale = 1f;
	private float targetScale = 1f;
	public float resizeRate = .5f;
	// player adjust the targetScale by scaleMouseRate per scroll wheel tick.
	public float scaleMouseRate = .1f;
	// target scale is clamped between min and max values
	private float minScale = .3f;
	private float maxScale = 5f;
	*/
	
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
			if (Input.GetKey (zRotateKey))
			{
				transform.Rotate (Vector3.forward * Input.GetAxis ("Horizontal") * rotationRate);
			}

			else 
			{
				// Y axis rotation
				transform.Rotate (Vector3.down * Input.GetAxis ("Horizontal") * rotationRate);
				// X axis rotation
				transform.Rotate (Vector3.right * Input.GetAxis ("Vertical") * rotationRate);
			}

		}
	}


	public float hintRate = 0.5f;
	private void Hint ()
	{
		// snap-to on light touch
		if (Input.GetKeyDown(hintKey))
		{
			// round rotation
			Vector3 rot = transform.rotation.eulerAngles;
			transform.rotation = Quaternion.Euler (Mathf.Round (rot.x),
			                                       Mathf.Round (rot.y),
			                                       Mathf.Round (rot.z));
		}
		// hold for hint
		if (Input.GetKey(hintKey))
		{
			// TODO: Start here. Create a "close enough" identifier for arrays/lists of numbers
			if (transform.rotation == originalRotation)
			{
				print ("YOU WIN");
			}

			transform.rotation = Quaternion.Euler (Vector3.RotateTowards (transform.rotation.eulerAngles,
			                                                              originalRotation.eulerAngles,
			                                                              hintRate * Time.deltaTime,
			                                                              0));


		}
	}

	// store correct rotation
	private Quaternion originalRotation;
	private void Start ()
	{
		originalRotation = transform.rotation;
		transform.rotation = Quaternion.Euler (new Vector3 (UnityEngine.Random.Range (0, 360),
							                                  UnityEngine.Random.Range (0, 360),
							                                  UnityEngine.Random.Range (0, 360)));
	}
	
	private void Update ()
	{


		// alpha purposes only
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
		Hint ();
		//DragFunctions();
		MoveObject();
	}
	
}