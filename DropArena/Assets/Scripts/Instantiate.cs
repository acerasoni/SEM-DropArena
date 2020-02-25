using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{

    public Material chaserMaterial;
    private Vector3 _pos;
    private GameObject _chaser;

    // Start is called before the first frame update
    void Start()
    {       
        _pos = new Vector3(4f, 0.49f, 4f);
		_chaser = GameObject.CreatePrimitive(PrimitiveType.Sphere); 
        _chaser.transform.position = _pos;
		_chaser.name = "chaser";
        _chaser.tag = "chaser";
        _chaser.GetComponent<Renderer>().material = chaserMaterial;

        _chaser.AddComponent<ChaserMovement>();

        Rigidbody gameObjectsRigidBody = _chaser.AddComponent<Rigidbody>(); // Add the rigidbody.
        gameObjectsRigidBody.mass = 2; 
    }

    // Update is called once per frame
    void Update()
    {

    }
  
}