using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleController : MonoBehaviour
{
    public Transform ball;
    public float reactionSpeed = 1.0f;
    public float minX = -10.5f;  // ����AI���ƶ�����Сxֵ
    public float maxX = 10.5f;   // ����AI���ƶ������xֵ

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
        if (ball.GetComponent<Rigidbody>().velocity.z > 0) // ���С���Ƿ���AI
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
            // С����AI�ķ�����룬��λAI��λ��
            float newXPosition = Mathf.MoveTowards(transform.position.x,
                                        0f, reactionSpeed * Time.deltaTime);
            transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
        }
    }
}


