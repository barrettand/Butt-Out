using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveScript : MonoBehaviour {
    public int dir;
    public KeyCode keyLeft, keyRight, keyThrust;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(keyLeft))
        {
            transform.Translate(-0.05f, 0, 0);
        }
        if (Input.GetKey(keyRight))
        {
            transform.Translate(0.05f, 0, 0);
        }
        if (Input.GetKeyDown(keyThrust))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(500 * dir, 100));
        }
    }
}
