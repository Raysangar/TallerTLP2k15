using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {


	private GameObject Player;
	private Rigidbody2D myRigidbody;

	public int speed;
	// Use this for initialization
	void Start () {
		Player=GameObject.Find ("MainCharacter");
		myRigidbody = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 direction = (Player.transform.position - this.transform.position).normalized;

		myRigidbody.velocity = direction * speed;
		Vector3 lookTowards = (Player.transform.position - this.transform.position).normalized;
		lookTowards.z = 0f;
		this.transform.right = lookTowards;

	
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Bullet") {
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		} else if (other.gameObject.tag == "Player") {
			Debug.Log("endGame");
		
		}
	}
}
