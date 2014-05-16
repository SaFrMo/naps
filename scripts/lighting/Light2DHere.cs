using UnityEngine;
using System.Collections;

public class Light2DHere : MonoBehaviour {

	private Light2D l;
	public Color lightColor;
	public float radius = 5f;

	void Start ()
	{
		l = Light2D.Create (transform.position,
		                    lightColor,
		                    radius);
	}
}
