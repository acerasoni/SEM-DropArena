using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{

    public Material chaserMaterial;
    private Vector3 _pos;
    public GameObject chaser;

    // Start is called before the first frame update
    void Start()
    {   
 
        GameObject player1 = GameObject.Find("player1");
        GameObject player2 = GameObject.Find("player2");

        _pos = new Vector3(4f, 0.49f, 4f);
		chaser = GameObject.CreatePrimitive(PrimitiveType.Sphere); 
        chaser.transform.position = _pos;
		chaser.name = "chaser";
        chaser.tag = "chaser";
        chaser.GetComponent<Renderer>().material = chaserMaterial;

        var script = GetComponent<ChaserMovement>();
        script.chaser = chaser;
        script.player1 = player1;
        script.player2 = player2;

        Rigidbody gameObjectsRigidBody = chaser.AddComponent<Rigidbody>(); // Add the rigidbody.
        gameObjectsRigidBody.mass = 2; 
    }

    // Update is called once per frame
    void Update()
    {

    }
  
}