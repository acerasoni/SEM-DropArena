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
        _chaser.transform.localScale += new Vector3(-0.5f, -0.5f, -0.5f);

        // Retrieve chaser in player scripts. This is because chaser doesn't exist until this point.
        GameObject.Find("_player1").GetComponent<PlayerGem>().retrieveChaser();
        GameObject.Find("_player2").GetComponent<PlayerGem>().retrieveChaser();

     
		_gem = GameObject.CreatePrimitive(PrimitiveType.Cube); 
		_gem.name = "gem";
        _gem.GetComponent<Renderer>().material = gemMaterial;
        _gem.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        Rigidbody gemRigidBody = _gem.AddComponent<Rigidbody>(); // Add the rigidbody.
        var gemCollider = _gem.GetComponent<BoxCollider>();  
        _gem.AddComponent<InstantiateGem>();
        gemCollider.size = new Vector3(0.25f, 0.25f, 0.25f);
        gemRigidBody.mass = 2; 
    }

    // Update is called once per frame
    void Update()
    {

    }
  
}