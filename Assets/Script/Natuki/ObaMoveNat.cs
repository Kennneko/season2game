using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObaMoveNat : MonoBehaviour
{
	public float walkSpeed;
	public Animator animator;
	Vector3 movingDirecion;
	public Rigidbody rb;
	public Vector3 movingVelocity;


	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float z = Input.GetAxisRaw("Vertical");
		movingDirecion = new Vector3(x, 0, z);
		movingDirecion.Normalize();//ŽÎ‚ß‚Ì‹——£‚ª’·‚­‚È‚é‚Ì‚ð–h‚¬‚Ü‚·
		movingVelocity = movingDirecion * walkSpeed;

		if(movingDirecion.z >= 0.5)
		{
			walkSpeed = 1;
			animator.SetFloat("Speed", movingVelocity.magnitude);
			if (Input.GetKey(KeyCode.LeftShift))
			{
				animator.SetFloat("Speed", 1.5f);
				walkSpeed = 1.5F;
			}
		}

		if (movingDirecion.z <= -0.5)
		{
			walkSpeed = 0.5f;
			animator.SetFloat("Speed", -1f);
		}

		if (movingDirecion.z == 0)
		{
			animator.SetFloat("Speed", 0f);
		}

		/*if(movingDirecion.z >= 0.5)
		{
			walkSpeed = 0.5;
			animator.SetFloat("Tired", movingVelocity.magnitude);
			if (Input.GetKey(KeyCode.LeftShift))
			{
				animator.SetFloat("Tired", 1.5f);
				walkSpeed = 1F;
			}
		}
		else
		{
			animator.SetFloat("Tired", 0f);
		}*/
	}

	void FixedUpdate()
	{
		rb.velocity = new Vector3(movingVelocity.x, 0, movingVelocity.z);
	}
}
