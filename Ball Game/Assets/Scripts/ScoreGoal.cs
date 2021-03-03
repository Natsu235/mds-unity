using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGoal : MonoBehaviour
{
    private GameObject _player1;         // Orange Girl
    private GameObject _player2;         // Blue Girl
    private GameObject _ball;
    private GameObject _orangeGoal;
    private GameObject _blueGoal;

    private Vector3 _player1OriginalPos;    // Player 1 Default Position
    private Vector3 _player2OriginalPos;    // Player 2 Default Position
    private Vector3 _ballOriginalPos;       // Ball Default Position

    private void Awake() {
        _player1 = GameObject.Find("Player 1");
        _player2 = GameObject.Find("Player 2");
        _ball = GameObject.Find("Ball");
        _orangeGoal = GameObject.Find("Orange Goal");
        _blueGoal = GameObject.Find("Blue Ball");
    }

    // Start is called before the first frame update
    void Start()
    {
        _player1OriginalPos = new Vector3(_player1.transform.position.x, _player1.transform.position.y);
        _player2OriginalPos = new Vector3(_player2.transform.position.x, _player2.transform.position.y);
        _ballOriginalPos = new Vector3(_ball.transform.position.x, _ball.transform.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private IEnumerator OnTriggerEnter2D(Collider2D col2D) {
        if (col2D.gameObject.CompareTag("Ball")) {
            if (gameObject.name == "Orange Goal") {
                Debug.Log("Player 2 Scored!");
            }
            else if (gameObject.name == "Blue Goal") {
                Debug.Log("Player 1 Scored!");
            }

            ResetRound();
            PauseGame();
            yield return new WaitForSeconds(3);
            ResumeGame();
        }
    }

    private void ResetRound() {
        _player1.transform.position = _player1OriginalPos;
        _player2.transform.position = _player2OriginalPos;
        _ball.transform.position = _ballOriginalPos;
    }

    private void PauseGame() {
        Time.timeScale = 0;
    }

    private void ResumeGame() {
        Time.timeScale = 1;
    }
}
