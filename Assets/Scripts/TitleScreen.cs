using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleScreen : MonoBehaviour { 

    public void PlayButton()
    {
        SceneManager.LoadScene("Conall Scene");

    }

    public void QuitButton()
    {
        Application.Quit();
    }
 
}
