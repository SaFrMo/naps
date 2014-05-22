using UnityEngine;
using System.Collections;

public class RotateArt : MonoBehaviour {
	
	public float rotationRate = 5f;
	
	private void Update ()
	{
		transform.Rotate (Vector3.up, rotationRate * Time.deltaTime);
	}
}
