﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;

    private Ball ball;

    void Start () {
        ball = FindObjectOfType<Ball>();
    }

	// Update is called once per frame
	void Update () {
        if (autoPlay == false) {
            MoveWithMouse();
        } else {
            AutoPlay();
        }
	}

    void AutoPlay() {
        Vector3 paddlePos = new Vector3(0.781f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 0.781f, 15.218f);
        this.transform.position = paddlePos;
    }

    void MoveWithMouse() {
        Vector3 paddlePos = new Vector3(0.781f, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.781f, 15.218f);
        this.transform.position = paddlePos;
    }
}
