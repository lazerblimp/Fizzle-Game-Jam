using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private AudioSource audioSource;
    public float playTime;
    private bool playingSound;

    void Start()
    {
        playingSound = true;
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayGame()
    {
        StartCoroutine(PlaySound());
    }

    void Update()
    {
        if (playingSound == false)
        {
            SceneManager.LoadScene("Level1");
        }
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    IEnumerator PlaySound()
    {
        audioSource.Play();
        yield return new WaitForSeconds(playTime);
        playingSound = false;

    }
}
