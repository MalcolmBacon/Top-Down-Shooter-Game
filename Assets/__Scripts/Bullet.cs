using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	 
	public float bulletSpeed = 10f;
	public float maxDistance; 

	private GameObject triggeringEnemy;
	public float damage;


	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.forward * Time.deltaTime * bulletSpeed);

		maxDistance += 1 * Time.deltaTime;
		if (maxDistance >= 5)
			Destroy (this.gameObject);
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy") {
			triggeringEnemy = other.gameObject;
			triggeringEnemy.GetComponent<Enemy> ().health -= damage;
			Destroy (this.gameObject);
		}
	}
}
