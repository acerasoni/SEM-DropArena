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
		 if (collision.gameObject.name == "gem")
		{
            if(this.name == "_player1"){
                 _chaser.setChasedPlayer(ChaserStateEnum.chasePlayer1);
                 moveGem();

            } else if(this.name == "_player2") {
                _chaser.setChasedPlayer(ChaserStateEnum.chasePlayer2);
                moveGem();
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
