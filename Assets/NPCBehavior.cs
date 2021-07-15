using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{

    Rigidbody2D npcRigidbody;
    public GameObject stateManager;

    bool npcSeesObstacle = false;
    public float patrolSpeed = 5f;

    bool isFacingLeft = true;
    
    // Start is called before the first frame update
    void Start()
    {
        npcRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stateManager.GetComponent<StateManager>().playScreen)
        {    
            if(!stateManager.GetComponent<StateManager>().kwasiTalking)
            {
                Patrolling();

            } else
            {
                npcSeesObstacle = false;
                npcRigidbody.velocity = new Vector2(0.0f, 0.0f);
                GetComponent<Animator>().Play("KwasiIdle");
            }
        } else
        {
            npcSeesObstacle = false;
            npcRigidbody.velocity = new Vector2(0.0f, 0.0f);
            GetComponent<Animator>().Play("KwasiIdle");

        }
        
    }

    void Patrolling()
    {
        float horizontalMovement;

        if(isFacingLeft)
        {
            horizontalMovement = -1.0f * patrolSpeed;
            GetComponent<Animator>().Play("KwasiLeft");
        } else
        {
            horizontalMovement = 1.0f * patrolSpeed;
            GetComponent<Animator>().Play("KwasiRight");

        }

        

        Vector2 rayCastDirection = new Vector2(horizontalMovement, 0.0f);

        float rayCastLength = 7f;
        int obstacleLayerMaskNumber = LayerMask.GetMask("Obstacle", "Player");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayCastDirection, rayCastLength, obstacleLayerMaskNumber);

        Debug.DrawRay(transform.position, rayCastDirection * rayCastLength, Color.red);

        //if the raycast has hit something
        if(hit.collider != null)
        {
            //in here check what we've hit
            if(hit.collider.gameObject.tag == "Obstacle") //obstacle is a tag
            {
                npcSeesObstacle = true;
            }
        } else
        {
            npcSeesObstacle = false;
        }

        if(npcSeesObstacle)
        {
            
            isFacingLeft = !isFacingLeft;
            
        } else
        {
            //if npc doesnt see obstacle then keep moving
            npcRigidbody.velocity = new Vector2(horizontalMovement, 0.0f);

        }
    }
}
