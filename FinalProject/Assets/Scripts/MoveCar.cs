using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float speed = 10f; // 전진 속도
    public float reverseSpeed = 5f; // 후진 속도
    public float turnSpeed = 50f; // 회전 속도

    void Update()
    {
        // 사용자 입력을 가져옵니다.
        bool isForward = Input.GetKey(KeyCode.W); // W 키
        bool isReverse = Input.GetKey(KeyCode.S); // S 키
        bool isTurnLeft = Input.GetKey(KeyCode.A); // A 키
        bool isTurnRight = Input.GetKey(KeyCode.D); // D 키

        // 차량을 전진 또는 후진 시킵니다.
        float moveSpeed = 0f;
        if (isForward)
        {
            moveSpeed = speed * Time.deltaTime;
        }
        else if (isReverse)
        {
            moveSpeed = -reverseSpeed * Time.deltaTime;
        }
        transform.Translate(Vector3.forward * moveSpeed);

        // 차량을 회전시킵니다.
        float turn = 0f;
        if (isTurnLeft)
        {
            turn = -turnSpeed * Time.deltaTime;
        }
        else if (isTurnRight)
        {
            turn = turnSpeed * Time.deltaTime;
        }
        transform.Rotate(0, turn, 0);
    }
}

