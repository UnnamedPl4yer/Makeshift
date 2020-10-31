using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pausemenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && paused)
            Resume();
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
            Pause();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pausemenu.SetActive(false);
        paused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pausemenu.SetActive(true);
        paused = true;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
