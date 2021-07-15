using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWalking : MonoBehaviour
{
    public float movementSpeed = 600f;
    public Rigidbody2D playerRB;
    public GameObject stateManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>(); //get a reference to the Rigidbody2D component on this player game object
    
        
    }

    void FixedUpdate()
    {
        
        if(!stateManager.GetComponent<StateManager>().cantMove)
        {

        if(Input.GetKey(KeyCode.LeftArrow)) 
        {
            ///move player to the left
            playerRB.AddForce(Vector2.left * movementSpeed);
            //playerRB.velocity = new Vector2(-1,playerRB.velocity.y) * movementSpeed; //or Vector2.left
            //Vector2.left is a short way of writing Vector2(-1, 0);

        } if (Input.GetKey(KeyCode.RightArrow))
          {
            //move the player to the right
            playerRB.AddForce(Vector2.right * movementSpeed);
            //playerRB.velocity = new Vector2(1,playerRB.velocity.y) * movementSpeed; //or Vector2.right

            //Vector2.right is a short way of writing Vector2(1, 0);

        } if (Input.GetKey(KeyCode.UpArrow))
          {
            //move the player up
            playerRB.AddForce(Vector2.up * movementSpeed);
                

        } if (Input.GetKey(KeyCode.DownArrow))
          {
           //move the player down
            playerRB.AddForce(Vector2.down * movementSpeed);
                

        }
       
        }
    }
    // Update is called once per frame
    void Update()
    {

        if(!stateManager.GetComponent<StateManager>().cantMove)
        {

        if(Input.GetKey(KeyCode.RightArrow)) 
        {
            
            GetComponent<Animator>().Play("WalkRight");
        }

        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            
            GetComponent<Animator>().Play("WalkLeft");

        }

        else if(Input.GetKey(KeyCode.UpArrow))
        {
            
            GetComponent<Animator>().Play("WalkUp");

        }

        else if(Input.GetKey(KeyCode.DownArrow))
        {
            
            GetComponent<Animator>().Play("WalkDown");

        }

        else
        {
            GetComponent<Animator>().Play("Idle");
        }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Katy")
        {
            stateManager.GetComponent<StateManager>().katyTalking = true;
        } 
        if (collision.gameObject.name == "Kwasi")
        {
            stateManager.GetComponent<StateManager>().kwasiTalking = true;


        } 
        if(collision.gameObject.name == "Joanna")
        {
            
            stateManager.GetComponent<StateManager>().joannaTalking = true;
            

        } 
        if(collision.gameObject.name == "Spencer")
        {
            stateManager.GetComponent<StateManager>().spencerTalking = true;


        } 
        if(collision.gameObject.name == "Dad")
        {
            stateManager.GetComponent<StateManager>().dadTalking = true;
            

        }
        if(collision.gameObject.name == "Bookcase")
        {
            stateManager.GetComponent<StateManager>().bookcaseChecking = true;

        }  
        if(collision.gameObject.name == "Cabinet")
        {
            stateManager.GetComponent<StateManager>().cabinetChecking = true;

        } 
        if(collision.gameObject.name == "Safe")
        {
            stateManager.GetComponent<StateManager>().safeChecking = true;

        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Katy")
        {
            stateManager.GetComponent<StateManager>().katyTalking = false;
        } 
        if (collision.gameObject.name == "Kwasi")
        {
            stateManager.GetComponent<StateManager>().kwasiTalking = false;
            

        } 
        if(collision.gameObject.name == "Joanna")
        {
            
            stateManager.GetComponent<StateManager>().joannaTalking = false;
            

        } 
        if(collision.gameObject.name == "Spencer")
        {
            stateManager.GetComponent<StateManager>().spencerTalking = false;
            

        } 
        if(collision.gameObject.name == "Dad")
        {
            stateManager.GetComponent<StateManager>().dadTalking = false;
            

        }
        if(collision.gameObject.name == "Bookcase")
        {
            stateManager.GetComponent<StateManager>().bookcaseChecking = false;
            
        }  
        if(collision.gameObject.name == "Cabinet")
        {
            stateManager.GetComponent<StateManager>().cabinetChecking = false;
            
        }  
        if(collision.gameObject.name == "Safe")
        {
            stateManager.GetComponent<StateManager>().safeChecking = false;
            
        } 
    }
}
