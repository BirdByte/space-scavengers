/*
 *  Moves object forward.
 *  Simple script can be applied to many objects.  Enemies, weapons, etc.
 */


using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float speed;

	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}

