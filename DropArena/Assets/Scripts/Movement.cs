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
    private float movementSpeed = 10;
     level lvl = new level();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if players are assigned
         if(player1 && player2)
         {
            //Processing Player1 input for horizontal 
            //This does the trick: Input.GetAxis("HorizontalPlayer1")
            //Input.GetAxis("HorizontalPlayer1")
            Vector3 vector1 = new Vector3(Input.GetAxis("HorizontalPlayer1"), 0, Input.GetAxis("VerticalPlayer1"));
            player1.GetComponent<Rigidbody>().AddForce(vector1 * movementSpeed);

            Vector3 vector2 = new Vector3(Input.GetAxis("HorizontalPlayer2"), 0, Input.GetAxis("VerticalPlayer2"));
            player2.GetComponent<Rigidbody>().AddForce(vector2 * movementSpeed);

        }

             if (player1.transform.position.y < 0)
         {
             lvl.levelloader();
         }
     }
 }
