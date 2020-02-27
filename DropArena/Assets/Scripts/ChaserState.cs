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
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("_player1");
        player2 = GameObject.Find("_player2");
        chaserState = new ChaserStateEnum();
        chaserState = ChaserStateEnum.noChase;
    }

    // Update is called once per frame
    void Update()
    {
        
                // Update chaser according to chaserState
        if (chaserState == ChaserStateEnum.chasePlayer1) {
            this.GetComponent<Rigidbody>().AddForce((player1.transform.position - this.transform.position).normalized * movementSpeed);
        } else if (chaserState == ChaserStateEnum.chasePlayer2){
            this.GetComponent<Rigidbody>().AddForce((player2.transform.position - this.transform.position).normalized * movementSpeed);
        } 
       

    }

    public void setChasedPlayer(ChaserStateEnum state) {
        this.chaserState = state;
    }

    public ChaserStateEnum getChasedPlayer() {
        return this.chaserState;
    }
}
