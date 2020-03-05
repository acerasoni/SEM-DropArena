using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    // Keyboard controls
    public string horizontalAxis, verticalAxis;

    // Movement state variables
    private float _movementBonus;
    private float _nudgeBonus;
    private bool _freeze;

    private Level _lvl;
    private Score _score;

    private Rigidbody _playerBody;

    void Start () {

        _lvl = GameObject.Find("_player1").GetComponent<Level>();
        _score = GameObject.Find("Score").GetComponent<Score>();
        // Initialise movement state
        _movementBonus = 1;
        _freeze = false;
        _nudgeBonus = 0;
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
        if (!_freeze) {
            //Processing horizontal input
            this.transform.position = new Vector3 (this.transform.position.x + Input.GetAxis (horizontalAxis) * 0.5f * _movementBonus,
                this.transform.position.y, this.transform.position.z);
            //Processing vertical input
            this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y,
                this.transform.position.z + Input.GetAxis (verticalAxis) * 0.5f * _movementBonus);
        }
    }

    void nudgePlayer () {
        // Check if close to the edge, in which case give a little nudge inward
        if (_playerBody.position.x < 0.1f) {
            // If on the left edge
            _playerBody.AddForce (0.04f + _nudgeBonus, 0, 0, ForceMode.Force);
        } else if (_playerBody.position.x > 8f) {
            // If on the right edge
            _playerBody.AddForce (-0.04f - _nudgeBonus, 0, 0, ForceMode.Force);
        }

        if (_playerBody.position.z < 0.1f) {
            // If on the bottom edge
            _playerBody.AddForce (0, 0, 0.04f + _nudgeBonus, ForceMode.Force);
        } else if (_playerBody.position.z > 8f) {
            // If on the top edge
            _playerBody.AddForce (0, 0, -0.04f - _nudgeBonus, ForceMode.Force);
        }
    }

    void checkIfHasFallen () {

        if (this.transform.position.y < 0) {
            if (this.name == "_player1") {
                _score.p2 ();
            } else {
                _score.p1 ();
            }
            _lvl.LevelLoader ();
        }

    }

    public void setMovementBonus (float _movementBonus) {
        this._movementBonus = _movementBonus;
    }

    public void setNudgeBonus (float _nudgeBonus) {
        this._nudgeBonus = _nudgeBonus;
    }

    public void setFreeze (bool _freeze) {
        this._freeze = _freeze;
    }
}