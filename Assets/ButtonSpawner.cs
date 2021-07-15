using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ButtonSpawner : MonoBehaviour
{

    public GameObject buttonPrefab;
    public Canvas UICanvas;
    public GameObject dialogueManager;
    

    int latestButtonID;

    public float hPosition;
    public string yn;
    public int bc;

    public int activeButtons = 0;

    public bool buttonsExist = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void SpawnAButton(float hPosition, string yn, int latestButtonID, int bc)
    {
        
        GameObject newButtonGO = Instantiate(buttonPrefab, UICanvas.transform);
        Button newButton = newButtonGO.GetComponent<Button>();
        RectTransform buttonTransform = newButtonGO.GetComponent<RectTransform>();
        TextMeshProUGUI buttonText = newButtonGO.GetComponentInChildren<TextMeshProUGUI>();
        ButtonInfo buttonInfo = newButtonGO.GetComponentInChildren<ButtonInfo>();

        buttonInfo.buttonID = latestButtonID;

        // float randomYPosition = Random.Range(-300.0f, 300.0f);
        // float randomXPosition = Random.Range(-300.0f, 300.0f);
        //buttonTransform.anchoredPosition = new Vector2(randomXPosition, randomYPosition);
        
        buttonTransform.anchoredPosition = new Vector2(hPosition, 0f);
        newButton.name = "button" + latestButtonID;


        buttonText.text = yn;
        newButton.onClick.AddListener(() => PressedButton(buttonInfo.buttonID, bc));
        buttonsExist = true;
        activeButtons++;


    }

    public void PressedButton(int buttonID, int bc)
    {
        Debug.Log("pressed a button with ID" + buttonID);
        

        if(bc == 0)
        {
            switch(buttonID)
            {
                case 0:
                    dialogueManager.GetComponent<DialogueManager>().bookcurrentMessage++;

                break;

                case 1:
                    dialogueManager.GetComponent<DialogueManager>().bookcurrentMessage += 2;
                    
                break;
            }
            
            dialogueManager.GetComponent<DialogueManager>().BookDialogue();
            dialogueManager.GetComponent<DialogueManager>().bookcurrentMessage++;
        } else if (bc == 1)
        {
            switch(buttonID)
            {
                case 0:
                    dialogueManager.GetComponent<DialogueManager>().cabinetcurrentMessage++;

                break;

                case 1:
                    dialogueManager.GetComponent<DialogueManager>().cabinetcurrentMessage += 5;
                    
                break;
            }
            
            dialogueManager.GetComponent<DialogueManager>().CabinetDialogue();
            dialogueManager.GetComponent<DialogueManager>().cabinetcurrentMessage++;
        }
            

        DestroyAllButtons();


    }

    public void DestroyAllButtons()
    {
        buttonsExist = false;
        activeButtons = 0;
        Destroy(GameObject.Find("button0"));
        Destroy(GameObject.Find("button1"));
        
    }
}
