using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinTheGame : MonoBehaviour
{
    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && GameObject.Find("Enemy(Clone)") == null)
        {
            ShowYouWin();
        }
    }
    void ShowYouWin()
    {
        winText.SetActive(true);
        Time.timeScale = 0;
        
    }
}
