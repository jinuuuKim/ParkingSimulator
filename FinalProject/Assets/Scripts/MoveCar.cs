using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float acceleration = 15f; // 가속도
    public float deceleration = 30f; // 감속도
    public float maxSpeed = 20f; // 최대 속도
    public float reverseMaxSpeed = 10f; // 최대 후진 속도
    public float turnSpeed = 50f; // 회전 속도
    public float brakeForce = 50f; // 브레이크 강도

    private float currentSpeed = 0f; // 현재 속도

    void Update()
    {
        HandleMovement();
        HandleSteering();
    }

    void HandleMovement()
    {
        bool isAccelerating = Input.GetKey(KeyCode.W); // W 키
        bool isReversing = Input.GetKey(KeyCode.S); // S 키
        bool isBraking = Input.GetKey(KeyCode.Space); // 스페이스바

        if (isBraking)
        {
            // 브레이크 우선 적용
            if (currentSpeed > 0)
            {
                currentSpeed -= brakeForce * Time.deltaTime;
                currentSpeed = Mathf.Max(currentSpeed, 0f);
            }
            else if (currentSpeed < 0)
            {
                currentSpeed += brakeForce * Time.deltaTime;
                currentSpeed = Mathf.Min(currentSpeed, 0f);
            }
        }
        else if (isAccelerating)
        {
            // 가속
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, -reverseMaxSpeed, maxSpeed);
        }
        else if (isReversing)
        {
            // 후진
            currentSpeed -= acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, -reverseMaxSpeed, maxSpeed);
        }
        else
        {
            // 자연 감속
            if (currentSpeed > 0)
            {
                currentSpeed -= deceleration * Time.deltaTime;
                currentSpeed = Mathf.Max(currentSpeed, 0f);
            }
            else if (currentSpeed < 0)
            {
                currentSpeed += deceleration * Time.deltaTime;
                currentSpeed = Mathf.Min(currentSpeed, 0f);
            }
        }

        // 차량 이동
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }

    void HandleSteering()
    {
        bool isTurningLeft = Input.GetKey(KeyCode.A); // A 키
        bool isTurningRight = Input.GetKey(KeyCode.D); // D 키

        float turn = 0f;
        if (isTurningLeft)
        {
            turn = -turnSpeed * Time.deltaTime;
        }
        else if (isTurningRight)
        {
            turn = turnSpeed * Time.deltaTime;
        }

        // 차량이 움직이고 있을 때만 회전
        if (currentSpeed > 0)
        {
            transform.Rotate(0, turn, 0);
        }
        else if (currentSpeed < 0)
        {
            transform.Rotate(0, -turn, 0); // 후진 시 방향 반전
        }
    }
}