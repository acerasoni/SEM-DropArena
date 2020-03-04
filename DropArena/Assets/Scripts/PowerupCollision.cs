using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupCollision : MonoBehaviour {

  public GameObject powerupObject;

  // Powerup state
  private TextMesh _powerupText;
  private float _powerUpDuration;
  private int _currentPowerup;
  private bool _isPoweredUp;

  // Start is called before the first frame update
  void Start () {
    _powerupText = powerupObject.GetComponent<TextMesh> ();

    // Start with no powerups
    _isPoweredUp = false;
  }

  // Update is called once per frame
  void Update () {

    // Move the powerup text alongside the player
    powerupObject.transform.position = new Vector3 (this.transform.position.x - 0.25f, this.transform.position.y + 0.5f, this.transform.position.z);

    if (Time.time >= _powerUpDuration + 5.0f && _isPoweredUp) {
      _isPoweredUp = false;
      _powerupText.text = "";
      resetPlayer ();
    }
  }

  void OnCollisionEnter (Collision collision) {

    // Check for collision with powerup   	
    if (collision.gameObject.name == "_powerup" && _isPoweredUp == false) {

      _powerUpDuration = Time.time;
      _isPoweredUp = true;

      // Get the type of powerup
      _currentPowerup = getPowerupType ();

      // Destroy the powerup object
      Destroy (collision.gameObject);

      switch (_currentPowerup) {

        case (int) InstantiatePowerups.PowerUps.sizePowerup:
          _powerupText.text = "You're a giant!";
          this.transform.localScale += new Vector3 (0.5f, 0.5f, 0.5f);
          break;

        case (int) InstantiatePowerups.PowerUps.speedPowerup:
          _powerupText.text = "You're much faster!";
          this.GetComponent<Movement> ().setMovementBonus (2.5f);
          break;

        case (int) InstantiatePowerups.PowerUps.massPowerup:
          _powerupText.text = "You're much heavier!";
          this.GetComponent<Rigidbody> ().mass += 0.6f;
          break;

        case (int) InstantiatePowerups.PowerUps.nofallPowerup:
          _powerupText.text = "It's hard to fall off the edge.";
          this.GetComponent<Movement> ().setNudgeBonus (4f);
          break;

        case (int) InstantiatePowerups.PowerUps.sizePowerdown:
          _powerupText.text = "You're very tiny now.";
          this.transform.localScale += new Vector3 (-0.5f, -0.5f, -0.5f);
          break;

        case (int) InstantiatePowerups.PowerUps.speedPowerdown:
          _powerupText.text = "You're slower, be careful.";
          this.GetComponent<Movement> ().setMovementBonus (0.5f);
          break;

        case (int) InstantiatePowerups.PowerUps.massPowerdown:
          _powerupText.text = "You're lighter. That's bad.";
          this.GetComponent<Rigidbody> ().mass -= 0.6f;
          break;

        case (int) InstantiatePowerups.PowerUps.freezePowerDown:
          _powerupText.text = "You can't move for now.";
          this.GetComponent<Movement> ().setFreeze (true);
          break;

      }
    }

  }

  private int getPowerupType () {
    // Retrieve script attached to player1
    GameObject player1 = GameObject.Find ("_player1");
    InstantiatePowerups instantiatePowerupScript = player1.GetComponent<InstantiatePowerups> ();
    return instantiatePowerupScript.getPowerupType ();
  }

  private void resetPlayer () {
    // Reset the scale
    this.transform.localScale = Vector3.one;

    // Reset the speed
    this.GetComponent<Movement> ().setMovementBonus (1);

    // Reset the nofall
    this.GetComponent<Movement> ().setNudgeBonus (0);

    // Reset the mass
    this.GetComponent<Rigidbody> ().mass = 1f;

    // Reset the freeze
    this.GetComponent<Movement> ().setFreeze (false);
  }

}