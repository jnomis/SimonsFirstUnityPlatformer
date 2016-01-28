using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;

	public Transform groundCheck;
	public Transform wallCheck;
	public Transform wallCheck2;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	private bool walled;
	private bool walled2;

	private bool doubleJumped;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate () {
		
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		walled = Physics2D.OverlapCircle (wallCheck.position, groundCheckRadius, whatIsGround);
		walled2 = Physics2D.OverlapCircle (wallCheck2.position, groundCheckRadius, whatIsGround);

	}

	// Update is called once per frame
	void Update () {
	
		if (grounded || walled || walled2) 
		{
			doubleJumped = false;
		}

		if(Input.GetKeyDown (KeyCode.Space) && (grounded || walled || walled2)) 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}

		if(Input.GetKeyDown (KeyCode.Space) && !doubleJumped && (!grounded || !walled || !walled2)) 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			doubleJumped = true;
		}

		if(Input.GetKey (KeyCode.RightArrow)) 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		if(Input.GetKey (KeyCode.LeftArrow)) 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

	}
}
