using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance;

    


    public int gameState = 0;
    public bool startScreen = false;
    public bool playScreen = false;
    public bool endScreen = false;
    public bool finishedCutscene1 = false;


    public bool katyTalking = false;
    public bool joannaTalking = false;
    public bool kwasiTalking = false;
    public bool spencerTalking = false;
    public bool bookcaseChecking = false;
    public bool cabinetChecking = false;
    public bool dadTalking = false;
    public bool safeChecking = false;


    public int katyState = 0;
    public int joannaState = 0;
    public int kwasiState = 0;
    public int spencerState = 0;
    public int bookState = 0;
    public int dadState = 0;
    public int safeState = 0;
    public int cabinetState = 0;



    public bool safeFound = false;
    public bool bookFound = false;
    public bool cabinetFound = false;
    public bool batteryFound = false;

    public bool spokeKaty = false;
    public bool spokeDad = false;
    public bool wrongCheck = false;

    public bool cantMove;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;  
        } else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cantMove = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        switch(gameState)
        {
            case 0:
                startScreen = true;
               
            break;

            case 1:
                startScreen = false;
                playScreen = true;
                

            break;

            case 2:
                playScreen = false;
                endScreen = true;
                
                
                

            break;
        }

        if(spokeDad)
        {
            safeState = 1;

            if(wrongCheck)
            {
                safeState = 2;
            } else if ((wrongCheck == false) && (batteryFound == false)) 
            {
                safeState = 1;
            }
        }

        if(safeFound)
        {
            katyState = 1;
            joannaState = 1;
            kwasiState = 1;
            spencerState = 1;
            dadState = 1;
            cabinetState = 1;
            
            if(cabinetFound)
            {
                joannaState = 2;
                
            }

            if(spokeKaty)
            {
                bookState = 1;
            }

            if(bookFound)
            {
                katyState = 2;
            }
            
            
            
        }

        

        if(batteryFound)
            {
                safeState = 3;
                if(katyTalking || kwasiTalking || joannaTalking || spencerTalking)
                {
                    gameState = 2;
                }
            }
    }
}
