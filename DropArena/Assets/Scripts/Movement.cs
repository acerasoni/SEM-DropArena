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
             //Processing Player1 input for horizontal 
             //This does the trick: Input.GetAxis("HorizontalPlayer1")
             player1.transform.position = new Vector3(player1.transform.position.x + Input.GetAxis("HorizontalPlayer1") / 4, player1.transform.position.y, player1.transform.position.z);
             //Processing Player1 input for vertical 
             player1.transform.position = new Vector3(player1.transform.position.x, player1.transform.position.y, player1.transform.position.z + Input.GetAxis("VerticalPlayer1") / 4);
 
             //Processing Player2 input for horizontal 
             //This does the trick: Input.GetAxis("HorizontalPlayer2")
             player2.transform.position = new Vector3(player2.transform.position.x + Input.GetAxis("HorizontalPlayer2") / 4, player2.transform.position.y, player2.transform.position.z);
             //Processing Player2 input for vertical 
             player2.transform.position = new Vector3(player2.transform.position.x, player2.transform.position.y, player2.transform.position.z + Input.GetAxis("VerticalPlayer2") / 4);
         }
     }
 }
