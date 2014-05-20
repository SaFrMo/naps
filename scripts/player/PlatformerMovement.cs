using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlatformerMovement : MonoBehaviour {

	public float movementRate = 1f;
	private bool facingRight = true;
	public float jumpForce = 4f;

	private void HorizontalControls()
	{
		float move = Input.GetAxis("Horizontal");
		rigidbody.velocity = new Vector3(move * movementRate, rigidbody.velocity.y);
		
		
		//make sure the character is facing the right direction
		if (move > 0 && !facingRight)
		{
			Flip();
		}
		else if (move < 0 && facingRight)
		{
			Flip();
		}
	}

	private void VerticalControls ()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			rigidbody.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}
	
	//Change which way the character is facing. 
	void Flip() 
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1; //inverts x scale to flip sprite
		transform.localScale = theScale;
	}


	private void Update ()
	{
		HorizontalControls();
		VerticalControls();
	}
}
