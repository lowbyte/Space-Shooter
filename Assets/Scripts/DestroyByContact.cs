using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public GameObject hullBreach;
	public int scoreValue;

	private GameController gameController;
	private bool isDead;

	void Start()
	{
		//Debug.Log(string.Format("{0} DestroyByContact created.", this.ToString()));

		isDead = false;
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}

		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		Debug.Log (string.Format("{0} detected a collision with {1}", this.gameObject.ToString(), other.gameObject.ToString()));

		//if ((gameObject.tag == "Asteroid" && other.tag == "Asteroid")) {
		//	return;
		//}

		if ((gameObject.tag == "Asteroid" && other.tag == "Enemy")
		    || (gameObject.tag == "Enemy" && other.tag == "Enemy")
		    || (gameObject.tag == "Enemy" && other.tag == "Asteroid"))
		{
			Debug.Log ("Important collision detected.");
			if (other.tag != "Asteroid")
			{
				throw(new UnityException());
				Debug.Log ("Starting co routine");
				if (hullBreach != null)
				{
					Instantiate (hullBreach, transform.position, transform.rotation);
				}
				//StartCoroutine( CollisionExplosionCollider(other));

			}

			//if (gameObject.tag != "Asteroid")
		//		StartCoroutine(CollisionExplosionGameObject(gameObject));

			if (!isDead)
				gameController.AddScore (scoreValue);

			isDead = true;

			return;
		}
		//if (other.tag == "Enemy Bolt" && gameObject.tag == "Enemy")
		//	return;

		if (other.tag == "Boundary")
			return;

		if (other.tag == "Player") 
		{
 			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		
		if (!isDead)
			gameController.AddScore (scoreValue);
		if (explosion != null) {
			Instantiate (explosion, transform.position, transform.rotation);
		}

		isDead = true;
		Destroy (other.gameObject);
		Destroy (gameObject);

	}
	/*
	IEnumerator CollisionExplosionCollider(Collider collisionObject)
	{
		throw(new UnityException());
		Debug.Log ("In coroutine.");
		yield return new WaitForSeconds(0.1f);

		
		if (explosion != null) {
			Debug.Log (string.Format("{0} has been destroyed.", collisionObject.tag));
			Instantiate (explosion, collisionObject.transform.position, collisionObject.transform.rotation);
		}

		if (tag != "Asteroid") {
			Debug.Log (string.Format("And {0} has been destroyed.", tag));
			Instantiate (explosion, transform.position, transform.rotation);
		}
		Destroy (gameObject);
		Destroy (collisionObject.gameObject);
	}

	IEnumerator CollisionExplosionGameObject(GameObject collisionObject)
	{
		yield return new WaitForSeconds(0.1f);
		
		if (explosion != null) {
			Instantiate (explosion, transform.position, transform.rotation);
		}
		
		Destroy (collisionObject);
	}*/
}
