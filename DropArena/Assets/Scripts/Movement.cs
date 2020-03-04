﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    level lvl = new level ();

    // Keyboard controls
    public string horizontalAxis, verticalAxis;

    // Movement state variables
    private float movementBonus;
    private float nudgeBonus;
    private bool freeze;

    private Rigidbody _playerBody;

    void Start () {

        // Initialise movement state
        movementBonus = 1;
        freeze = false;
        nudgeBonus = 0;
        _playerBody = this.GetComponent<Rigidbody> ();

    }

    void Update () {

        // Move the player via the keyboard commands
        movePlayer ();
        // Nudge the player inward if they are close to the arena
        nudgePlayer ();
        // Check if the player has fallen
        checkIfHasFallen ();

    }

    void movePlayer () {
        if (!freeze) {
            //Processing horizontal input
            this.transform.position = new Vector3 (this.transform.position.x + Input.GetAxis (horizontalAxis) * 0.35f * movementBonus,
                this.transform.position.y, this.transform.position.z);
            //Processing vertical input
            this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y,
                this.transform.position.z + Input.GetAxis (verticalAxis) * 0.35f * movementBonus);
        }
    }

    void nudgePlayer () {
        // Check if close to the edge, in which case give a little nudge inward
        if (_playerBody.position.x < 0.1f) {
            // If on the left edge
            _playerBody.AddForce (0.04f + nudgeBonus, 0, 0, ForceMode.Force);
        } else if (_playerBody.position.x > 3.9f) {
            // If on the right edge
            _playerBody.AddForce (-0.04f - nudgeBonus, 0, 0, ForceMode.Force);
        }

        if (_playerBody.position.z < 0.1f) {
            // If on the bottom edge
            _playerBody.AddForce (0, 0, 0.04f + nudgeBonus, ForceMode.Force);
        } else if (_playerBody.position.z > 3.9f) {
            // If on the top edge
            _playerBody.AddForce (0, 0, -0.04f - nudgeBonus, ForceMode.Force);
        }
    }

    void checkIfHasFallen () {

        if (this.transform.position.y < 0) {
            if (this.name == "_player1") {
                // JOSH INCREASE SCORE FOR PLAYER 2 HERE
            } else {
                // JOSH INCREASE SCORE FOR PLAYER 1 HERE
            }
            lvl.levelloader ();
        }

    }

    public void setMovementBonus (float movementBonus) {
        this.movementBonus = movementBonus;
    }

    public void setNudgeBonus (float nudgeBonus) {
        this.nudgeBonus = nudgeBonus;
    }

    public void setFreeze (bool freeze) {
        this.freeze = freeze;
    }
}