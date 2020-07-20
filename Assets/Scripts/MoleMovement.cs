using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleMovement : MonoBehaviour {

    public float upForce = 200;

    private bool isDead = false;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();//check for a rigid body for physics
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero; //get parameter velocity an update at 0 every time player jumps
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }
	}

	void OnCollisionEnter2D(Collision2D coll)//if gameobject hits an obj is called
    {
		if (coll.gameObject.tag != "background") {
			isDead = true;
			GameControl.instance.BirdDied();
		}

    }
}
