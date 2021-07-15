using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class DialogueManager : MonoBehaviour
{

    public GameObject textbox;
    public GameObject textBackground;
    public Canvas UICanvas;

    GameObject newMessage;
    GameObject boxBackground;
    public GameObject stateManager;
    public GameObject buttonSpawner;
    public GameObject safeCodeInput;
    public GameObject startOverlay;
    public GameObject endOverlay;

    public AudioSource audioSource;
    public AudioClip textboxAdvance;
    public AudioClip correctPassword;
    public AudioClip incorrectPassword;


    int currentMessage = 0;
    int katycurrentMessage = 0;
    int joannacurrentMessage = 0;
    int kwasicurrentMessage = 0;
    int spencercurrentMessage = 0;
    public int bookcurrentMessage = 0;
    public int cabinetcurrentMessage = 0;
    int dadcurrentMessage = 0;
    public int safecurrentMessage = 0;
    int endcurrentMessage = 0;


    int katymessageLimit = 3;
    int joannamessageLimit = 4;
    int kwasimessageLimit = 2;
    int spencermessageLimit = 2;
    int bookmessageLimit = 2;
    int cabinetmessageLimit = 2;
    int dadmessageLimit = 3;
    int safemessageLimit = 2;

    float textboxXPosition = 0.0f;
    float textboxYPosition = -150.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

     void Update()
    {
        if (stateManager.GetComponent<StateManager>().playScreen)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {   
                
                if(stateManager.GetComponent<StateManager>().katyTalking)
                {
                    KatyDialogue();
                    

                } else if(stateManager.GetComponent<StateManager>().joannaTalking)
                {
                    JoannaDialogue();
                } else if(stateManager.GetComponent<StateManager>().kwasiTalking)
                {
                    KwasiDialogue();
                } else if(stateManager.GetComponent<StateManager>().spencerTalking)
                {
                    SpencerDialogue();
                } else if(stateManager.GetComponent<StateManager>().bookcaseChecking)
                {
                    BookDialogue();
                } else if(stateManager.GetComponent<StateManager>().cabinetChecking)
                {
                    CabinetDialogue();
                } else if(stateManager.GetComponent<StateManager>().dadTalking)
                {
                    DadDialogue();
                } else if(stateManager.GetComponent<StateManager>().safeChecking)
                {
                    SafeDialogue();
                }

            }

            if (newMessage == null)
                {
                    AllowMoving();
                    
                }
           
        } else if (stateManager.GetComponent<StateManager>().startScreen)
        {   
            
            if(Input.GetKeyDown(KeyCode.Space))
            {   
                startOverlay.SetActive(false);
                SpawnDialogue();

            
            }
            
           
        } else if (stateManager.GetComponent<StateManager>().endScreen)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {   
           
                EndDialogue();

            
            }
        }

        
        
    }

    public void SpawnDialogue()
    {   
        if(newMessage != null) //destroy previous message
        {
            Destroy(newMessage);
        }
        if(boxBackground != null) //destroy previous boxbackground
        {
            Destroy(boxBackground);
        }
        if (stateManager.GetComponent<StateManager>().finishedCutscene1)
            {
                stateManager.GetComponent<StateManager>().gameState = 1;
            }
        if(currentMessage < 15) 
        {
        stateManager.GetComponent<StateManager>().cantMove = true;
        audioSource.PlayOneShot(textboxAdvance);

        newMessage = Instantiate(textbox, UICanvas.transform);
        boxBackground = Instantiate(textBackground, UICanvas.transform);
        TextMeshProUGUI newMessageText = newMessage.GetComponent<TextMeshProUGUI>();
        RectTransform textTransform = newMessage.GetComponent<RectTransform>();
        RectTransform boxTransform = boxBackground.GetComponent<RectTransform>();
        TextInfo textInfo = newMessage.GetComponentInChildren<TextInfo>();

        textInfo.messageID = currentMessage;

        textTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);
        boxTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);

        newMessage.name = "message" + textInfo.messageID;
        boxBackground.name = "box" + textInfo.messageID;
        
        switch(currentMessage) 
        {
            case 0:
                newMessageText.text = "Joanna:" + "\r\n" + "Woo!";
                
            break;
            
            case 1:
                newMessageText.text = "Joanna:" + "\r\n" + "Okay then,";
                
                
            break;

            case 2:
                newMessageText.text = "Joanna:" + "\r\n" + "I’m glad we could agree on something.";
                
                
            break;

            case 3:
                newMessageText.text = "Spencer:" + "\r\n" + "I'm really bad at Rockband,";
                
            break;

            case 4:
                newMessageText.text = "Spencer:" + "\r\n" + "but I will do my best.";
                
            break;

            case 5:
                newMessageText.text = "Katy:" + "\r\n" + "Don’t worry, we can sing.";
                
            break;

            case 6:
                newMessageText.text = "Katy:" + "\r\n" + "It’ll be great.";
                
            break;

            case 7:
                newMessageText.text = "Joanna:" + "\r\n" + "Wait guys, all the controllers are empty.";
                
            break;

            case 8:
                newMessageText.text = "Katy:" + "\r\n" + "Oh god.";
                
            break;

            case 9:
                newMessageText.text = "Katy:" + "\r\n" + "Now we gotta find like 6 batteries.";
                
            break;

            case 10:
                newMessageText.text = "Kwasi:" + "\r\n" + "You guys don’t have batteries?";
                
            break;

            case 11:
                newMessageText.text = "Katy:" + "\r\n" + "Oh who ever has batteries?";
                
            break;

            case 12:
                newMessageText.text = "Kwasi:" + "\r\n" + "People who buy batteries.";
                
            break;

            case 13:
                newMessageText.text = "Katy:" + "\r\n" + "Ha-ha.";
                
            break;

            case 14:
                newMessageText.text = "Kwasi:" + "\r\n" + "Come on, let’s start looking.";
                stateManager.GetComponent<StateManager>().finishedCutscene1 = true;

            break;



        }

        currentMessage++;       
        } else
        {
            stateManager.GetComponent<StateManager>().cantMove = false;

        }


    }

    public void EndDialogue()
    {   
        if(newMessage != null) //destroy previous message
        {
            Destroy(newMessage);
        }
        if(boxBackground != null) //destroy previous boxbackground
        {
            Destroy(boxBackground);
        }
        // if (stateManager.GetComponent<StateManager>().finishedCutscene1)
        //     {
        //         stateManager.GetComponent<StateManager>().gameState = 1;
        //     }
        if(endcurrentMessage < 8) 
        {
        stateManager.GetComponent<StateManager>().cantMove = true;
        audioSource.PlayOneShot(textboxAdvance);

        newMessage = Instantiate(textbox, UICanvas.transform);
        boxBackground = Instantiate(textBackground, UICanvas.transform);
        TextMeshProUGUI newMessageText = newMessage.GetComponent<TextMeshProUGUI>();
        RectTransform textTransform = newMessage.GetComponent<RectTransform>();
        RectTransform boxTransform = boxBackground.GetComponent<RectTransform>();
        endText endText = newMessage.GetComponentInChildren<endText>();

        endText.endmessageID = endcurrentMessage;

        textTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);
        boxTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);

        newMessage.name = "message" + endText.endmessageID;
        boxBackground.name = "box" + endText.endmessageID;
        
        switch(endcurrentMessage) 
        {
            case 0:
                newMessageText.text = "Kwasi:" + "\r\n" + "Yes!";
                
            break;
            
            case 1:
                newMessageText.text = "Kwasi:" + "\r\n" + "We can finally play!";
                
                
            break;

            case 2:
                newMessageText.text = "Spencer:" + "\r\n" + "I'm gonna try to play guitar!";
                
                
            break;

            case 3:
                newMessageText.text = "Spencer:" + "\r\n" + "Because why not?";
                
            break;

            case 4:
                newMessageText.text = "Katy:" + "\r\n" + "I'm gonna sing the three-part harmonies";
                
            break;

            case 5:
                newMessageText.text = "Katy:" + "\r\n" + "by myself!";
                
            break;

            case 6:
                newMessageText.text = "Joanna:" + "\r\n" + "I don't know if that's gonna work,";
                
            break;
           
            case 7:
                newMessageText.text = "Joanna:" + "\r\n" + "but I love the energy!";
                //stateManager.GetComponent<StateManager>().finishedCutscene1 = true;

            break;

        }

        endcurrentMessage++;       
        } else
        {
            endOverlay.SetActive(true);

        }

    }

    

    public void KatyDialogue()
    {
            stateManager.GetComponent<StateManager>().cantMove = true;

        switch(stateManager.GetComponent<StateManager>().katyState)
        {
            case 0:
                katymessageLimit = 3;
            break;

            case 1:
                katymessageLimit = 5;

            break;

            case 2:
                katymessageLimit = 4;

            break;
        }
        
        if(newMessage != null) //destroy previous message
        {
            Destroy(newMessage);
        }
        if(boxBackground != null) //destroy previous boxbackground
        {
            Destroy(boxBackground);
        }
        if(katycurrentMessage < katymessageLimit) 
        {
        audioSource.PlayOneShot(textboxAdvance);

        newMessage = Instantiate(textbox, UICanvas.transform);
        boxBackground = Instantiate(textBackground, UICanvas.transform);
        TextMeshProUGUI newMessageText = newMessage.GetComponent<TextMeshProUGUI>();
        RectTransform textTransform = newMessage.GetComponent<RectTransform>();
        RectTransform boxTransform = boxBackground.GetComponent<RectTransform>();
        katyText katyText = newMessage.GetComponentInChildren<katyText>();

        katyText.katymessageID = katycurrentMessage;

        textTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);
        boxTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);

        newMessage.name = "message" + katyText.katymessageID;
        boxBackground.name = "box" + katyText.katymessageID;
        
        switch(stateManager.GetComponent<StateManager>().katyState)
        {   
            case 0:
                switch(katycurrentMessage) 
                {
                    case 0:
                        newMessageText.text = "Katy:" + "\r\n" + "The ones in the drawer might be half dead,";
                        
                    break;
                    
                    case 1:
                        newMessageText.text = "Katy:" + "\r\n" + "but we can make it work!";
                        
                        
                    break;

                    case 2:

                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        katycurrentMessage = -1;
                    break;
                }
            break;

            case 1:
                switch(katycurrentMessage) 
                {
                    case 0:
                        newMessageText.text = "Katy:" + "\r\n" + "Sorry.";
                        
                    break;

                    case 1:
                        newMessageText.text = "Katy:" + "\r\n" + "I can’t remember the combination for the safe.";
                        
                    break;

                    case 2:
                        newMessageText.text = "Katy:" + "\r\n" + "I think I wrote it down though.";
                        
                    break;

                    case 3:
                        newMessageText.text = "Katy:" + "\r\n" + "Maybe check the bookcase?";
                        
                    break;

                    case 4:
                        stateManager.GetComponent<StateManager>().spokeKaty = true;

                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        katycurrentMessage = -1;
                    break;
                }
            break;

            case 2:
                switch(katycurrentMessage) 
                {
                    case 0:
                        newMessageText.text = "Katy:" + "\r\n" + "Oh, there was only one number on the paper?";
                        
                    break;

                    case 1:
                        newMessageText.text = "Katy:" + "\r\n" + "That's awkward.";
                        
                    break;

                    case 2:
                        newMessageText.text = "Katy:" + "\r\n" + "I guess it must have gotten ripped up.";
                        
                    break;

                    case 3:
                        
                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        katycurrentMessage = -1;
                    break;
                }
            break;
        }
        katycurrentMessage++; 

        } 

    }

    public void JoannaDialogue()
    {
        stateManager.GetComponent<StateManager>().cantMove = true;
        switch(stateManager.GetComponent<StateManager>().joannaState)
        {
            case 0:
                joannamessageLimit = 4;
            break;

            case 1:
                joannamessageLimit = 3;

            break;

            case 2:
                joannamessageLimit = 4;

            break;
        }

        if(newMessage != null) //destroy previous message
        {
            Destroy(newMessage);
        }
        if(boxBackground != null) //destroy previous boxbackground
        {
            Destroy(boxBackground);
        }
        if(joannacurrentMessage < joannamessageLimit) 
        {
        audioSource.PlayOneShot(textboxAdvance);
            
        newMessage = Instantiate(textbox, UICanvas.transform);
        boxBackground = Instantiate(textBackground, UICanvas.transform);
        TextMeshProUGUI newMessageText = newMessage.GetComponent<TextMeshProUGUI>();
        RectTransform textTransform = newMessage.GetComponent<RectTransform>();
        RectTransform boxTransform = boxBackground.GetComponent<RectTransform>();
        joannaText joannaText = newMessage.GetComponentInChildren<joannaText>();

        joannaText.joannamessageID = joannacurrentMessage;

        textTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);
        boxTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);

        newMessage.name = "message" + joannaText.joannamessageID;
        boxBackground.name = "box" + joannaText.joannamessageID;
        
        switch(stateManager.GetComponent<StateManager>().joannaState)
        {   
            case 0:
                switch(joannacurrentMessage) 
                {
                    case 0:
                        newMessageText.text = "Joanna:" + "\r\n" + "I’ll plug in the game if it means that";
                        
                    break;
                        
                    case 1:
                        newMessageText.text = "Joanna:" + "\r\n" + "I don’t have to look for batteries.";
                        
                    break;

                    case 2:
                        newMessageText.text = "Joanna:" + "\r\n" + ";D";
                            
                    break;

                    case 3:
                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        joannacurrentMessage = -1;
                    break;
                    }
            break;

            case 1:
                switch(joannacurrentMessage) 
                {
                    case 0:
                        newMessageText.text = "Joanna:" + "\r\n" + "I have no idea what the combination is.";
                        
                    break;
                        
                    case 1:
                        newMessageText.text = "Joanna:" + "\r\n" + "Sorry :(";
                        
                    break;

                    case 2:
                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        joannacurrentMessage = -1;
                    break;
                    }
            break;

            case 2:
                switch(joannacurrentMessage) 
                {
                    case 0:
                        newMessageText.text = "Joanna:" + "\r\n" + "You found a note in the cabinet?";
                        
                    break;
                        
                    case 1:
                        newMessageText.text = "Joanna:" + "\r\n" + "Haha, oh yeah I totally wrote that. :P";
                        
                    break;

                    case 2:
                        newMessageText.text = "Joanna:" + "\r\n" + "You're welcome!";
                        
                    break;

                    case 3:
                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        joannacurrentMessage = -1;
                    break;
                    }
            break;
            
        }
        joannacurrentMessage++;       
        } 

    }

    public void KwasiDialogue()
    {
        stateManager.GetComponent<StateManager>().cantMove = true;
        switch(stateManager.GetComponent<StateManager>().kwasiState)
        {
            case 0:
                kwasimessageLimit = 2;
            break;

            case 1:
                kwasimessageLimit = 8;

            break;
        }
        if(newMessage != null) //destroy previous message
        {
            Destroy(newMessage);
        }
        if(boxBackground != null) //destroy previous boxbackground
        {
            Destroy(boxBackground);
        }
        if(kwasicurrentMessage < kwasimessageLimit) 
        {
        audioSource.PlayOneShot(textboxAdvance);
            
        newMessage = Instantiate(textbox, UICanvas.transform);
        boxBackground = Instantiate(textBackground, UICanvas.transform);
        TextMeshProUGUI newMessageText = newMessage.GetComponent<TextMeshProUGUI>();
        RectTransform textTransform = newMessage.GetComponent<RectTransform>();
        RectTransform boxTransform = boxBackground.GetComponent<RectTransform>();
        kwasiText kwasiText = newMessage.GetComponentInChildren<kwasiText>();

        kwasiText.kwasimessageID = kwasicurrentMessage;

        textTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);
        boxTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);

        newMessage.name = "message" + kwasiText.kwasimessageID;
        boxBackground.name = "box" + kwasiText.kwasimessageID;
        
        switch(stateManager.GetComponent<StateManager>().kwasiState)
        {
            case 0:
                switch(kwasicurrentMessage) 
                {
                    case 0:
                        newMessageText.text = "Kwasi:" + "\r\n" + "We’ll look in the drawers over here.";
                        
                    break;

                    case 1:
                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        kwasicurrentMessage = -1;
                    break;
                }
            break;

            case 1:
                switch(kwasicurrentMessage) 
                {
                    case 0:
                        newMessageText.text = "Kwasi:" + "\r\n" + "I don’t remember the numbers.";
                        
                    break;

                    case 1:
                        newMessageText.text = "Kwasi:" + "\r\n" + "But I do remember that if you multiply";
                        
                    break;

                    case 2:
                        newMessageText.text = "Kwasi:" + "\r\n" + "the first number by the second number,";
                        
                    break;

                    case 3:
                        newMessageText.text = "Kwasi:" + "\r\n" + "the result will be equal to the same value";
                        
                    break;

                    case 4:
                        newMessageText.text = "Kwasi:" + "\r\n" + "as the result of multiplying";
                        
                    break;

                    case 5:
                        newMessageText.text = "Kwasi:" + "\r\n" + "the first number by itself.";
                        
                    break;

                    case 6:
                        newMessageText.text = "Kwasi:" + "\r\n" + "I thought that was interesting.";
                        
                    break;

                    case 7:
                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        kwasicurrentMessage = -1;
                    break;
                }
            break;
        }
        kwasicurrentMessage++;       
        } 

    }
    
    public void SpencerDialogue()
    {
        stateManager.GetComponent<StateManager>().cantMove = true;
        switch(stateManager.GetComponent<StateManager>().spencerState)
        {
            case 0:
                spencermessageLimit = 3;
            break;

            case 1:
                spencermessageLimit = 6;

            break;
        }
        if(newMessage != null) //destroy previous message
        {
            Destroy(newMessage);
        }
        if(boxBackground != null) //destroy previous boxbackground
        {
            Destroy(boxBackground);
        }
        if(spencercurrentMessage < spencermessageLimit) 
        {
        audioSource.PlayOneShot(textboxAdvance);
            
        newMessage = Instantiate(textbox, UICanvas.transform);
        boxBackground = Instantiate(textBackground, UICanvas.transform);
        TextMeshProUGUI newMessageText = newMessage.GetComponent<TextMeshProUGUI>();
        RectTransform textTransform = newMessage.GetComponent<RectTransform>();
        RectTransform boxTransform = boxBackground.GetComponent<RectTransform>();
        spencerText spencerText = newMessage.GetComponentInChildren<spencerText>();

        spencerText.spencermessageID = spencercurrentMessage;

        textTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);
        boxTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);

        newMessage.name = "message" + spencerText.spencermessageID;
        boxBackground.name = "box" + spencerText.spencermessageID;
        
        switch(stateManager.GetComponent<StateManager>().spencerState)
        {
            case 0:
                switch(spencercurrentMessage) 
                {
                    case 0:
                        newMessageText.text = "Spencer:" + "\r\n" + "What about the TV remote?";
                        
                    break;

                    case 1:
                        newMessageText.text = "Spencer:" + "\r\n" + "You could get some batteries from there.";
                        
                    break;

                    case 2:
                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        spencercurrentMessage = -1;
                    break;
                }
            break;

            case 1:
                switch(spencercurrentMessage) 
                {
                    case 0:
                        newMessageText.text = "Spencer:" + "\r\n" + "The safe combo?";
                        
                    break;

                    case 1:
                        newMessageText.text = "Spencer:" + "\r\n" + "Oof.";
                        
                    break;

                    case 2:
                        newMessageText.text = "Spencer:" + "\r\n" + "I'm pretty sure the second number was 2.";
                        
                    break;

                    case 3:
                        newMessageText.text = "Spencer:" + "\r\n" + "But I don't remember any of the others.";
                        
                    break;

                    case 4:
                        newMessageText.text = "Spencer:" + "\r\n" + "Is that helpful?";
                        
                    break;

                    case 5:
                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        spencercurrentMessage = -1;
                    break;
                }
            break;
        }
        spencercurrentMessage++;       
        } 
    }

    public void BookDialogue()
    {
                //Debug.Log(bookcurrentMessage);
        stateManager.GetComponent<StateManager>().cantMove = true;
        switch(stateManager.GetComponent<StateManager>().bookState)
        {
            case 0:
                bookmessageLimit = 2;
            break;

            case 1:
                bookmessageLimit = 4;

            break;
        }
        if(newMessage != null) //destroy previous message
        {
            Destroy(newMessage);
        }
        if(boxBackground != null) //destroy previous boxbackground
        {
            Destroy(boxBackground);
        }
        if(bookcurrentMessage < bookmessageLimit) 
        {
            audioSource.PlayOneShot(textboxAdvance);
        newMessage = Instantiate(textbox, UICanvas.transform);
        boxBackground = Instantiate(textBackground, UICanvas.transform);
        TextMeshProUGUI newMessageText = newMessage.GetComponent<TextMeshProUGUI>();
        RectTransform textTransform = newMessage.GetComponent<RectTransform>();
        RectTransform boxTransform = boxBackground.GetComponent<RectTransform>();
        bookText bookText = newMessage.GetComponentInChildren<bookText>();

        bookText.bookmessageID = bookcurrentMessage;

        textTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);
        boxTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);

        newMessage.name = "message" + bookText.bookmessageID;
        boxBackground.name = "box" + bookText.bookmessageID;
        
        switch(stateManager.GetComponent<StateManager>().bookState)
        {
            case 0:
                switch(bookcurrentMessage) 
                {
                    case 0:
                        newMessageText.text = "It’s a bookcase.";
                        
                    break;

                    case 1:
                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        bookcurrentMessage = -1;
                    break;
                }
            break;

            case 1:
                switch(bookcurrentMessage) 
                {
                    case 0:
                        newMessageText.text = "There's a piece of paper sticking out of a book.";
                        
                    break;

                    case 1:
                        newMessageText.text = "Read it?";
                        if(buttonSpawner.GetComponent<ButtonSpawner>().activeButtons < 2)
                        {
                            buttonSpawner.GetComponent<ButtonSpawner>().SpawnAButton(-150.0f, "Yes", 0, 0);
                            buttonSpawner.GetComponent<ButtonSpawner>().SpawnAButton(150.0f, "No", 1, 0);
                        }

                    break;

                    case 2:
                        newMessageText.text = "It says: 7";
                        stateManager.GetComponent<StateManager>().bookFound = true;
                        
                    break;

                    case 3:
                        
                        
                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        bookcurrentMessage = -1;
                        

                    break;

                }
            break;
        }
            if(!buttonSpawner.GetComponent<ButtonSpawner>().buttonsExist)
            {
                bookcurrentMessage++;       

            }

        } 

    }

    public void CabinetDialogue()
    {
        stateManager.GetComponent<StateManager>().cantMove = true;
        switch(stateManager.GetComponent<StateManager>().cabinetState)
        {
            case 0:
                cabinetmessageLimit = 2;
            break;

            case 1:
                cabinetmessageLimit = 8;

            break;
        } 
        if(newMessage != null) //destroy previous message
        {
            Destroy(newMessage);
        }
        if(boxBackground != null) //destroy previous boxbackground
        {
            Destroy(boxBackground);
        }
        if(cabinetcurrentMessage < cabinetmessageLimit) 
        {
            audioSource.PlayOneShot(textboxAdvance);
        newMessage = Instantiate(textbox, UICanvas.transform);
        boxBackground = Instantiate(textBackground, UICanvas.transform);
        TextMeshProUGUI newMessageText = newMessage.GetComponent<TextMeshProUGUI>();
        RectTransform textTransform = newMessage.GetComponent<RectTransform>();
        RectTransform boxTransform = boxBackground.GetComponent<RectTransform>();
        cabinetText cabinetText = newMessage.GetComponentInChildren<cabinetText>();

        cabinetText.cabinetmessageID = cabinetcurrentMessage;

        textTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);
        boxTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);

        newMessage.name = "message" + cabinetText.cabinetmessageID;
        boxBackground.name = "box" + cabinetText.cabinetmessageID;
    
        switch(stateManager.GetComponent<StateManager>().cabinetState)
        {
            case 0:
                switch(cabinetcurrentMessage) 
                {
                    case 0:
                        newMessageText.text = "No batteries here.";
                        
                    break;

                    case 1:
                        
                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        cabinetcurrentMessage = -1;
                        
                    break;
                    
                }
            break;

            case 1:
                switch(cabinetcurrentMessage) 
                {
                    case 0:
                        newMessageText.text = "No batteries here.";
                        
                    break;

                    case 1:
                        newMessageText.text = "There's a post-it note stuck on the glass.";
                        
                    break;

                    case 2:
                        newMessageText.text = "Read it?";
                        if(buttonSpawner.GetComponent<ButtonSpawner>().activeButtons < 2)
                        {
                            buttonSpawner.GetComponent<ButtonSpawner>().SpawnAButton(-150.0f, "Yes", 0, 1);
                            buttonSpawner.GetComponent<ButtonSpawner>().SpawnAButton(150.0f, "No", 1, 1);
                        }

                    break;

                    case 3:
                        newMessageText.text = "It says: To get the third number of the combination,";
                        
                    break;

                    case 4:
                        newMessageText.text = "you find the sum of all four numbers in the combination,";
                        
                    break;

                    case 5:
                        newMessageText.text = "then add the tens and the ones places together";
                        
                    break;

                    case 6:
                        newMessageText.text = "to get a single digit number.";
                        stateManager.GetComponent<StateManager>().cabinetFound = true;
                        
                    break;

                    case 7:
                        
                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        cabinetcurrentMessage = -1;
                        
                    break;
                }
            break;

        }

            if(!buttonSpawner.GetComponent<ButtonSpawner>().buttonsExist)
            {
                cabinetcurrentMessage++;       

            }

        } 

    }

    public void DadDialogue()
    {
        stateManager.GetComponent<StateManager>().cantMove = true;
        switch(stateManager.GetComponent<StateManager>().dadState)
        {
            case 0:
                dadmessageLimit = 4;
            break;

            case 1:
                dadmessageLimit = 3;

            break;
        }
        if(newMessage != null) //destroy previous message
        {
            Destroy(newMessage);
        }
        if(boxBackground != null) //destroy previous boxbackground
        {
            Destroy(boxBackground);
        }
        if(dadcurrentMessage < dadmessageLimit) 
        {
        audioSource.PlayOneShot(textboxAdvance);
            
        newMessage = Instantiate(textbox, UICanvas.transform);
        boxBackground = Instantiate(textBackground, UICanvas.transform);
        TextMeshProUGUI newMessageText = newMessage.GetComponent<TextMeshProUGUI>();
        RectTransform textTransform = newMessage.GetComponent<RectTransform>();
        RectTransform boxTransform = boxBackground.GetComponent<RectTransform>();
        dadText dadText = newMessage.GetComponentInChildren<dadText>();

        dadText.dadmessageID = dadcurrentMessage;

        textTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);
        boxTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);

        newMessage.name = "message" + dadText.dadmessageID;
        boxBackground.name = "box" + dadText.dadmessageID;
        
        switch(stateManager.GetComponent<StateManager>().dadState)
        {
            case 0:
                switch(dadcurrentMessage) 
                {
                    case 0:
                        newMessageText.text = "Dad:" + "\r\n" + "You want the batteries from my remote?";
                        
                    break;

                    case 1:
                        newMessageText.text = "Dad:" + "\r\n" + "How am I gonna watch TV?";
                        
                    break;

                    case 2:
                        newMessageText.text = "Dad:" + "\r\n" + "I think there's a box of batteries in the safe.";
                        
                    break;

                    case 3:
                        stateManager.GetComponent<StateManager>().spokeDad = true;

                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        dadcurrentMessage = -1;
                    break;
                }
            break;

            case 1:
                switch(dadcurrentMessage) 
                {
                    case 0:
                        newMessageText.text = "Dad:" + "\r\n" + "I don't know the combination.";
                        
                    break;

                    case 1:
                        newMessageText.text = "Dad:" + "\r\n" + "Ask your sister.";
                        
                    break;

                    case 2:
                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        dadcurrentMessage = -1;
                    break;
                }
            break;
        }
        dadcurrentMessage++;       
        } 

    }

    public void SafeDialogue()
    {
        stateManager.GetComponent<StateManager>().cantMove = true;
        switch(stateManager.GetComponent<StateManager>().safeState)
        {
            case 0:
                safemessageLimit = 2;
            break;

            case 1:
                safemessageLimit = 2;

            break;

            case 2:
                safemessageLimit = 2;
            break;

            case 3:
                safemessageLimit = 3;

            break;
        }
        if(newMessage != null) //destroy previous message
        {
            Destroy(newMessage);
        }
        if(boxBackground != null) //destroy previous boxbackground
        {
            Destroy(boxBackground);
        }
        if(safecurrentMessage < safemessageLimit) 
        {
            
        newMessage = Instantiate(textbox, UICanvas.transform);
        boxBackground = Instantiate(textBackground, UICanvas.transform);
        TextMeshProUGUI newMessageText = newMessage.GetComponent<TextMeshProUGUI>();
        RectTransform textTransform = newMessage.GetComponent<RectTransform>();
        RectTransform boxTransform = boxBackground.GetComponent<RectTransform>();
        safeText safeText = newMessage.GetComponentInChildren<safeText>();

        safeText.safemessageID = safecurrentMessage;

        textTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);
        boxTransform.anchoredPosition = new Vector2(textboxXPosition, textboxYPosition);

        newMessage.name = "message" + safeText.safemessageID;
        boxBackground.name = "box" + safeText.safemessageID;
        
        switch(stateManager.GetComponent<StateManager>().safeState)
        {
            case 0:
                switch(safecurrentMessage) 
                {
                    case 0:
                    audioSource.PlayOneShot(textboxAdvance);
                        newMessageText.text = "The safe is locked.";
                        
                    break;

                    case 1:
                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        safecurrentMessage = -1;
                    break;
                }
            break;

            case 1:
                switch(safecurrentMessage) 
                {
                    case 0:
                    
                        newMessageText.text = "INPUT 4-DIGIT COMBINATION AND PRESS ENTER";
                        stateManager.GetComponent<StateManager>().safeFound = true;
                        safeCodeInput.SetActive(true);

                        
                    break;

                    case 1:

                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        safecurrentMessage = -1;
                    break;
                }
            break;

            case 2:
                switch(safecurrentMessage) 
                {
                    case 0:
                    audioSource.PlayOneShot(incorrectPassword);
                        newMessageText.text = "INVALID PASSWORD";
                        stateManager.GetComponent<StateManager>().wrongCheck = false;
                        
                    break;

                    case 1:
                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        safecurrentMessage = -1;
                    break;
                }
            break;

            case 3:
                switch(safecurrentMessage) 
                {
                    case 0:
                    audioSource.PlayOneShot(correctPassword);
                        newMessageText.text = "PASSWORD ACCEPTED";
                        
                    break;

                    case 1:
                    audioSource.PlayOneShot(textboxAdvance);
                        newMessageText.text = "You got the batteries.";
                        
                    break;

                    case 2:
                        if(newMessage != null) //destroy previous message
                        {
                            Destroy(newMessage);
                        }
                        if(boxBackground != null) //destroy previous boxbackground
                        {
                            Destroy(boxBackground);
                        }
                        safecurrentMessage = -1;
                    break;
                }
            break;
        }   
            if(!safeCodeInput.activeSelf)
            {
                safecurrentMessage++;       

            }
            
        } 

    }

    public void AllowMoving()
    {
        stateManager.GetComponent<StateManager>().cantMove = false;

    }

}
