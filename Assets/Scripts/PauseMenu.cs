using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused)
            {
                pauseMenuUI.gameObject.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
            }
            else
            {
                resume();
            }
            
        } 
    }

    public void resume()
    {
        Debug.Log("resume is pressed");
        pauseMenuUI.gameObject.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;

    }

    public void quitGame()
    {
        SceneManager.LoadScene("TitleScreen");
        Time.timeScale = 1;
        Application.Quit();
    }
}
