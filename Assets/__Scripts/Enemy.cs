using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float health;
	public float pointsToGive;

	public GameObject player;



	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
			Die ();
	}

	public void Die()
	{
		Destroy (this.gameObject);
		player.GetComponent<Player> ().points += pointsToGive;
	}
}
