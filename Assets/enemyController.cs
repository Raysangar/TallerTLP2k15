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

		Vector2 direction = Player.transform.position - this.transform.position;

		myRigidbody.velocity = direction * speed;
		Vector3 moveTowards = (Player.transform.position - this.transform.position).normalized;
		moveTowards.z = 0f;
		this.transform.right = moveTowards;

	
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
