using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class gettingInput : MonoBehaviour
{
    
    
    public GameObject safeCodeInput;
    public GameObject stateManager;
    public GameObject dialogueManager;


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //safeCodeInput.GetComponent<TMP_InputField>().onEndEdit.AddListener(displayInput);
        
        
    }

    public void displayInput(string input)
    {
        Debug.Log(input);
        if(input == "0217")
        {
            Debug.Log("CORRECT PASSWORD");
            stateManager.GetComponent<StateManager>().batteryFound = true;
            
            //dialogueManager.GetComponent<DialogueManager>().safecurrentMessage++;
            dialogueManager.GetComponent<DialogueManager>().SafeDialogue(); //finsih the first case

        } else
        {
            stateManager.GetComponent<StateManager>().wrongCheck = true;
            
            //dialogueManager.GetComponent<DialogueManager>().safecurrentMessage++;
            dialogueManager.GetComponent<DialogueManager>().SafeDialogue(); //finsih the first case

        }
        
        FinishSafe();
        
        

    }

    public void FinishSafe()
    {
        //dialogueManager.GetComponent<DialogueManager>().SafeDialogue(); //finsih the first case
        dialogueManager.GetComponent<DialogueManager>().SafeDialogue(); //play the correct case dialogue for answering the safe
        
        
        safeCodeInput.SetActive(false);
    }

}
