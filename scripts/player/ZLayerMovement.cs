using UnityEngine;
using System.Collections;

public class ZLayerMovement : MonoBehaviour {

	public float zMovementRate = 1f;
	public float maxZ = 5f;
	public float minZ = 5f;
	private float currentZ;
	private float targetZ;
	public KeyCode zForwardKey = KeyCode.W;
	public KeyCode zBackKey = KeyCode.S;

	private void Start ()
	{
		currentZ = transform.position.z;
		maxZ = currentZ + maxZ;
		minZ = currentZ - minZ;
		targetZ = currentZ;
	}

	private void Update ()
	{
		if (Input.GetKeyDown (zForwardKey) && targetZ < maxZ)
		{
			targetZ++;
		}
		if (Input.GetKeyDown (zBackKey) && targetZ > minZ)
		{
			targetZ--;
		}

		if (transform.position.z != targetZ)
		{
			transform.position = Vector3.Lerp (transform.position, 
			                                   new Vector3 (transform.position.x, transform.position.y, targetZ),
			                                   zMovementRate * Time.deltaTime);
		}
	}

}
