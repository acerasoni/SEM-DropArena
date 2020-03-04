using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
        private TextMesh _resultText;
        public GameObject resultObject;

    /**
     * @params
     * @return
     */
    void Start()
    {
        _resultText = resultObject.GetComponent<TextMesh> ();
    }

    /**
     * @params
     * @return
     */
    void Update()
    {
        result();
    }

        /**
     * @params
     * @return
     */
        public void result(){
        if (Score.player1Score > Score.player2Score)
        {
            _resultText.text = "Player 1 wins! \n Better luck next time Player 2";
        }
        if (Score.player1Score < Score.player2Score)
        {
            _resultText.text = "Player 2 wins! \n Better luck next time Player 1";
        }
        if (Score.player1Score == Score.player2Score)
        {
            _resultText.text = "DRAW!";
        }
    }
}
