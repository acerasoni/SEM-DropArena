using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGem : MonoBehaviour {

    private ChaserState _chaser;

    Level _lvl;
    Score _score;

    void Start () {
        // Fetch level and score from scene
        _lvl = GameObject.Find ("_player1").GetComponent<Level> ();
        _score = GameObject.Find ("Score").GetComponent<Score> ();
    }

    void Update () {

    }

    void OnCollisionEnter (Collision collision) {

        // Check for collision with gem   	
        if (collision.gameObject.name == "gem") {
            GameObject.Find ("GameObject").GetComponent<AudioSource> ().Play ();

            if (this.name == "_player1") {
                _chaser.setChasedPlayer (ChaserStateEnum.chasePlayer2);
                moveGem (collision);

            } else if (this.name == "_player2") {
                _chaser.setChasedPlayer (ChaserStateEnum.chasePlayer1);
                moveGem (collision);
            }
        }

        // Check for collision with chaser
        if (collision.gameObject.name == "chaser") {
            if (this.name == "_player1" && _chaser.getChasedPlayer () == ChaserStateEnum.chasePlayer1) {
                _score.p2 ();
                _lvl.LevelLoader ();
            } else if (this.name == "_player2" && _chaser.getChasedPlayer () == ChaserStateEnum.chasePlayer2) {
                _score.p1 ();
                _lvl.LevelLoader ();
            }
        }
    }

    public void retrieveChaser () {
        _chaser = GameObject.Find ("chaser").GetComponent<ChaserState> ();
    }

    /**
     * Given collision with an object, it will check if it is the gem and if so respawn it.
     * @params Collision 
     */
    private void moveGem (Collision collision) {
        InstantiateGem script = GameObject.Find ("gem").GetComponent<InstantiateGem> ();
        script.generateNewPosition ();
    }
}