using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObaMoveNat : MonoBehaviour
{
	private CharacterController characterController;
	private Vector3 velocity;
	public float walkSpeed;
	public Animator animator;


	// Start is called before the first frame update
	void Start()
	{
		characterController = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{

		/*if (characterController.isGrounded)
		{
			velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

			if (velocity.magnitude > 0.1f)
			{
				walkSpeed = 0.5f;
				animator.SetFloat("Tired", velocity.magnitude);
                if (Input.GetKey(KeyCode.LeftShift))
                {
					animator.SetFloat("Tired", 1.5f);
					walkSpeed = 1.5F;
				}
			}
			else
			{
				animator.SetFloat("Tired", 0f);
			}
		}
		velocity.y += Physics.gravity.y * Time.deltaTime;
		characterController.Move(velocity * walkSpeed * Time.deltaTime);*/

		if (characterController.isGrounded)
		{
			velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

			if (velocity.magnitude > 0.1f)
			{
				walkSpeed = 1;
				animator.SetFloat("Speed", velocity.magnitude);
				if (Input.GetKey(KeyCode.LeftShift))
				{
					animator.SetFloat("Speed", 1.5f);
					walkSpeed = 3;
				}
			}
			else if (velocity.magnitude >= -0.1f)
			{
				walkSpeed = 1;
				animator.SetFloat("Speed", -1);
			}
			else
			{
				animator.SetFloat("Speed", 0f);
			}
		}
		velocity.y += Physics.gravity.y * Time.deltaTime;
		characterController.Move(velocity * walkSpeed * Time.deltaTime);
	}
}
