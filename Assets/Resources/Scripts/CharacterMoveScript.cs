using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMoveScript : MonoBehaviour {
    public GameObject opponent, cooldownBar, victoryText, continueButton;
    public int dir;
    public float buttforce;
    public KeyCode keyLeft, keyRight, keyThrust, keySuperThrust;
    public bool onGround, showContinue;
    public bool showVictory = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (cooldownBar.name.Contains("1") && cooldownBar.GetComponent<RectTransform>().anchoredPosition.x < 0) {
            cooldownBar.GetComponent<RectTransform>().anchoredPosition += new Vector2(5, 0);
        }
        if (cooldownBar.name.Contains("1") && cooldownBar.GetComponent<RectTransform>().anchoredPosition.x < -2000)
        {
            cooldownBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(-2000, 0);
        }
        if (cooldownBar.name.Contains("2") && cooldownBar.GetComponent<RectTransform>().anchoredPosition.x > 0)
        {
            cooldownBar.GetComponent<RectTransform>().anchoredPosition -= new Vector2(5, 0);
        }
        if (cooldownBar.name.Contains("2") && cooldownBar.GetComponent<RectTransform>().anchoredPosition.x > 2000)
        {
            cooldownBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(2000, 0);
        }
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
            buttforce = ((2000 - Mathf.Abs(cooldownBar.GetComponent<RectTransform>().anchoredPosition.x)) / 4);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(((2000 - Mathf.Abs(cooldownBar.GetComponent<RectTransform>().anchoredPosition.x))/4) * dir, 200));
            onGround = false;
            if (cooldownBar.name.Contains("1"))
            {
                cooldownBar.GetComponent<RectTransform>().anchoredPosition -= new Vector2(500, 0);
            }
            if (cooldownBar.name.Contains("2"))
            {
                cooldownBar.GetComponent<RectTransform>().anchoredPosition += new Vector2(500, 0);
            }
        }
        if (Input.GetKeyDown(keySuperThrust) && onGround)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
            onGround = false;
        }
        if (transform.position.y < -8)
        {
            showVictory = true;
            victoryText.GetComponent<Text>().enabled = showVictory;
            victoryText.GetComponent<Text>().text = opponent.gameObject.name + " is victorious!";
            showContinue = true;
            continueButton.gameObject.SetActive(showContinue);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Arena") {
            onGround = true;
        }
        if (col.gameObject.GetComponent<Rigidbody2D>())
        {
            col.gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(buttforce * 0.5f * -dir, 0));
            buttforce = 0;
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Rigidbody2D>())
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(buttforce * 0.5f * -dir, 0));
            buttforce = 0;
        }
    }
}
