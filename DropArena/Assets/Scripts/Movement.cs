using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Player Objects
     [SerializeField]
     private GameObject _player1;
     [SerializeField]
     private GameObject _player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if players are assigned
         if(_player1 && _player1)
         {
             //Processing Player1 input for horizontal 
             //This does the trick: Input.GetAxis("HorizontalPlayer1")
             _player1.transform.position = new Vector3(_player1.transform.position.x + Input.GetAxis("HorizontalPlayer1"), _player1.transform.position.y, _player1.transform.position.z);
             //Processing Player1 input for vertical 
             _player1.transform.position = new Vector3(_player1.transform.position.x, _player1.transform.position.y, _player1.transform.position.z + Input.GetAxis("VerticalPlayer1"));
 
             //Processing Player2 input for horizontal 
             //This does the trick: Input.GetAxis("HorizontalPlayer2")
             _player2.transform.position = new Vector3(_player2.transform.position.x + Input.GetAxis("HorizontalPlayer2"), _player2.transform.position.y, _player2.transform.position.z);
             //Processing Player2 input for vertical 
             _player2.transform.position = new Vector3(_player2.transform.position.x, _player2.transform.position.y, _player2.transform.position.z + Input.GetAxis("VerticalPlayer2"));
         }
     }
 }
