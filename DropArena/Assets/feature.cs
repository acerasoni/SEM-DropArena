using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feature : MonoBehaviour
{
    public float movementSpeed = 6.0f;
    private Vector3 horizontalMovement;
    private Vector3 verticalMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * Vector3.right * movementSpeed;
        verticalMovement = Input.GetAxis("Vertical") * Vector3.forward * movementSpeed;
        Vector3 movement = horizontalMovement + verticalMovement;
        
    }
}
