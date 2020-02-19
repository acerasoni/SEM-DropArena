using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{

    public Material chaser;
    Vector3 Pos;
    // Start is called before the first frame update
    void Start()
    {   
          
		GameObject Chaser = GameObject.CreatePrimitive(PrimitiveType.Sphere); 
        Chaser.transform.position = new Vector3(4f, 0.49f, 4f);
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
