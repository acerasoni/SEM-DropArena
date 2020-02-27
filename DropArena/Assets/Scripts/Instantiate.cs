using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{

    public Material chaserMaterial;
    public Material gemMaterial;
    private Vector3 _chaserPos;
    private Vector3 _gemPos;
    private GameObject _chaser;
    private GameObject _gem;

    // Start is called before the first frame update
    void Start()
    {       
        _chaserPos = new Vector3(4f, 0.49f, 4f);
		_chaser = GameObject.CreatePrimitive(PrimitiveType.Sphere); 
        _chaser.transform.position = _chaserPos;
		_chaser.name = "chaser";
        _chaser.tag = "chaser";
        _chaser.GetComponent<Renderer>().material = chaserMaterial;
        Rigidbody chaserRigidBody = _chaser.AddComponent<Rigidbody>(); // Add the rigidbody.
        _chaser.AddComponent<ChaserState>();
        chaserRigidBody.mass = 2; 

        // Retrieve chaser in player scripts. This is because chaser doesn't exist until this point.
        GameObject.Find("_player1").GetComponent<PlayerGem>().retrieveChaser();
        GameObject.Find("_player2").GetComponent<PlayerGem>().retrieveChaser();

        _gemPos = generateRandomPosition();
		_gem = GameObject.CreatePrimitive(PrimitiveType.Cube); 
        _gem.transform.position = _gemPos;
		_gem.name = "gem";
        _gem.GetComponent<Renderer>().material = gemMaterial;
        _gem.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        Rigidbody gemRigidBody = _gem.AddComponent<Rigidbody>(); // Add the rigidbody.
        var gemCollider = _gem.GetComponent<BoxCollider>();
        gemCollider.size = new Vector3(0.25f, 0.25f, 0.25f);
        gemRigidBody.mass = 2; 
    }

    // Update is called once per frame
    void Update()
    {

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