using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {


	private GameObject Player;
	private Rigidbody2D myRigidbody;

	public int speed;
	public GameObject blood;
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
			GameObject bloodInstance = Instantiate(blood, this.transform.position, this.transform.rotation) as GameObject;
			Destroy(bloodInstance,1.0f);
			Destroy (other.gameObject);
			Destroy (this.gameObject,0.01f);
            GameObject.Find("ScoreController").GetComponent<ScoreController>().addScore(1);
		} else if (other.gameObject.tag == "Player")
            GameObject.Find("LevelManager").GetComponent<LevelManager>().playerDied();
	}
}
