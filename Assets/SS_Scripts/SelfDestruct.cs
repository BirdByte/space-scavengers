/*
 *  Destroy game objects x amount of time after creation.
 *  Without this the objects will continue to exist off-screen, using memory.
 *  Can be applied to many temporary objects.
 */ 
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    public float timer = 1f;

	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }


    }
}
