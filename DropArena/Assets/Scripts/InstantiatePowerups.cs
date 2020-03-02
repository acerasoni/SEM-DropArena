using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePowerups : MonoBehaviour
{   

    private enum PowerUps{
        sizePowerup = 0,
        speedPowerup =  1,
        massPowerup = 2,
        nofallPowerup = 3,
        sizePowerdown = 4,
        speedPowerdown = 5,
        massPowerdown = 6,
        freezePowerDown = 7
    }
    
    // Powerup materials
    public Material positiveMaterial;
    public Material negativeMaterial;

    // Current time
    private float _time;
    private float _powerupSpawnDelay;
    private int currentPowerup;

    // Positive powerups
    public GameObject powerup;

    // Start is called before the first frame update
    void Start()
    {
        _time = Time.time;
        _powerupSpawnDelay = 5.0f;
        generatePowerup();
    }

    // Update is called once per frame
    void Update()
    {
        // Every 5.0 seconds, spawn a new powerup
        // Destroy previous one if it exists
        if(Time.time >= _time + _powerupSpawnDelay){
            generatePowerup();
            _time = Time.time;
        }   
    }

    private void generatePowerup() {
        // Randomly select one powerup
        currentPowerup = Random.Range(0, 8);

        switch(currentPowerup) {
            case (int) PowerUps.sizePowerup: 
               powerup = GameObject.CreatePrimitive(PrimitiveType.Capsule); break;
            case (int) PowerUps.speedPowerup: 
               powerup = GameObject.CreatePrimitive(PrimitiveType.Capsule); break;
            case (int) PowerUps.massPowerup: 
               powerup = GameObject.CreatePrimitive(PrimitiveType.Capsule); break;
            case (int) PowerUps.nofallPowerup: 
               powerup = GameObject.CreatePrimitive(PrimitiveType.Capsule); break;
            case (int) PowerUps.sizePowerdown: 
               powerup = GameObject.CreatePrimitive(PrimitiveType.Cylinder); break;
            case (int) PowerUps.speedPowerdown:
               powerup = GameObject.CreatePrimitive(PrimitiveType.Quad); break;
            case (int) PowerUps.massPowerdown: 
               powerup = GameObject.CreatePrimitive(PrimitiveType.Quad); break;
            case (int) PowerUps.freezePowerDown: 
               powerup = GameObject.CreatePrimitive(PrimitiveType.Quad); break;
        }

        powerup.transform.localScale += new Vector3(-0.85f, -0.85f, -0.85f);
        powerup.transform.position = generateRandomPosition();
        Rigidbody powerupBody = powerup.AddComponent<Rigidbody>(); // Add the rigidbody.

        powerupBody.mass = 2;

        // Kills the game object in 5.0 seconds after loading the object
        Destroy(powerup, _powerupSpawnDelay);
    }

    private Vector3 generateRandomPosition() {
         return new Vector3(Random.Range(0, 5.0f), 0.49f, Random.Range(0, 5.0f));
    }

}
