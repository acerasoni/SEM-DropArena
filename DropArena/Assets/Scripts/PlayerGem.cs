﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGem : MonoBehaviour
{

    private ChaserState _chaser;
    private int player;
    level lvl = new level();
    Score score = new Score();

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
                score.p1();
                lvl.levelloader();
             } else if(this.name == "_player2" && _chaser.getChasedPlayer() == ChaserStateEnum.chasePlayer2) {
                 //Application.LoadLevel("nextlevel");
                score.p2();
                lvl.levelloader();
             }
 		    }
        }
  	
	public void retrieveChaser() {
          _chaser = GameObject.Find("chaser").GetComponent<ChaserState>();
    }

    private void moveGem(Collision collision) {
            InstantiateGem script = GameObject.Find("gem").GetComponent<InstantiateGem>();
            script.generateNewPosition();
    }
}
