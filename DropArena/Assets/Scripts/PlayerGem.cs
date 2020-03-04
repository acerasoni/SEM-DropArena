using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGem : MonoBehaviour
{

    private ChaserState _chaser;
    private int player;
    level lvl = new level();
    Score score = new Score();

    /**
     * @params
     * @return
     */
    void Start()
    {
    
    }

    /**
     * @params
     * @return
     */
    void Update()
    {
        
    }

    /**
     * @params collision object
     * @return
     */
    void OnCollisionEnter(Collision collision){    	 

            // Check for collision with gem   	
		 if (collision.gameObject.name == "gem")
		{
            GameObject.Find("GameObject").GetComponent<AudioSource>().Play();
                        
            if(this.name == "_player1"){
                 _chaser.setChasedPlayer(ChaserStateEnum.chasePlayer2);
                 moveGem(collision);

            } else if(this.name == "_player2") {
                _chaser.setChasedPlayer(ChaserStateEnum.chasePlayer1);
                moveGem(collision);
            }
		}

        // Check for collision with chaser
        if (collision.gameObject.name == "chaser")
		{
            if(this.name == "_player1" && _chaser.getChasedPlayer() == ChaserStateEnum.chasePlayer1){
                  //Application.LoadLevel("nextlevel");
                score.p2();
                lvl.levelloader();
             } else if(this.name == "_player2" && _chaser.getChasedPlayer() == ChaserStateEnum.chasePlayer2) {
                 //Application.LoadLevel("nextlevel");
                score.p1();
                lvl.levelloader();
             }
 		    }
        }

    /**
     * @params
     * @return
     */
    public void retrieveChaser() {
          _chaser = GameObject.Find("chaser").GetComponent<ChaserState>();
    }

    /**
     * @params collision object
     * @return
     */
    private void moveGem(Collision collision) {
            InstantiateGem script = GameObject.Find("gem").GetComponent<InstantiateGem>();
            script.generateNewPosition();
    }
}
