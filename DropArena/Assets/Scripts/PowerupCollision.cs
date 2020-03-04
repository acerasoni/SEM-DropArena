using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupCollision : MonoBehaviour {

  private float _powerUpDuration;
  private int _currentPowerup;
  private bool _isPoweredUp;

  public TextMesh powerup;

  // Start is called before the first frame update
  void Start () {
    // Start with no powerups
    _isPoweredUp = false;
  }

  // Update is called once per frame
  void Update () {

    // Move the powerup text alongside the player
    Vector3 playerPosition = Camera.main.WorldToViewportPoint(this.transform.position);
    powerup.position = new Vector3(playerPosition.x*Screen.width + xDisp, playerPosition.y*Screen.height + yDisp, 40);

    if (Time.time >= _powerUpDuration + 5.0f && _isPoweredUp) {
      _isPoweredUp = false;
      powerup.text = "";
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
          if (this.name == "_player1") {
            powerup.text = "Player 1 Size PowerUp";
          } else {
            powerup.text = "Player 2 Size PowerUp";
          }
          this.transform.localScale += new Vector3 (0.5f, 0.5f, 0.5f);
          break;

        case (int) InstantiatePowerups.PowerUps.speedPowerup:
          if (this.name == "_player1") {
            powerup.text = "Player 1 Speed Power Up";
          } else {
            powerup.text = "Player 2 Speed Power Up";
          }
          this.GetComponent<Movement> ().setMovementBonus (1.5f);
          break;

        case (int) InstantiatePowerups.PowerUps.massPowerup:
          if (this.name == "_player1") {
            powerup.text = "Player 1 Mass Power Up";
          } else {
            powerup.text = "Player 2 Mass Power Up";
          }
          this.GetComponent<Rigidbody> ().mass += 0.6f;
          break;

        case (int) InstantiatePowerups.PowerUps.nofallPowerup:
          if (this.name == "_player1") {
            powerup.text = "Player 1 Force Power Up";
          } else {
            powerup.text = "Player 2 Force Power Up";
          }
          this.GetComponent<Movement> ().setNudgeBonus (2f);
          break;

        case (int) InstantiatePowerups.PowerUps.sizePowerdown:
          if (this.name == "_player1") {
            powerup.text = "Player 1 Size Power Down";
          } else {
            powerup.text = "Player 2 Size Power Down";
          }
          this.transform.localScale += new Vector3 (-0.5f, -0.5f, -0.5f);
          break;

        case (int) InstantiatePowerups.PowerUps.speedPowerdown:
          if (this.name == "_player1") {
            powerup.text = "Player 1 Speed Power Up";
          } else {
            powerup.text = "Player 2 Speed Power Up";
          }
          this.GetComponent<Movement> ().setMovementBonus (0.5f);
          break;

        case (int) InstantiatePowerups.PowerUps.massPowerdown:
          if (this.name == "_player1") {
            powerup.text = "Player 1 Mass Power Down";
          } else {
            powerup.text = "Player 2 Mass Power Down";
          }
          this.GetComponent<Rigidbody> ().mass -= 0.6f;
          break;

        case (int) InstantiatePowerups.PowerUps.freezePowerDown:
          if (this.name == "_player1") {
            powerup.text = "Player 1 Freeze";
          } else {
            powerup.text = "Player 2 Freeze";
          }
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