using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public static int player1Score;
    public static int player2Score;

    private TextMesh _scoreText;

    // Start is called before the first frame update
    void Start () {
        _scoreText = this.GetComponent<TextMesh> ();
    }

    // Update is called once per frame
    void Update () {
        _scoreText.text = player1Score + " - " + player2Score;
    }

    public void p1 () {
        player1Score++;
    }
    public void p2 () {
        player2Score++;
    }
}