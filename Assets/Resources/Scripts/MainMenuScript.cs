﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void StartButton()
    {
        SceneManager.LoadScene("CharacterSelection");
    }

    public void ExitButton()
    {
        Debug.Break();
        Application.Quit();
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
