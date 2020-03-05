using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChaserStateEnum {
    chasePlayer1 = 0,
    chasePlayer2 = 1,
    noChase = 2
}

public class ChaserState : MonoBehaviour {

    // TODO: Make these private
    public Light player2Light;
    public Light player1Light;

    public float movementSpeed = 4.5f;
    public ChaserStateEnum chaserState;
    private GameObject player1, player2;
    private Rigidbody chaserBody;

    void Start () {
        player1 = GameObject.Find ("_player1");
        player2 = GameObject.Find ("_player2");
        
        player1Light = player1.GetComponent<Light>();
        player2Light = player2.GetComponent<Light>();
        player1Light.intensity = 15f;
        player2Light.intensity = 15f;

        player1Light.enabled = false;
        player2Light.enabled = false;
        chaserState = new ChaserStateEnum ();
        chaserState = ChaserStateEnum.noChase;
        chaserBody = this.GetComponent<Rigidbody> ();
    }

    void Update () {
        // Update chaser according to chaserState
        if (chaserState == ChaserStateEnum.chasePlayer1) {
            chaserBody.AddForce ((player1.transform.position - this.transform.position).normalized * movementSpeed);
        } else if (chaserState == ChaserStateEnum.chasePlayer2) {
            chaserBody.AddForce ((player2.transform.position - this.transform.position).normalized * movementSpeed);
        }

        // Check if close to the edge, in which case give a little nudge inward
        if (chaserBody.position.x < 0.2f) {
            // If on the left edge
            chaserBody.AddForce (1f, 0, 0, ForceMode.Force);
        } else if (chaserBody.position.x > 3.8f) {
            // If on the right edge
            chaserBody.AddForce (-1f, 0, 0, ForceMode.Force);
        }

        if (chaserBody.position.z < 0.2f) {
            // If on the bottom edge
            chaserBody.AddForce (0, 0, 1f, ForceMode.Force);
        } else if (chaserBody.position.z > 3.8f) {
            // If on the top edge
            chaserBody.AddForce (0, 0, -1f, ForceMode.Force);
        }
    }

    public void setChasedPlayer (ChaserStateEnum state) {
        chaserBody.useGravity = false;
        if (state == ChaserStateEnum.chasePlayer1) {
            player1Light.enabled = true;
            player2Light.enabled = false;
        } else if (state == ChaserStateEnum.chasePlayer2) {
            player1Light.enabled = false;
            player2Light.enabled = true;
        }
        this.chaserState = state;
    }

    public ChaserStateEnum getChasedPlayer () {
        return this.chaserState;
    }
}