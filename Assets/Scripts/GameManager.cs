using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    AudioSource audioSource;
    [SerializeField]
    AudioClip[] audioClips;
    
    private void Awake()
    {
        if(gameManager != null)
        {
            Destroy(this);
        }
        else
        {
            gameManager = new GameManager();
        }

        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeBackgoundMusic()
    {
        var currentScene = SceneManager.GetActiveScene();
        
        switch (currentScene.name)
        {
            case "GameStartScene":
                audioSource.clip = audioClips[0];
                break;
            case "BattleScene":
                audioSource.clip = audioClips[Random.Range(2,7)];
                break;
            case "LoadingScene":
                audioSource.clip = audioClips[1];
                break;
        }

        audioSource.Play();
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        ChangeBackgoundMusic();
    }
}
