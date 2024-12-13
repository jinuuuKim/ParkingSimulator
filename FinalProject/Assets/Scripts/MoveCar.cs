using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float acceleration = 15f; // ���ӵ�
    public float deceleration = 30f; // ���ӵ�
    public float maxSpeed = 20f; // �ִ� �ӵ�
    public float reverseMaxSpeed = 10f; // �ִ� ���� �ӵ�
    public float turnSpeed = 50f; // ȸ�� �ӵ�
    public float brakeForce = 50f; // �극��ũ ����

    private float currentSpeed = 0f; // ���� �ӵ�

    void Update()
    {
        HandleMovement();
        HandleSteering();
    }

    void HandleMovement()
    {
        bool isAccelerating = Input.GetKey(KeyCode.W); // W Ű
        bool isReversing = Input.GetKey(KeyCode.S); // S Ű
        bool isBraking = Input.GetKey(KeyCode.Space); // �����̽���

        if (isBraking)
        {
            // �극��ũ �켱 ����
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
            // ����
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, -reverseMaxSpeed, maxSpeed);
        }
        else if (isReversing)
        {
            // ����
            currentSpeed -= acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, -reverseMaxSpeed, maxSpeed);
        }
        else
        {
            // �ڿ� ����
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

        // ���� �̵�
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }

    void HandleSteering()
    {
        bool isTurningLeft = Input.GetKey(KeyCode.A); // A Ű
        bool isTurningRight = Input.GetKey(KeyCode.D); // D Ű

        float turn = 0f;
        if (isTurningLeft)
        {
            turn = -turnSpeed * Time.deltaTime;
        }
        else if (isTurningRight)
        {
            turn = turnSpeed * Time.deltaTime;
        }

        // ������ �����̰� ���� ���� ȸ��
        if (currentSpeed > 0)
        {
            transform.Rotate(0, turn, 0);
        }
        else if (currentSpeed < 0)
        {
            transform.Rotate(0, -turn, 0); // ���� �� ���� ����
        }
    }
}