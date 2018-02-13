using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//Variables
	public float movementSpeed;
	public GameObject camera1; 

	public GameObject playerObj;

	public GameObject bulletSpawnPoint;
	public GameObject bullet;
	public float waitTime;

	public float points;

	private Transform bulletSpawned;

	void Start()
	{
		playerObj.GetComponent<Rigidbody> ();
		points = 0;
	}


	//Methods
	void Update()
	{
		//Player facing mouse
		Plane playerPlane = new Plane(Vector3.up, transform.position);
		Ray ray = UnityEngine.Camera.main.ScreenPointToRay (Input.mousePosition);
		float hitDist = 0.0f;



		if (playerPlane.Raycast (ray, out hitDist)) {
			//if player is being hit by ray, calculate Vector3 target point and hit distance 
			Vector3 targetPoint = ray.GetPoint(hitDist);
			Quaternion targetRotation = Quaternion.LookRotation (targetPoint - transform.position);
			targetRotation.x = 0;
			targetRotation.z = 0;
		//	targetRotation.y = 0;

			playerObj.transform.rotation = Quaternion.Slerp (playerObj.transform.rotation, targetRotation, 7f * Time.deltaTime);
			//transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, 7f * Time.deltaTime);
			//playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 7f * Time.deltaTime);

			//playerObj.transform.rotation = Quaternion.Slerp (0, 0, 1);

		}

		//Player Movement 
		if (Input.GetKey(KeyCode.W))
			transform.Translate (Vector3.forward * movementSpeed * Time.deltaTime);
			
		if (Input.GetKey(KeyCode.S))
			transform.Translate (Vector3.back * movementSpeed * Time.deltaTime);

		if (Input.GetKey(KeyCode.A))
			transform.Translate (Vector3.left * movementSpeed * Time.deltaTime);

		if (Input.GetKey(KeyCode.D))
			transform.Translate (Vector3.right * movementSpeed * Time.deltaTime);
		
//
		//Shooting
		if (Input.GetMouseButtonDown (0)) {
			Shoot ();
		}

	}

	void Shoot()
	{
		bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
		bulletSpawned.rotation = bulletSpawnPoint.transform.rotation;
	}


}
