using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Player Objects
     [SerializeField]
     public GameObject player1;
     [SerializeField]
     public GameObject player2;
     level lvl = new level();
     public float movementBonusPlayer1;
     public float movementBonusPlayer2;

     public bool freezePlayer1;
     public bool freezePlayer2;

     public float nudgeBonusPlayer1;
     public float nudgeBonusPlayer2;

    // Start is called before the first frame update
    void Start()
    {
        movementBonusPlayer1 = 1;
           movementBonusPlayer2 = 1;

           freezePlayer1 = false;
           freezePlayer2 = false;

           nudgeBonusPlayer1 = 0;
           nudgeBonusPlayer2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if players are assigned
         if(player1 && player1)
         {
             Rigidbody player1Body = player1.GetComponent<Rigidbody>();
             Rigidbody player2Body = player2.GetComponent<Rigidbody>();
             
            if(!freezePlayer1) {
             //Processing Player1 input for horizontal 
             player1.transform.position = new Vector3(player1.transform.position.x + Input.GetAxis("HorizontalPlayer1") * movementBonusPlayer1, 
             player1.transform.position.y, player1.transform.position.z);
             //Processing Player1 input for vertical 
             player1.transform.position = new Vector3(player1.transform.position.x, player1.transform.position.y, 
             player1.transform.position.z + Input.GetAxis("VerticalPlayer1") * movementBonusPlayer1);
            } 
            if(!freezePlayer2) {
             //Processing Player2 input for horizontal 
             player2.transform.position = new Vector3(player2.transform.position.x + Input.GetAxis("HorizontalPlayer2") * movementBonusPlayer1, 
             player2.transform.position.y, player2.transform.position.z);
             //Processing Player2 input for vertical 
             player2.transform.position = new Vector3(player2.transform.position.x, player2.transform.position.y, 
             player2.transform.position.z + Input.GetAxis("VerticalPlayer2") * movementBonusPlayer1);
            }
        
            nudgePlayer(player1Body, nudgeBonusPlayer1);
            nudgePlayer(player2Body, nudgeBonusPlayer2);
         }

         if (player1.transform.position.y < 0)
         {
             lvl.levelloader();
         }

        if (player2.transform.position.y < 0)
         {
             lvl.levelloader();
         }
     }

     void nudgePlayer(Rigidbody playerBody, float nudgeBonus) {
          // Check if close to the edge, in which case give a little nudge inward
        if(playerBody.position.x < 0.1f) {
            // If on the left edge
             playerBody.AddForce(0.04f + nudgeBonus, 0, 0, ForceMode.Force);
        } else if(playerBody.position.x > 3.9f) {
            // If on the right edge
             playerBody.AddForce(-0.04f - nudgeBonus, 0, 0, ForceMode.Force);
        }

        if(playerBody.position.z < 0.1f) {
            // If on the bottom edge
             playerBody.AddForce(0, 0, 0.04f + nudgeBonus, ForceMode.Force);
        } else if(playerBody.position.z > 3.9f) {
            // If on the top edge
            playerBody.AddForce(0, 0, -0.04f - nudgeBonus, ForceMode.Force);
        }
     }
 }
