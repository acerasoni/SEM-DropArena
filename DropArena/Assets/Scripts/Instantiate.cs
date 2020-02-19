using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject Chaser;
    public GameObject Cube;
    Vector3 Pos;
    // Start is called before the first frame update
    void Start()
    {   
        while (GameObject.FindGameObjectsWithTag("chaser").Length <= 2)
        {
            Create();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Create(){
        Pos = new Vector3(4f, 0, 4f);
		GameObject Chaser = (GameObject)Instantiate( Cube, Pos, transform.rotation);
		Chaser.name = "chaser";
        Chaser.tag = "chaser";
		
    }
}
