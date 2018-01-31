/*
 * Attached to in-game currency / ship parts.
 * Manages movement, object rotation, object destruction, and object sound.
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour {

    public float speed;
    public float rotateSpeed;
    public int currencyValue;
    private GameController gameController;
 
    void Start()
    {
    
        //move object forward
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

        //link to gamecontroller
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

    }

    void Update()
    {

        //rotates object
        transform.Rotate(Vector3.right, rotateSpeed * Time.deltaTime, Space.World);

    }

    void OnTriggerEnter(Collider other)
    {
        //will ignore other objects labeled "enemy"
        if (other.tag == "PlayerLaser")
        {
            return;
        }
        if (other.tag == "Enemy")
        {
            return;
        }

        //if player ship contacts with currency 
        if (other.tag == "Player")
        {
            PickUp();
        }
    }

    public void PickUp()
    {

        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        Destroy(gameObject, .1f);   //delay object destroy; allows time for sfx to play

        gameController.AddCurrency(currencyValue);

    }


}
