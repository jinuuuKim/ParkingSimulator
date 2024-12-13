using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpin : MonoBehaviour
{
    public float sensitivity = 100f; // 마우스 민감도

    private float yaw = 0f; // 좌우 회전값

    void Start()
    {
        // 마우스 커서를 화면에 표시합니다.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        // 마우스 입력값 가져오기
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        // 카메라의 Yaw(좌우 각도) 조정
        yaw += mouseX;

        // 카메라 회전 적용
        transform.localRotation = Quaternion.Euler(0f, yaw, 0f);
    }
}
