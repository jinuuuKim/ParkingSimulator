using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpin : MonoBehaviour
{
    public float sensitivity = 100f; // ���콺 �ΰ���

    private float yaw = 0f; // �¿� ȸ����

    void Start()
    {
        // ���콺 Ŀ���� ȭ�鿡 ǥ���մϴ�.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        // ���콺 �Է°� ��������
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        // ī�޶��� Yaw(�¿� ����) ����
        yaw += mouseX;

        // ī�޶� ȸ�� ����
        transform.localRotation = Quaternion.Euler(0f, yaw, 0f);
    }
}
