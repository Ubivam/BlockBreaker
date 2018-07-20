using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    private Ball ball;
    // Update is called once per frame
    private void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }
    void Update () {
        if (autoPlay)
        {
            MachenePlay();
        }
        else
        {
            MousePlay();
        }
    }
    void MousePlay()
    {
        Vector3 paddlePos = new Vector3(1f, this.transform.position.y, 0f);
        float moustBlockPosition = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(moustBlockPosition, 1, 15);
        this.transform.position = paddlePos;
    }
    void MachenePlay()
    {
        Vector3 paddlePos = new Vector3(1f, this.transform.position.y, 0f);
        Vector3 ballPosition = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPosition.x, 1, 15);
        this.transform.position = paddlePos;
    }
}
