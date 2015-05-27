using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour 
{
	public float tumble;

	private Rigidbody rb;

	void Start()
	{
		rb = this.GetComponent<Rigidbody> ();

		rb.angularVelocity = Random.insideUnitSphere * tumble;

	}
}
