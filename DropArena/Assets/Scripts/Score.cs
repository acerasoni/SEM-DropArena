using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject scoreObject;
    private TextMesh _scoreText;
    public static int player1Score;
    public static int player2Score;


    /**
     * @params
     * @return
     */
    void Start()
    {
        _scoreText = scoreObject.GetComponent<TextMesh> ();
    }


    /**
     * @params
     * @return
     */
    void Update()
    {
        _scoreText.text = player1Score +" - " + player2Score;
    }

    /**
     * @params
     * @return
     */
    public void p1()
    {
        player1Score++;
    }

    /**
     * @params
     * @return
     */
    public void p2()
    {
        player2Score++;
    }
}
