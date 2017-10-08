using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public AudioSource sounds;
    public AudioClip buttonclick;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Character Manager") && SceneManager.GetActiveScene().name.Contains("Main"))
        {
            Destroy(GameObject.Find("Character Manager"));
        }
        Time.timeScale = 1;
    }

    public void StartButton()
    {
        sounds.clip = buttonclick;
        sounds.Play();
        SceneManager.LoadScene("CharacterSelection");
    }

    public void ExitButton()
    {
        sounds.clip = buttonclick;
        sounds.Play();
        Debug.Break();
        Application.Quit();
    }

    public void BackButton()
    {
        sounds.clip = buttonclick;
        sounds.Play();
        SceneManager.LoadScene("MainMenu");
    }
    
    public void PlayButton()
    {
        sounds.clip = buttonclick;
        sounds.Play();
        SceneManager.LoadScene("TestScene");
    }
}
