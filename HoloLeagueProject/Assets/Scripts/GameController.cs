using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private int redScore;
    private int blueScore;
    public int maxScore = 5;
    private GameObject field;
    private GameObject ball;
    private GameObject redCar;
    private GameObject blueCar;

    // Use this for initialization
    void Start () {
        redScore = 0;
        blueScore = 0;
        field = GameObject.FindGameObjectWithTag("FieldSystem");
        redCar = GameObject.FindGameObjectWithTag("TEMPREDCARNAME");
        blueCar = GameObject.FindGameObjectWithTag("TEMPBLUECARNAME");
        ball = GameObject.FindGameObjectWithTag("TEMPBALLNAME");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void redGoal() {
        redScore++;
        detectGoal();
    }

    void blueGoal() {
        blueScore++;
        detectGoal();
    }

    void resetPosition() {
        ComputeBoundary compBoundary = field.GetComponent<ComputeBoundary>();
        float FLength = compBoundary.fieldLength;
        float FWidth = compBoundary.fieldWidth;
        Vector3 CPos = compBoundary.centerPos;
        ball.transform.position = CPos;
        redCar.transform.position = (FLength - CPos) / 2;
        blueCar.transform.position = - (FLength - CPos) / 2;
    }

    void detectGoal() {
        if (blueScore == maxScore || redScore == maxScore) {
            GG();
        } else {
            resetPosition();
        }
    }

    void GG() {
        Debug.Log("Game Over");
        Debug.Log("Red Score: " + redScore);
        Debug.Log("Blue Score: " + blueScore);
    }


}
