using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserMovement : MonoBehaviour
{

public GameObject player1;
public GameObject player2;

public GameObject chaser;
public Rigidbody chaserBody;
public int target; // 0 - nobody, 1 - player1, 2 - player2

    // Start is called before the first frame update
    void Start()
    {
        chaserBody = GetComponent<Rigidbody>();
        target = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody sphereBody;

        if(target == 0) {
                return;
        } else if(target == 1) {
                sphereBody = player1.GetComponent<Rigidbody>();
        } else {
                sphereBody = player2.GetComponent<Rigidbody>();
        }

        float x = 0;
        float z = 0;

	if(chaserBody.position.x >= sphereBody.position.x) 
    {
        x = -0.05f;
    } else if(chaserBody.position.x < sphereBody.position.x)
    {
        x = 0.05f;
    }

   	if(chaserBody.position.z >= sphereBody.position.z)
    {
        z = -0.05f;
    } else if(chaserBody.position.z < sphereBody.position.z) 
    {
        z = 0.05f;
    }
    	transform.Translate(x, 0, z);
    }
}
