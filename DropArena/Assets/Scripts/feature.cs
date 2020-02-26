using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ChaserState
{
    chasePlayer1 = 0,
    chasePlayer2 = 1,
    noChase = 2
}

public class feature : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    private ChaserState chaserState;
    private GameObject player1, player2;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("_player1");
        player2 = GameObject.Find("_player2");
        chaserState = new ChaserState();
        chaserState = ChaserState.noChase;
    }

    // Update is called once per frame
    void Update()
    {
        if (chaserState == ChaserState.chasePlayer1) {
            this.GetComponent<Rigidbody>().AddForce((player1.transform.position - this.transform.position).normalized * movementSpeed);
        } else if (chaserState == ChaserState.chasePlayer2){
            this.GetComponent<Rigidbody>().AddForce((player2.transform.position - this.transform.position).normalized * movementSpeed);
        } 
       
        
    }
}
