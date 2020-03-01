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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if players are assigned
         if(player1 && player1)
         {
             Rigidbody player1Body = player1.GetComponent<Rigidbody>();
             Rigidbody player2Body = player2.GetComponent<Rigidbody>();
               
               //Processing Player1 input for horizontal 
            //This does the trick: Input.GetAxis("HorizontalPlayer1")
            //Input.GetAxis("HorizontalPlayer1")
            player1Body.AddForce(Input.GetAxis("HorizontalPlayer1") * 12, 0, Input.GetAxis("VerticalPlayer1") * 12, ForceMode.Acceleration);
            player2Body.AddForce(Input.GetAxis("HorizontalPlayer2") * 12, 0, Input.GetAxis("VerticalPlayer2") * 12, ForceMode.Acceleration);

            nudgePlayer(player1Body);
         nudgePlayer(player2Body);
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

     void nudgePlayer(Rigidbody playerBody) {
          // Check if close to the edge, in which case give a little nudge inward
        if(playerBody.position.x < 0.1f) {
            // If on the left edge
             playerBody.AddForce(0.2f, 0, 0, ForceMode.Force);
        } else if(playerBody.position.x > 3.9f) {
            // If on the right edge
             playerBody.AddForce(-0.2f, 0, 0, ForceMode.Force);
        }

        if(playerBody.position.z < 0.1f) {
            // If on the bottom edge
             playerBody.AddForce(0, 0, 0.2f, ForceMode.Force);
        } else if(playerBody.position.z > 3.9f) {
            // If on the top edge
            playerBody.AddForce(0, 0, -0.2f, ForceMode.Force);
        }
     }
 }
