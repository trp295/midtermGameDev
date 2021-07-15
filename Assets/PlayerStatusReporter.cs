using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

//in playerMovement write
//PlayerStatusReporter.playerJumped?.Invoke(); inside of the keycode space if statement

public class PlayerStatusReporter : MonoBehaviour
{
    TextMeshProUGUI textObject;

    public static Action playerJumped;

    private void Awake()
    {
        playerJumped += OnPlayerJumped;
        textObject = GetComponent<TextMeshProUGUI>();
    }

    void OnPlayerJumped()
    {
        textObject.text = "Player has jumped";
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
