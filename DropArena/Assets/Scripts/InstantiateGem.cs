using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateGem : MonoBehaviour {

    public Material gemMaterial;
    public bool justSpawned;

    // Start is called before the first frame update
    void Start () {
        justSpawned = true;
        generateNewPosition ();

        this.name = "gem";
        this.GetComponent<Renderer> ().material = gemMaterial;
        this.transform.localScale = new Vector3 (0.25f, 0.25f, 0.25f);
        Rigidbody gemRigidBody = this.gameObject.AddComponent<Rigidbody> (); // Add the rigidbody.
        var gemCollider = this.gameObject.GetComponent<BoxCollider> ();

        gemCollider.size = new Vector3 (0.25f, 0.25f, 0.25f);
        gemRigidBody.mass = 2;
    }

    // Update is called once per frame
    void Update () {
        if (isNotInPosition ()) {
            generateNewPosition ();
        }

    }

    public void generateNewPosition () {

        Vector3 position = generateRandomPosition ();
        this.transform.position = position;
    }

    private bool isNotInPosition () {

        // Checking if the gem is higher than 0.51 because we spawn it at exactly 0.5 - meaning something must have pushed it up (i.e. spawning on a column)
        if (this.transform.position.y > 0.51f) {
            return true;
        }

        // Check the gem is not too close to one player, only if just spawned. Defined as farthest player not being twice as far away than closer player.
        if (justSpawned) {
            Vector3 vectorPlayerOne = GameObject.Find ("_player1").GetComponent<Rigidbody> ().position;
            Vector3 vectorPlayerTwo = GameObject.Find ("_player2").GetComponent<Rigidbody> ().position;
            Vector3 vectorGem = this.GetComponent<Rigidbody> ().position;
            float distanceFromOne = Mathf.Abs(Vector3.Distance (vectorGem, vectorPlayerOne));
            float distanceFromTwo = Mathf.Abs(Vector3.Distance (vectorGem, vectorPlayerTwo));

            if(distanceFromOne > distanceFromTwo*2 || distanceFromTwo > distanceFromOne*2) {
                return true;
            }

            Debug.Log("D1: " + distanceFromOne);
            Debug.Log("D2: " + distanceFromTwo);
        }



        justSpawned = false;
        return false;

    }

    // Generates random position on one of the 4 edges.
    // The size of the base is 10, but we will set the square position to 9 to avoid collision with edge obstacles.
    public Vector3 generateRandomPosition () {
        Vector3 gPos;

        System.Random rand = new System.Random ();
        float range = 8.5f;
        float rFloat = (float) (rand.NextDouble () * range);

        // Determine axis
        if (rand.NextDouble () >= 0.5) {
            // Determine left or right
            if (rand.NextDouble () >= 0.5) {
                // Left
                gPos = new Vector3 (-0.25f, 0.5f, rFloat);
            } else {
                // Right
                gPos = new Vector3 (8.25f, 0.5f, rFloat);
            }
        } else {
            // Determine top or bottom
            if (rand.NextDouble () >= 0.5) {
                // Top
                gPos = new Vector3 (rFloat, 0.5f, 8.25f);
            } else {
                // Bottom
                gPos = new Vector3 (rFloat, 0.5f, -0.25f);
            }
        }

        return gPos;
    }

}