using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChaserStateEnum
{
    chasePlayer1 = 0,
    chasePlayer2 = 1,
    noChase = 2
}

public class ChaserState : MonoBehaviour
{

    public float movementSpeed = 5f;
    public ChaserStateEnum chaserState;
    private GameObject player1, player2;
    private Rigidbody chaserBody;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("_player1");
        player2 = GameObject.Find("_player2");
        chaserState = new ChaserStateEnum();
        chaserState = ChaserStateEnum.noChase;
        chaserBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update chaser according to chaserState
        if (chaserState == ChaserStateEnum.chasePlayer1) {
            chaserBody.AddForce((player1.transform.position - this.transform.position).normalized * movementSpeed);
        } else if (chaserState == ChaserStateEnum.chasePlayer2){
            chaserBody.AddForce((player2.transform.position - this.transform.position).normalized * movementSpeed);
        } 
       
        // Check if close to the edge, in which case give a little nudge inward
        if(chaserBody.position.x < 0.2f) {
            // If on the left edge
             chaserBody.AddForce(0.5f, 0, 0, ForceMode.Force);
        } else if(chaserBody.position.x > 3.8f) {
            // If on the right edge
             chaserBody.AddForce(-0.5f, 0, 0, ForceMode.Force);
        }

        if(chaserBody.position.y < 0.2f) {
            // If on the bottom edge
             chaserBody.AddForce(0, 0, 0.5f, ForceMode.Force);
        } else if(chaserBody.position.y > 3.8f) {
            // If on the top edge
            chaserBody.AddForce(0, 0, -0.5f, ForceMode.Force);
        }
    }

    public void setChasedPlayer(ChaserStateEnum state) {
        this.chaserState = state;
    }

    public ChaserStateEnum getChasedPlayer() {
        return this.chaserState;
    }
}
