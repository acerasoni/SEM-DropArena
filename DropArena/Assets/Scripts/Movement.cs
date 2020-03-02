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
                 player1Body.AddForce(Input.GetAxis("HorizontalPlayer1") * 12 * movementBonusPlayer1, 0, 
                 Input.GetAxis("VerticalPlayer1") * 12 * movementBonusPlayer1, ForceMode.Acceleration);
            } 
            if(!freezePlayer2) {
                 player2Body.AddForce(Input.GetAxis("HorizontalPlayer2") * 12 * movementBonusPlayer2, 0, 
                 Input.GetAxis("VerticalPlayer2") * 12 * movementBonusPlayer2, ForceMode.Acceleration);
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
