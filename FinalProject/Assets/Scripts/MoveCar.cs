using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float speed = 10f; // ���� �ӵ�
    public float reverseSpeed = 5f; // ���� �ӵ�
    public float turnSpeed = 50f; // ȸ�� �ӵ�

    void Update()
    {
        // ����� �Է��� �����ɴϴ�.
        bool isForward = Input.GetKey(KeyCode.W); // W Ű
        bool isReverse = Input.GetKey(KeyCode.S); // S Ű
        bool isTurnLeft = Input.GetKey(KeyCode.A); // A Ű
        bool isTurnRight = Input.GetKey(KeyCode.D); // D Ű

        // ������ ���� �Ǵ� ���� ��ŵ�ϴ�.
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

        // ������ ȸ����ŵ�ϴ�.
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

