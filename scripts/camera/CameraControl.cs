using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameObject overallView;
	public GameObject player;
	public float cameraLerpRate;

	private Vector3 goalPlayerMode;

	public enum CamMode
	{
		FollowPlayer,
		Overall
	}

	// is the camera following the player or stepping back to take a look?
	CamMode currentCamMode = CamMode.FollowPlayer;
	// switch camera modes
	private void CamModeToggle ()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			if (currentCamMode == CamMode.FollowPlayer) { currentCamMode = CamMode.Overall; }
			else { currentCamMode = CamMode.FollowPlayer; }
		}
	}

	private void Update ()
	{
		// overall camera control
		CamModeToggle();


		switch (currentCamMode)
		{
		case CamMode.FollowPlayer:
			goalPlayerMode = player.transform.position + Vector3.back * 10;
			if (transform.position != goalPlayerMode)
			{
				transform.position = Vector3.Lerp (transform.position, goalPlayerMode, cameraLerpRate * Time.deltaTime);
			}


			break;

		case CamMode.Overall:
			if (transform.position != overallView.transform.position)
			{
				transform.position = Vector3.Lerp (transform.position, overallView.transform.position, cameraLerpRate * Time.deltaTime);
			}
			break;
		}
		transform.LookAt (player.transform.position);

	}
}
