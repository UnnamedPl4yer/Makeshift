using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static float volume;

    public void PlayGame()
    {
        SceneManager.LoadScene("StartCutscene");
    }

    public void SetVolume(float vol)
    {
        volume = vol;
    }

    public void Credits()
    {

    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
