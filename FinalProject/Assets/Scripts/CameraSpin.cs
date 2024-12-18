using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpin : MonoBehaviour
{
    public float sensitivity = 50f; // ���콺 �ΰ���
    public Camera driverViewCamera;   // ������ ���� ī�޶�
    public Camera parkingView1Camera; // ���� Ȯ�ο� ī�޶� 1
    public Camera parkingView2Camera; // ���� Ȯ�ο� ī�޶� 2

    private float yaw = 0f; // �¿� ȸ����
    private int currentViewIndex = 0; // ���� Ȱ��ȭ�� ������ �ε���
    private Camera[] cameras;        // ī�޶� �迭

    void Start()
    {
        // ���콺 Ŀ���� ȭ�鿡 ǥ���մϴ�.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // ī�޶� �迭 �ʱ�ȭ
        cameras = new Camera[] { driverViewCamera, parkingView1Camera, parkingView2Camera };

        // �ʱ� ���¿��� ������ ���� ī�޶� Ȱ��ȭ
        SetActiveCamera(0);
    }

    void Update()
    {
        RotateCamera();

        // O Ű �Է����� ī�޶� ��ȯ
        if (Input.GetKeyDown(KeyCode.O))
        {
            // ���� ī�޶�� ��ȯ (��ȯ ���)
            currentViewIndex = (currentViewIndex + 1) % cameras.Length;
            SetActiveCamera(currentViewIndex);
        }
    }

    void RotateCamera()
    {
        // ���콺 �Է°� ��������
        if (cameras[currentViewIndex] == driverViewCamera) // ���� Ȯ�� ���������� ī�޶� ȸ�� ��Ȱ��ȭ
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

            // ī�޶��� Yaw(�¿� ����) ����
            yaw += mouseX;

            // ī�޶� ȸ�� ����
            transform.localRotation = Quaternion.Euler(0f, yaw, 0f);
        }
    }

    void SetActiveCamera(int index)
    {
        // ��� ī�޶� ��Ȱ��ȭ
        foreach (Camera cam in cameras)
        {
            cam.enabled = false;
        }

        // ������ ī�޶� Ȱ��ȭ
        cameras[index].enabled = true;
    }
}
