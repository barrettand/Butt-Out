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
    public string playerOneChar, playerTwoChar;
    public Sprite victoryMsg;
    // Use this for initialization

    void Start ()
    {
        if (GameObject.Find("Character Manager").GetComponent<CharacterData>().bothPlayersChosen)
        {
            playerOneChar = GameObject.Find("Character Manager").GetComponent<CharacterData>().playerOneChar;
            playerTwoChar = GameObject.Find("Character Manager").GetComponent<CharacterData>().playerTwoChar;
        }
        sizeType = 1;
        if (gameObject.name.Contains("1"))
        {
            GetComponent<Animator>().Play(playerOneChar + "Idle");
        }
        else
        {
            GetComponent<Animator>().Play(playerTwoChar + "Idle");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Character Manager").GetComponent<CharacterData>().bothPlayersChosen)
        {
            playerOneChar = GameObject.Find("Character Manager").GetComponent<CharacterData>().playerOneChar;
            playerTwoChar = GameObject.Find("Character Manager").GetComponent<CharacterData>().playerTwoChar;
        }
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
        if (gameObject.name.Contains("1") && (playerOneChar.Contains("BGB") || playerOneChar.Contains("Megalo"))) {
            transform.localScale = new Vector3(3 * dir, transform.localScale.y, transform.localScale.z);
        }
        if (gameObject.name.Contains("1") && !(playerOneChar.Contains("BGB") || playerOneChar.Contains("Megalo")))
        {
            transform.localScale = new Vector3(1.6f * dir, 1.5f, transform.localScale.z);
            GetComponent<BoxCollider2D>().size = new Vector2(0.6f, 1.5f);
        }
        if (gameObject.name.Contains("2") && (playerTwoChar.Contains("BGB") || playerTwoChar.Contains("Megalo")))
        {
            transform.localScale = new Vector3(3 * dir, transform.localScale.y, transform.localScale.z);
        }
        if (gameObject.name.Contains("2") && !(playerTwoChar.Contains("BGB") || playerTwoChar.Contains("Megalo")))
        {
            transform.localScale = new Vector3(1.6f * dir, 1.5f, transform.localScale.z);
            GetComponent<BoxCollider2D>().size = new Vector2(0.6f, 1.5f);
        }
        if (Input.GetKey(keyLeft))
        {
            if (sizeType == 1 && onGround)
            {
                if (gameObject.name.Contains("1"))
                {
                    GetComponent<Animator>().Play(playerOneChar + "Walk");
                }
                else
                {
                    GetComponent<Animator>().Play(playerTwoChar + "Walk");
                }
            }
            else if (sizeType == 2 && onGround)
            {
                if (gameObject.name.Contains("1"))
                {
                    GetComponent<Animator>().Play(playerOneChar + "WalkSuper");
                }
                else
                {
                    GetComponent<Animator>().Play(playerTwoChar + "WalkSuper");
                }
            }
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0));
        }
        if (Input.GetKey(keyRight))
        {
            if (sizeType == 1 && onGround)
            {
                if (gameObject.name.Contains("1"))
                {
                    GetComponent<Animator>().Play(playerOneChar + "Walk");
                }
                else
                {
                    GetComponent<Animator>().Play(playerTwoChar + "Walk");
                }
            }
            else if (sizeType == 2 && onGround)
            {
                if (gameObject.name.Contains("1"))
                {
                    GetComponent<Animator>().Play(playerOneChar + "WalkSuper");
                }
                else
                {
                    GetComponent<Animator>().Play(playerTwoChar + "WalkSuper");
                }
            }
            GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0));
        }
        if (Input.GetKeyDown(keyThrust) && onGround)
        {
            if (sizeType == 1)
            {
                if (gameObject.name.Contains("1"))
                {
                    GetComponent<Animator>().Play(playerOneChar + "Attack");
                }
                else
                {
                    GetComponent<Animator>().Play(playerTwoChar + "Attack");
                }
            }
            else if (sizeType == 2)
            {
                if (gameObject.name.Contains("1"))
                {
                    GetComponent<Animator>().Play(playerOneChar + "AttackSuper");
                }
                else
                {
                    GetComponent<Animator>().Play(playerTwoChar + "AttackSuper");
                }
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
                if (gameObject.name.Contains("1"))
                {
                    GetComponent<Animator>().Play(playerOneChar + "Attack");
                }
                else
                {
                    GetComponent<Animator>().Play(playerTwoChar + "Attack");
                }
            }
            else if (sizeType == 2)
            {
                if (gameObject.name.Contains("1"))
                {
                    GetComponent<Animator>().Play(playerOneChar + "AttackSuper");
                }
                else
                {
                    GetComponent<Animator>().Play(playerTwoChar + "AttackSuper");
                }
            }
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
            onGround = false;
        }
        if (onGround && !Input.GetKey(keyLeft) && !Input.GetKey(keyRight))
        {
            if (sizeType == 1)
            {
                if (gameObject.name.Contains("1"))
                {
                    GetComponent<Animator>().Play(playerOneChar + "Idle");
                }
                else
                {
                    GetComponent<Animator>().Play(playerTwoChar + "Idle");
                }
            }
            else if (sizeType == 2)
            {
                if (gameObject.name.Contains("1"))
                {
                    GetComponent<Animator>().Play(playerOneChar + "IdleSuper");
                }
                else
                {
                    GetComponent<Animator>().Play(playerTwoChar + "IdleSuper");
                }
            }
        }
        if (transform.position.y < -8)
        {
            showVictory = true;
            victoryText.GetComponent<Image>().enabled = showVictory;
            victoryText.GetComponent<Image>().sprite = opponent.GetComponent<CharacterMoveScript>().victoryMsg;
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
