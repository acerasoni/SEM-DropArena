using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateGem : MonoBehaviour
{

    public Material gemMaterial;

    // Start is called before the first frame update
    void Start()
    {
        generateNewPosition();

		this.name = "gem";
        this.GetComponent<Renderer>().material = gemMaterial;
        this.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        Rigidbody gemRigidBody = this.gameObject.AddComponent<Rigidbody>(); // Add the rigidbody.
        var gemCollider = this.gameObject.GetComponent<BoxCollider>();  

        gemCollider.size = new Vector3(0.25f, 0.25f, 0.25f);
        gemRigidBody.mass = 2; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        void OnCollisionEnter(Collision collision){    	 
    
            if(isCollidingWithColumn(collision)) {
                generateNewPosition();
            }
         }

    public void generateNewPosition() {
        
            Vector3 position = generateRandomPosition();
            this.transform.position = position;
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
        float range = 8.5f;
        float rFloat = (float) (rand.NextDouble()* range);

        // Determine axis
        if(rand.NextDouble() >= 0.5) {
            // Determine left or right
            if(rand.NextDouble() >= 0.5){
                // Left
                gPos = new Vector3(-0.5f, 0.49f, rFloat);
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
                 gPos = new Vector3(rFloat, 0.49f, -0.5f);
            }
        }
        
        return gPos;
    }

}
