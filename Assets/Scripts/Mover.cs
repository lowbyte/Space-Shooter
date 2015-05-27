using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour 
{
	public float speed;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}

	void Update()
	{
		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
	}
}
