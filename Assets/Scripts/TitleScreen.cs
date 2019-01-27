using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {

    public GameObject creditPanel;
    public void PlayButton()
    {
        SceneManager.LoadScene("Conall Scene");
    }

    public void CreditButton()
    {
        creditPanel.SetActive(true);
        Debug.Log("activate credit panel");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
 
}
