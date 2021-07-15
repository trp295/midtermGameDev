using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    public GameObject stateManager;
    public AudioSource gameMusic;
    public GameObject endMusicPlayer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (stateManager.GetComponent<StateManager>().endScreen)
        {
            gameMusic.Stop();
            endMusicPlayer.SetActive(true);
            
        }
    }
}
