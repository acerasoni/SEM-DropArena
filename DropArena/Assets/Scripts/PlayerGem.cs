using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGem : MonoBehaviour
{

    private ChaserState _chaser;
    private int player;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        void OnCollisionEnter(Collision collision){    	 

            // Check for collision with gem   	
		 if (collision.gameObject.name == "gem")
		{
            if(this.name == "_player1"){
                 _chaser.setChasedPlayer(ChaserStateEnum.chasePlayer2);
                 moveGem();

            } else if(this.name == "_player2") {
                _chaser.setChasedPlayer(ChaserStateEnum.chasePlayer1);
                moveGem();
            }
		}

        // Check for collision with chaser
        if (collision.gameObject.name == "chaser")
		{
            if(this.name == "_player1" && _chaser.getChasedPlayer() == ChaserStateEnum.chasePlayer1){
                  Application.LoadLevel("nextlevel");
             } else if(this.name == "_player2" && _chaser.getChasedPlayer() == ChaserStateEnum.chasePlayer2) {
                 Application.LoadLevel("nextlevel");
             }
 		    }
        }
  	
	public void retrieveChaser() {
          _chaser = GameObject.Find("chaser").GetComponent<ChaserState>();
    }

    private void moveGem() {
            Instantiate script = GameObject.Find("_player1").GetComponent<Instantiate>();
            Vector3 newGemPos = script.generateRandomPosition();

            GameObject gem = GameObject.Find("gem");
            gem.transform.position = newGemPos;
    }
}
