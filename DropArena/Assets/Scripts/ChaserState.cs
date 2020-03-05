using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChaserStateEnum {
    chasePlayer1 = 0,
    chasePlayer2 = 1,
    noChase = 2
}

public class ChaserState : MonoBehaviour {

    public Light player2Light;
    public Light player1Light;

    public float movementSpeed = 4.5f;
    public ChaserStateEnum chaserState;
    private GameObject _player1, _player2;
    private Rigidbody _chaserBody;

    void Start () {
        _player1 = GameObject.Find ("_player1");
        _player2 = GameObject.Find ("_player2");

        player1Light = _player1.GetComponent<Light> ();
        player2Light = _player2.GetComponent<Light> ();
        player1Light.intensity = 15f;
        player2Light.intensity = 15f;

        player1Light.enabled = false;
        player2Light.enabled = false;
        chaserState = new ChaserStateEnum ();
        chaserState = ChaserStateEnum.noChase;
        _chaserBody = this.GetComponent<Rigidbody> ();
    }

    void Update () {
        // Update chaser according to chaserState
        if (chaserState == ChaserStateEnum.chasePlayer1) {
            _chaserBody.AddForce ((_player1.transform.position - this.transform.position).normalized * movementSpeed);
        } else if (chaserState == ChaserStateEnum.chasePlayer2) {
            _chaserBody.AddForce ((_player2.transform.position - this.transform.position).normalized * movementSpeed);
        }

        // Check if close to the edge, in which case give a little nudge inward
        if (_chaserBody.position.x < 0.2f) {
            // If on the left edge
            _chaserBody.AddForce (1f, 0, 0, ForceMode.Force);
        } else if (_chaserBody.position.x > 3.8f) {
            // If on the right edge
            _chaserBody.AddForce (-1f, 0, 0, ForceMode.Force);
        }

        if (_chaserBody.position.z < 0.2f) {
            // If on the bottom edge
            _chaserBody.AddForce (0, 0, 1f, ForceMode.Force);
        } else if (_chaserBody.position.z > 3.8f) {
            // If on the top edge
            _chaserBody.AddForce (0, 0, -1f, ForceMode.Force);
        }
    }

    public void setChasedPlayer (ChaserStateEnum state) {
        _chaserBody.useGravity = true;
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