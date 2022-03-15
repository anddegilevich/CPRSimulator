using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject GameUI;
    public GameObject PauseUI;
    public KeyCode Pause;
    public GameObject VCam;
    public static bool GameIsPaused = false;

    // Update is called once per frame
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Update()
    {
        if (Input.GetKeyDown(Pause))
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        GameIsPaused = true;
        PauseUI.SetActive(true);
        VCam.SetActive(false);
        GameUI.SetActive(false);
        Time.timeScale = 0.001f;
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GameIsPaused = false;
        PauseUI.SetActive(false);
        VCam.SetActive(true);
        GameUI.SetActive(true);
        Time.timeScale = 1f;
    }
}
