using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateGem : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
          // Step 1 - create position
            Vector3 position = generateRandomPosition();
            this.transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        void OnCollisionEnter(Collision collision){    	 
            // Step 3 - move the gem
            generateValidPosition(collision);
         }

    public void generateValidPosition(Collision collision) {
            // Step 2 - check if there is collision
            while(isCollidingWithColumn(collision)) {
                Vector3 position = generateRandomPosition();
                this.transform.position = position;
            }
    } 

    private bool isCollidingWithColumn(Collision collision) {
        
        switch(collision.gameObject.name) {
            case  "_player1": 
            case  "_player2": 
            case  "chaser": 
            case  "_powerup": 
            case  "Arena": 
            return false;
        }

        return true;

    } 

    // Generates random position on one of the 4 edges.
    // The size of the base is 10, but we will set the square position to 9 to avoid collision with edge obstacles.
    public Vector3 generateRandomPosition() {
        Vector3 gPos;

        System.Random rand = new System.Random();
        int range = 4;
        float rFloat = (float) (rand.NextDouble()* range);

        // Determine axis
        if(rand.NextDouble() >= 0.5) {
            // Determine left or right
            if(rand.NextDouble() >= 0.5){
                // Left
                gPos = new Vector3(0f, 0.49f, rFloat);
            } else {
                // Right
                gPos = new Vector3(8.5f, 0.49f, rFloat);
            }
        } else {
            // Determine top or bottom
            if(rand.NextDouble() >= 0.5) {
                // Top
                 gPos = new Vector3(rFloat, 0.49f, 8.5f);
            } else {
                // Bottom
                 gPos = new Vector3(rFloat, 0.49f, 0f);
            }
        }
        
        return gPos;
    }

}
