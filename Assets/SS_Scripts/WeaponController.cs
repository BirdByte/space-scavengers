/*
 * Enemy firing handler.
 * 
 */


using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;

	void Start ()
	{
        //continue to fire until object destroyed
		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire ()
	{
        //spawn projectiles and play sound
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		GetComponent<AudioSource>().Play();
	}
}
