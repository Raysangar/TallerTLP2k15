using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour
{



	private Rigidbody2D myRigidbody;
	private Vector3 AimPoint;
	private Animator animator;

	public int speed = 10;
	public int bulletSpeed = 100;
	public GameObject bullet;
	public GameObject canon;
	public AudioSource shootAudio;



	// Use this for initialization
	void Start ()
	{
		myRigidbody = this.GetComponent<Rigidbody2D> ();
		animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		Movement ();
		Aim ();
		Shoot ();

	}

	void Movement ()
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		myRigidbody.velocity = Vector2.up * v * speed + Vector2.right * h * speed;
		animator.SetFloat ("velocity", (Vector2.up * v * speed + Vector2.right * h * speed).magnitude);
	}

	void Aim ()
	{
		AimPoint = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10f));
		this.transform.right = AimPoint - this.transform.position;

	}

	 void Shoot ()
	{
		if (Input.GetMouseButtonDown (0)) {
			animator.SetTrigger("Attack");
			GameObject bulletInstance = Instantiate (bullet, canon.transform.position, this.transform.rotation) as GameObject;

			bulletInstance.GetComponent<Rigidbody2D> ().velocity = bulletSpeed * (canon.transform.position - this.transform.position);
			Destroy(bulletInstance,2.0f);
			shootAudio.Play();
		
		}
	}

}
