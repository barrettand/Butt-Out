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
        Quaternion q = new Quaternion(0, 0, 0, 0);
        q.eulerAngles = new Vector3(0, 0, 270);
        Instantiate(Resources.Load("Prefabs/Ball Of Yarn"), new Vector2(Random.Range(-7.5f, 7.5f), 9), q);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name.Contains("Yarn"))
        {
            Destroy(col.gameObject);
        }
    }
}
