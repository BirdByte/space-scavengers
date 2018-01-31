/*
 *  Controls player movement and weapons.
 * 
 */

 
using UnityEngine;
using System.Collections;

[System.Serializable]   //gives unity access to variables
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    //private GameController gameController;
    //public GameObject playerExplosion;
   // public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
    public float distance = 1.0f;   //z axis distance from camera

    //private Vector3 target;
	private float nextFire = 0.0f;
  

    void Update ()
	{
  		//auto fire when game begins
        if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
    }

	void FixedUpdate ()
	{

        //controls player ship movement
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                //record touch
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    //move object smoothly to new touch position
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0.0f));
                    transform.position = Vector3.Lerp(transform.position, new Vector3(touchPosition.x, 0.0f, touchPosition.z), Time.deltaTime * 20f);
                }
            }
        }
        else
        {
            //PC Movement controls (for easier testing)
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = distance;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }

        //sets boundaries for player ship
        GetComponent<Rigidbody>().position = new Vector3
        (
            //sets boundaries for playership so that it does not move off screen
        	Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
        	0.0f, 
        	Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        //------------------------------

        //-- I BROKE IT!!???
        //-- Note to self: If unable to fix, consider creating tilt through animation instead.
        //-- Also test by putting it in separate script.

        //adds tilt when moving left to right   
        //GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);

    }
}
