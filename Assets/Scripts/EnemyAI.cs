using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float speed;
	
	private Rigidbody rb;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0, 180, 0);
	}
}
