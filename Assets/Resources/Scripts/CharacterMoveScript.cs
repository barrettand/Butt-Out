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
    public AudioSource sounds, footstepsP1, footstepsP2, victoryMusic, collisions;
    public AudioClip footstep, buttonclick, falloffscreen, victory, pickupyarn, buttsound1, buttsound2, buttsound3, buttsound4;
    public AudioClip[] buttsounds;
    bool flag1, flag2;
    // Use this for initialization

    void Start ()
    {
        InvokeRepeating("FootstepsP1", 0, 0.2f);
        InvokeRepeating("FootstepsP2", 0, 0.2f);
        flag1 = true;
        flag2 = true;
        buttsounds = new AudioClip[4];
        buttsounds[0] = buttsound1;
        buttsounds[1] = buttsound2;
        buttsounds[2] = buttsound3;
        buttsounds[3] = buttsound4;
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
        else if (gameObject.name.Contains("1") && (playerOneChar.Contains("Fanny") || playerOneChar.Contains("Derrie")))
        {
            transform.localScale = new Vector3(1.6f * dir, 1.6f, transform.localScale.z);
            GetComponent<BoxCollider2D>().size = new Vector2(0.6f, 1.5f);
        }
        else if (gameObject.name.Contains("1") && (playerOneChar.Contains("Hot")))
        {
            transform.localScale = new Vector3(1.8f * dir, 1.8f, transform.localScale.z);
            GetComponent<BoxCollider2D>().size = new Vector2(0.55f, 1.35f);
        }
        else if (gameObject.name.Contains("2") && (playerTwoChar.Contains("BGB") || playerTwoChar.Contains("Megalo")))
        {
            transform.localScale = new Vector3(3 * dir, transform.localScale.y, transform.localScale.z);
        }
        else if (gameObject.name.Contains("2") && (playerTwoChar.Contains("Fanny") || playerTwoChar.Contains("Derrie")))
        {
            transform.localScale = new Vector3(1.6f * dir, 1.6f, transform.localScale.z);
            GetComponent<BoxCollider2D>().size = new Vector2(0.6f, 1.5f);
        }
        else if (gameObject.name.Contains("2") && (playerTwoChar.Contains("Hot")))
        {
            transform.localScale = new Vector3(1.8f * dir, 1.8f, transform.localScale.z);
            GetComponent<BoxCollider2D>().size = new Vector2(0.55f, 1.35f);
        }
        if (Input.GetKey(keyLeft))
        {
            if (sizeType == 1 && onGround)
            {
                if (gameObject.name.Contains("1"))
                {
                    footstepsP1.volume = 1;
                    GetComponent<Animator>().Play(playerOneChar + "Walk");
                }
                else
                {
                    footstepsP2.volume = 1;
                    GetComponent<Animator>().Play(playerTwoChar + "Walk");
                }
            }
            else if (sizeType == 2 && onGround)
            {
                if (gameObject.name.Contains("1"))
                {
                    footstepsP1.volume = 1;
                    GetComponent<Animator>().Play(playerOneChar + "WalkSuper");
                }
                else
                {
                    footstepsP2.volume = 1;
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
                    footstepsP1.volume = 1;
                    GetComponent<Animator>().Play(playerOneChar + "Walk");
                }
                else
                {
                    footstepsP2.volume = 1;
                    GetComponent<Animator>().Play(playerTwoChar + "Walk");
                }
            }
            else if (sizeType == 2 && onGround)
            {
                if (gameObject.name.Contains("1"))
                {
                    footstepsP1.volume = 1;
                    GetComponent<Animator>().Play(playerOneChar + "WalkSuper");
                }
                else
                {
                    footstepsP2.volume = 1;
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
                    footstepsP1.volume = 0;
                    GetComponent<Animator>().Play(playerOneChar + "Idle");
                }
                else
                {
                    footstepsP2.volume = 0;
                    GetComponent<Animator>().Play(playerTwoChar + "Idle");
                }
            }
            else if (sizeType == 2)
            {
                if (gameObject.name.Contains("1"))
                {
                    footstepsP1.volume = 0;
                    GetComponent<Animator>().Play(playerOneChar + "IdleSuper");
                }
                else
                {
                    footstepsP1.volume = 0;
                    GetComponent<Animator>().Play(playerTwoChar + "IdleSuper");
                }
            }
        }
        if (transform.position.y < -8)
        {
            if (flag1)
            {
                sounds.clip = falloffscreen;
                sounds.Play();
                flag1 = false;
            }
            if (flag2)
            {
                victoryMusic.Play();
                flag2 = false;
            }
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
        sounds.clip = buttonclick;
        sounds.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void RevertSize()
    {
        sizeType = 1;
    }

    public void FootstepsP1()
    {
        footstepsP1.Play();
    }
    public void FootstepsP2()
    {
        footstepsP2.Play();
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Arena") {
            onGround = true;
        }
        if (col.gameObject.GetComponent<Rigidbody2D>() && col.gameObject.name.Contains("Player"))
        {
            collisions.clip = buttsounds[Mathf.RoundToInt(Random.Range(0, 3))];
            collisions.Play();
            GetComponent<Rigidbody2D>().AddForce(new Vector2(buttforce * 0.5f * -dir, 0));
            buttforce = 0;
        }
        if (col.gameObject.name.Contains("Yarn"))
        {
            sounds.clip = pickupyarn;
            sounds.Play();
            Destroy(col.gameObject);
            sizeType = 2;
            Invoke("RevertSize", 5.0f);
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Rigidbody2D>())
        {
            collisions.clip = buttsounds[Mathf.RoundToInt(Random.Range(0, 3))];
            collisions.Play();
            GetComponent<Rigidbody2D>().AddForce(new Vector2(buttforce * 0.5f * -dir, 0));
            buttforce = 0;
        }
    }
}
