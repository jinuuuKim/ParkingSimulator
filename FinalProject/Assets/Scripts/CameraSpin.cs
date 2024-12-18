using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpin : MonoBehaviour
{
    public float sensitivity = 50f; // 마우스 민감도
    public Camera driverViewCamera;   // 운전자 시점 카메라
    public Camera parkingView1Camera; // 주차 확인용 카메라 1
    public Camera parkingView2Camera; // 주차 확인용 카메라 2

    private float yaw = 0f; // 좌우 회전값
    private int currentViewIndex = 0; // 현재 활성화된 시점의 인덱스
    private Camera[] cameras;        // 카메라 배열

    void Start()
    {
        // 마우스 커서를 화면에 표시합니다.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // 카메라 배열 초기화
        cameras = new Camera[] { driverViewCamera, parkingView1Camera, parkingView2Camera };

        // 초기 상태에서 운전자 시점 카메라 활성화
        SetActiveCamera(0);
    }

    void Update()
    {
        RotateCamera();

        // O 키 입력으로 카메라 전환
        if (Input.GetKeyDown(KeyCode.O))
        {
            // 다음 카메라로 전환 (순환 방식)
            currentViewIndex = (currentViewIndex + 1) % cameras.Length;
            SetActiveCamera(currentViewIndex);
        }
    }

    void RotateCamera()
    {
        // 마우스 입력값 가져오기
        if (cameras[currentViewIndex] == driverViewCamera) // 주차 확인 시점에서는 카메라 회전 비활성화
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

            // 카메라의 Yaw(좌우 각도) 조정
            yaw += mouseX;

            // 카메라 회전 적용
            transform.localRotation = Quaternion.Euler(0f, yaw, 0f);
        }
    }

    void SetActiveCamera(int index)
    {
        // 모든 카메라 비활성화
        foreach (Camera cam in cameras)
        {
            cam.enabled = false;
        }

        // 선택한 카메라만 활성화
        cameras[index].enabled = true;
    }
}
