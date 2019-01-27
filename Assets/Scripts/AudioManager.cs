using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioSource musicSource;

    public static AudioManager instance = null;
    public float lowPitchRange = .3f;
    public float highPitchRange = 1f;

    private string sceneName;
    private string prevSceneName;
    private Scene currentScene;
    private bool playing = false;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        prevSceneName = sceneName;
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    private void Update()
    {
        if (sceneName == "TitleScreen" && !playing)
        {
            PlayMusic(menuMusic);
            playing = true;
        }
        else if (sceneName == "Conall Scene" && !playing)
        {
            Debug.Log("here");
            PlayMusic(gameMusic);
            Debug.Log("playing");
            playing = true;
        }

        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (sceneName != prevSceneName)
        {
            playing = false;
            prevSceneName = sceneName;
        }
    }

}
