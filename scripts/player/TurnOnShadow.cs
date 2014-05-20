using UnityEngine;
using System.Collections;

public class TurnOnShadow : MonoBehaviour {

	private void OnCollisionEnter (Collision c)
	{
		if (!c.collider.GetComponent<MeshRenderer>().castShadows)
		{
			c.collider.GetComponent<MeshRenderer>().castShadows = true;
		}
	}
}
