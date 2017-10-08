using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMoveScript : MonoBehaviour {
    public GameObject opponent, cooldownBar, victoryText, continueButton;
    public int dir, sizeType;
    public float buttforce;
    public KeyCode keyLeft, keyRight, keyThrust, keySuperThrust;
    public bool onGround, showContinue;
    public bool showVictory = false;
	// Use this for initialization
	void Start () {
        sizeType = 1;
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
        transform.localScale = new Vector3(3 * dir, transform.localScale.y, transform.localScale.z);
        if (Input.GetKey(keyLeft))
        {
            if (sizeType == 1 && onGround)
            {
                GetComponent<Animator>().Play("BGBOLWalk");
            }
            else if (sizeType == 2 && onGround)
            {
                GetComponent<Animator>().Play("BGBOLWalkSuper");
            }
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0));
        }
        if (Input.GetKey(keyRight))
        {
            if (sizeType == 1 && onGround)
            {
                GetComponent<Animator>().Play("BGBOLWalk");
            }
            else if (sizeType == 2 && onGround)
            {
                GetComponent<Animator>().Play("BGBOLWalkSuper");
            }
            GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0));
        }
        if (Input.GetKeyDown(keyThrust) && onGround)
        {
            if (sizeType == 1)
            {
                GetComponent<Animator>().Play("BGBOLAttack");
            }
            else if (sizeType == 2)
            {
                GetComponent<Animator>().Play("BGBOLAttackSuper");
            }
            buttforce = ((2000 - Mathf.Abs(cooldownBar.GetComponent<RectTransform>().anchoredPosition.x)) / 4);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(((2000 - Mathf.Abs(cooldownBar.GetComponent<RectTransform>().anchoredPosition.x))/4) * dir * sizeType, 200));
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
            if (sizeType == 1)
            {
                GetComponent<Animator>().Play("BGBOLAttack");
            }
            else if (sizeType == 2)
            {
                GetComponent<Animator>().Play("BGBOLAttackSuper");
            }
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
            onGround = false;
        }
        if (onGround && !Input.GetKey(keyLeft) && !Input.GetKey(keyRight))
        {
            if (sizeType == 1)
            {
                GetComponent<Animator>().Play("BGBOLIdle");
            }
            else if (sizeType == 2)
            {
                GetComponent<Animator>().Play("BGBOLIdleSuper");
            }
        }
        if (transform.position.y < -8)
        {
            showVictory = true;
            victoryText.GetComponent<Text>().enabled = showVictory;
            victoryText.GetComponent<Text>().text = opponent.gameObject.name + " is victorious!";
            showContinue = true;
            continueButton.gameObject.SetActive(showContinue);
            Time.timeScale = 0;
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RevertSize()
    {
        sizeType = 1;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Arena") {
            onGround = true;
        }
        if (col.gameObject.GetComponent<Rigidbody2D>() && col.gameObject.name.Contains("Player"))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(buttforce * 0.5f * -dir, 0));
            buttforce = 0;
        }
        if (col.gameObject.name.Contains("Yarn"))
        {
            Destroy(col.gameObject);
            sizeType = 2;
            Invoke("RevertSize", 5.0f);
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
