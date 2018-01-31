/*
 * Handles behavior when Enemy Ship or Enemy Laser comes into contact with
 * the player ship. 
 * 
 */



using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
    public GameObject shipPart;
	public int scoreValue;
	private GameController gameController;

	void Start ()
	{   
        //link to gamecontroller
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
        //enemies will ignore other objects labeled "enemy" (enemy projectiles)
		if (other.tag == "Enemy" || other.tag == "Currency")
		{
			return;
		}

		if (explosion != null)
		{
            //show enemy explosion and dropped ship part
			Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(shipPart, transform.position, transform.rotation);
		}

        //if player ship contacts with "enemy" it will explode
		if (other.tag == "Player")
		{
            Debug.Log("Player explodes");
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		
		gameController.AddScore(scoreValue);
		Destroy (other.gameObject);   //destroy player ship
		Destroy (gameObject);     //destroy enemy ship
	}
}