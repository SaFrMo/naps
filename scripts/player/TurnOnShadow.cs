using UnityEngine;
using System.Collections;

public class TurnOnShadow : MonoBehaviour {

	public AudioClip pop;

	private void OnCollisionEnter (Collision c)
	{
		if (!c.collider.GetComponent<MeshRenderer>().castShadows)
		{
			c.collider.GetComponent<MeshRenderer>().castShadows = true;
			GetComponent<AudioSource>().PlayOneShot(pop);
		}
	}
}
