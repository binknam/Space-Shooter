using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float tilt;
	public float speed;
	public Object shot;
	public Transform shotSpawn;
	public float fireRate;

	private float Xmin = -6.8f, Xmax = 6.8f, Zmin = -4, Zmax = 8;
	private float nextFire;

	void Update() {

		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}

	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody> ().velocity = movement * speed;

		GetComponent<Rigidbody> ().position = new Vector3
		(
				Mathf.Clamp (GetComponent<Rigidbody> ().position.x, Xmin, Xmax),
				0.0f,
				Mathf.Clamp (GetComponent<Rigidbody> ().position.z, Zmin, Zmax)
		);

		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody> ().velocity.x * tilt);
	}
}
