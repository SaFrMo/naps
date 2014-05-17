using UnityEngine;
using System.Collections;
using Vectrosity;

public class OrientationCircles : MonoBehaviour {

	Vector2[] segments = new Vector2[100];
	VectorLine xzAxis;

	private void Start ()
	{
		xzAxis = new VectorLine ("XZ Circle", segments, Color.green, null, 2f);
		xzAxis.MakeCircle(Camera.main.WorldToScreenPoint(transform.position), 200f);
		xzAxis.Draw();
	}


}
