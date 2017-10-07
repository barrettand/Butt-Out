using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterData : MonoBehaviour {
    public GameObject startButton;
    public string playerOneChar, playerTwoChar;
    public bool playerOneChosen, bothPlayersChosen = false;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void SelectChar (string buttonPressed)
    {
        if (playerOneChosen == true && bothPlayersChosen == false)
        {
            bothPlayersChosen = true;
            playerTwoChar = buttonPressed;
            GameObject.Find(buttonPressed).GetComponent<Button>().interactable = false;
            startButton.GetComponent<Button>().interactable = true;
        }
        if (playerOneChosen == false && bothPlayersChosen == false)
        {
            playerOneChosen = true;
            playerOneChar = buttonPressed;
            GameObject.Find(buttonPressed).GetComponent<Button>().interactable = false;
        }
    }
}
