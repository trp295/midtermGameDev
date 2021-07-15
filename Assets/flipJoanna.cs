using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipJoanna : MonoBehaviour
{

    public GameObject stateManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (stateManager.GetComponent<StateManager>().playScreen)
        {    
            if(!stateManager.GetComponent<StateManager>().joannaTalking)
            {
                GetComponent<Animator>().Play("JoannaBack");


            } else
            {
                GetComponent<Animator>().Play("JoannaIdle");
            }
        } else
        {
            
            GetComponent<Animator>().Play("JoannaIdle");

        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
