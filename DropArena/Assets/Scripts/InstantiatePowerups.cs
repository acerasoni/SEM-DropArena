using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePowerups : MonoBehaviour {

    public enum PowerUps {
        sizePowerup = 0,
        speedPowerup = 1,
        massPowerup = 2,
        nofallPowerup = 3,
        sizePowerdown = 4,
        speedPowerdown = 5,
        massPowerdown = 6,
        freezePowerDown = 7
    }

    // Powerup materials
    public Material positiveMaterial;
    public Material negativeMaterial;

    // Current time
    private float _time;
    private float _powerupSpawnDelay;
    private int _currentPowerup;

    // Positive powerups
    private GameObject _powerup;

    // Start is called before the first frame update
    void Start () {
        _time = Time.time;
        _powerupSpawnDelay = 5.0f;
        generatePowerup ();
    }

    // Update is called once per frame
    void Update () {
        // Every 5.0 seconds, spawn a new powerup
        // Destroy previous one if it exists
        if (Time.time >= _time + _powerupSpawnDelay) {
            generatePowerup ();
            _time = Time.time;
        }
    }

    private void generatePowerup () {
        // Randomly select one powerup
        _currentPowerup = Random.Range (0, 8);

        switch (_currentPowerup) {
            case (int) PowerUps.sizePowerup:
            case (int) PowerUps.speedPowerup:
            case (int) PowerUps.massPowerup:
            case (int) PowerUps.nofallPowerup:
                _powerup = GameObject.CreatePrimitive (PrimitiveType.Capsule);
                _powerup.GetComponent<Renderer> ().material = positiveMaterial;
                break;
            case (int) PowerUps.sizePowerdown:
            case (int) PowerUps.speedPowerdown:
            case (int) PowerUps.massPowerdown:
            case (int) PowerUps.freezePowerDown:
                _powerup = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
                _powerup.GetComponent<Renderer> ().material = negativeMaterial;
                break;
        }

        _powerup.name = "_powerup";
        _powerup.transform.localScale += new Vector3 (-0.85f, -0.85f, -0.85f);
        _powerup.transform.position = generateNewPosition ();
        Rigidbody powerupBody = _powerup.AddComponent<Rigidbody> (); // Add the rigidbody.

        powerupBody.mass = 2;

        // Kills the game object in 5.0 seconds after loading the object
        Destroy (_powerup, _powerupSpawnDelay);
    }


    /**
     * Generates a new, valid position for the powerup
     * @return the Vector3 position
     */
    public Vector3 generateNewPosition () {
        Vector3 position = generateRandomPosition ();
        while (isNotValidPosition (position)) {
            position = generateRandomPosition ();
        }

        return position;
    }


    /**
     * Returns false if the position is not a valid powerup position according to the player's positions.
     * @param the Vector3 position
     * @return bool = true if invalid
     */
    private bool isNotValidPosition (Vector3 position) {

        // Checking if the powerup is higher than 0.51 because we spawn it at exactly 0.5 - meaning something must have pushed it up (i.e. spawning on a column)
        if (position.y > 0.51f) {
            return true;
        }

        // Check the powerup is not too close to one player, only if just spawned. Defined as being at least 1 unit away.

        Vector3 vectorPlayerOne = GameObject.Find ("_player1").GetComponent<Rigidbody> ().position;
        Vector3 vectorPlayerTwo = GameObject.Find ("_player2").GetComponent<Rigidbody> ().position;
        Vector3 vectorGem = position;
        float distanceFromOne = Mathf.Abs (Vector3.Distance (vectorGem, vectorPlayerOne));
        float distanceFromTwo = Mathf.Abs (Vector3.Distance (vectorGem, vectorPlayerTwo));

        if (distanceFromOne < 1 || distanceFromTwo < 1) {
            return true;
        }

        return false;

    }


    /**
     * Generates random position inside of the Arena.
     * @return the Vector3 position
     */
    private Vector3 generateRandomPosition () {
        return new Vector3 (Random.Range (0, 5.0f), 0.49f, Random.Range (0, 5.0f));
    }

    
    /**
     * @return Powerup type as enumerated by ChaserStateEnum
     */
    public int getPowerupType () {
        return this._currentPowerup;
    }

}