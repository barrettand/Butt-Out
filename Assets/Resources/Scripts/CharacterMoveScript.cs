using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveScript : MonoBehaviour {
    public GameObject opponent;
    public int dir, buttpower;
    public KeyCode keyLeft, keyRight, keyThrust, keySuperThrust;
    public bool onGround;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (opponent.transform.position.x > transform.position.x) {
            dir = 1;
        }
        if (opponent.transform.position.x < transform.position.x)
        {
            dir = -1;
        }
        transform.localScale = new Vector3(dir, transform.localScale.y, transform.localScale.z);
        if (Input.GetKey(keyLeft))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0));
        }
        if (Input.GetKey(keyRight))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0));
        }
        if (Input.GetKeyDown(keyThrust) && onGround)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(buttpower * dir, 200));
            onGround = false;
        }
        if (Input.GetKeyDown(keySuperThrust))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
            onGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Arena") {
            onGround = true;
        }
        if (col.gameObject.GetComponent<Rigidbody2D>())
        {
            col.gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-col.gameObject.GetComponent<CharacterMoveScript>().buttpower * 0.5f * dir, 0));
        }
    }
}
