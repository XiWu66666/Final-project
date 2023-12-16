using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleController : MonoBehaviour
{
    public Transform ball;
    public float reactionSpeed = 1.0f;
    public float minX = -10.5f;  // 敌人AI能移动的最小x值
    public float maxX = 10.5f;   // 敌人AI能移动的最大x值

    private Vector3 lastBallPosition;

    void Start()
    {
        lastBallPosition = ball.position;
    }

    void Update()
    {
        UpdatePaddlePositionBasedOnBallDirection();
        lastBallPosition = ball.position;
    }

    void UpdatePaddlePositionBasedOnBallDirection()
    {
        if (ball.GetComponent<Rigidbody>().velocity.z > 0) // 检查小球是否朝着AI
        {
            float relativeBallPosition = ball.position.x - transform.position.x;
            float predictedBallPosition = ball.position.x + ball.GetComponent<Rigidbody>().velocity.x *
                                          (transform.position.z - ball.position.z) / ball.GetComponent<Rigidbody>().velocity.z;
            float newXPosition = Mathf.MoveTowards(transform.position.x,
                                        predictedBallPosition, reactionSpeed * Time.deltaTime);
            newXPosition = Mathf.Clamp(newXPosition, minX, maxX);
            transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
        }
        else
        {
            // 小球朝着AI的方向进入，则复位AI的位置
            float newXPosition = Mathf.MoveTowards(transform.position.x,
                                        0f, reactionSpeed * Time.deltaTime);
            transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
        }
    }
}


