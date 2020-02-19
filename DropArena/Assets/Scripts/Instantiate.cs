using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{

    private Material chaser;
    private Vector3 Pos = new Vector3(4f, 0.49f, 4f);
    // Start is called before the first frame update
    void Start()
    {    
		GameObject Chaser = GameObject.CreatePrimitive(PrimitiveType.Sphere); 
        Chaser.transform.position = Pos;
		Chaser.name = "chaser";
        Chaser.tag = "chaser";
        Chaser.GetComponent<Renderer>().material = chaser;
        Rigidbody gameObjectsRigidBody = Chaser.AddComponent<Rigidbody>(); // Add the rigidbody.
        gameObjectsRigidBody.mass = 2; 
    }

    // Update is called once per frame
    void Update()
    {

    }
  
}