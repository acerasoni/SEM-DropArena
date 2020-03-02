using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCollision : MonoBehaviour
{

    private float _powerUpDuration;
    private int _currentPowerup;
    private bool _isPoweredUp;

    // Start is called before the first frame update
    void Start()
    {
        // Start with no powerups
        _isPoweredUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= _powerUpDuration + 5.0f && _isPoweredUp) {
            _isPoweredUp = false;
            resetPlayer();
        } 
    }

    void OnCollisionEnter(Collision collision){    	 

        GameObject player1 = GameObject.Find("_player1");

            // Check for collision with powerup   	
		 if (collision.gameObject.name == "_powerup" && _isPoweredUp == false)
		{

            _powerUpDuration = Time.time;
            _isPoweredUp = true;

            // Get the type of powerup
            _currentPowerup = getPowerupType();
            // Destroy the powerup object
            Destroy(collision.gameObject);

            switch(_currentPowerup) {

            case (int) InstantiatePowerups.PowerUps.sizePowerup:   
                this.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                break;


            case (int) InstantiatePowerups.PowerUps.speedPowerup:       
                  if(this.name == "_player1") {
                    player1.GetComponent<Movement>().movementBonusPlayer1 = 1.5f;
                  } else {
                    player1.GetComponent<Movement>().movementBonusPlayer1 = 1.5f;
                  }
                  break;


            case (int) InstantiatePowerups.PowerUps.massPowerup: 
                this.GetComponent<Rigidbody>().mass += 0.6f;    
                break;


            case (int) InstantiatePowerups.PowerUps.nofallPowerup: 
             if(this.name == "_player1") {
                    player1.GetComponent<Movement>().nudgeBonusPlayer1 = 2f;
                  } else {
                    player1.GetComponent<Movement>().nudgeBonusPlayer2 = 2f;
                  }
                  break;


            case (int) InstantiatePowerups.PowerUps.sizePowerdown: 
                 this.transform.localScale += new Vector3(-0.5f, -0.5f, -0.5f);
                  break;


            case (int) InstantiatePowerups.PowerUps.speedPowerdown:
             if(this.name == "_player1") {
                    player1.GetComponent<Movement>().movementBonusPlayer1 = 0.5f;
                  } else {
                    player1.GetComponent<Movement>().movementBonusPlayer1 = 0.5f;
                  }
                  break;


            case (int) InstantiatePowerups.PowerUps.massPowerdown: 
            this.GetComponent<Rigidbody>().mass -= 0.6f;    
                  break;


            case (int) InstantiatePowerups.PowerUps.freezePowerDown: 
            if(this.name == "_player1") {
                    player1.GetComponent<Movement>().freezePlayer1 = true;
                  } else {
                    player1.GetComponent<Movement>().freezePlayer2 = true;
                  }
                  break;

          }
		}

        }

        private int getPowerupType() {
            // Retrieve script attached to player1
        GameObject player1 = GameObject.Find("_player1");
        InstantiatePowerups instantiatePowerupScript = player1.GetComponent<InstantiatePowerups>();
        return instantiatePowerupScript.getPowerupType();
        }

        private void resetPlayer() {
            // Reset the scale
            this.transform.localScale = Vector3.one;

            // Reset the speed
            GameObject player1 = GameObject.Find("_player1");
            if(this.name == "_player1") {
                player1.GetComponent<Movement>().movementBonusPlayer1 = 1;
            }
            else  {
                player1.GetComponent<Movement>().movementBonusPlayer2 = 1;
            }

            // Reset the nofall
              if(this.name == "_player1") {
                    player1.GetComponent<Movement>().nudgeBonusPlayer1 = 0;
                  } else {
                    player1.GetComponent<Movement>().nudgeBonusPlayer2 = 0;
                  }

            // Reset the mass
            this.GetComponent<Rigidbody>().mass = 1f;

            // Reset the freeze
                if(this.name == "_player1") {
                    player1.GetComponent<Movement>().freezePlayer1 = false;
                  } else {
                    player1.GetComponent<Movement>().freezePlayer2 = false;
                  }
        }
  	
}
