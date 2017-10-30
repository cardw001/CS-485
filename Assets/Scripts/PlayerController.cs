using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private Vector3 spawn;
	
	public LayerMask groundLayers;
	public float jumpForce = 9;
	public SphereCollider col;
	
	void Start ()
	{
		rb = GetComponent <Rigidbody> ();
		col = GetComponent <SphereCollider> ();
		spawn = transform.position;
	}
	void Update()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
		
		if(IsGrounded() && Input.GetKeyDown(KeyCode.Space)){
		rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}
	void OnCollisionEnter(Collision other){
	 if(other.gameObject.tag == "Ground")
		{
			transform.position = spawn;
		}
	}
	private bool IsGrounded()
	{
		return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
	}
}