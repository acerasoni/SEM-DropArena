using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{

    public Material chaserMaterial;
    private Vector3 _chaserPos;
    private Vector3 _gemPos;
    private GameObject _chaser;
    private GameObject _gem;
    
    /**
     * @params
     * @return
     */
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
    }

    /**
     * @params
     * @return
     */
    void Update()
    {

    }
  
}