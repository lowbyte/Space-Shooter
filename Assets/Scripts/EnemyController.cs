using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float startFireWait;
	public GameObject shot;
	public Transform shotSpawn;
	public float delayTime;
	public float fireRate;

	private AudioSource audio;

	// Use this for initialization
	void Start () 
	{
		audio = this.GetComponent<AudioSource> ();
		InvokeRepeating ("FireBolt", delayTime, fireRate);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FireBolt()
	{
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		this.audio.Play ();
	}
}
