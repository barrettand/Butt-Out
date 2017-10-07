using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOfYarnScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnBall", 3.0f, 20.0f);
    }
	
	// Update is called once per frame
	void Update () {

	}

    void SpawnBall() {
        Instantiate(Resources.Load("Prefabs/Ball Of Yarn"), new Vector2(Random.Range(-7.5f, 7.5f), 9), transform.rotation);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name.Contains("Yarn"))
        {
            Destroy(col.gameObject);
        }
    }
}
