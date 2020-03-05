using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraPosition : MonoBehaviour

{
    private float _time = 6f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _time -= Time.deltaTime;
         if (_time < 0)
         {
            GameObject.Find("Main Camera").transform.position = new Vector3(3.95f, 7.3f, -5.5f);             
         }  
    }
}
