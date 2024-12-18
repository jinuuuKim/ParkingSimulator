using UnityEngine;
using System.Collections;

public class ParkingManager : MonoBehaviour
{
    public Transform successPopup; // 성공 팝업 UI 오브젝트
    public Transform failurePopup; // 실패 팝업 UI 오브젝트

    private static ParkingManager activeParkingZone; // 현재 활성 주차 영역

    private bool isInsideParkingZone = false; // 차량이 주차 공간에 있는지 여부

    void OnTriggerEnter(Collider other)
    {
        // 주차 공간에 진입한 오브젝트가 "Player" 태그를 가진 경우
        if (other.CompareTag("Player"))
        {
            isInsideParkingZone = true;
            activeParkingZone = this; // 현재 주차 영역을 활성화
            Debug.Log("Car entered the parking zone.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // 주차 공간을 벗어난 오브젝트가 "Player" 태그를 가진 경우
        if (other.CompareTag("Player"))
        {
            isInsideParkingZone = false;
            if (activeParkingZone == this) activeParkingZone = null; // 활성 주차 영역 해제
            Debug.Log("Car exited the parking zone.");
        }
    }

    void Update()
    {
        // P 키를 누르면 성공/실패 팝업을 표시
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (activeParkingZone == this && isInsideParkingZone)
            {
                ShowPopup(successPopup); // 성공 팝업 활성화
                Debug.Log("Parking Success!");
            }
            else if (activeParkingZone == null || (activeParkingZone == this && !isInsideParkingZone))
            {
                ShowPopup(failurePopup); // 실패 팝업 활성화
                Debug.Log("Parking Failure!");
            }
        }
    }


    void ShowPopup(Transform popup)
    {
        popup.gameObject.SetActive(true); // 팝업 활성화

        // 팝업을 자동차 앞에 위치
        Transform playerCar = GameObject.FindWithTag("Player").transform;
        Vector3 popupPosition = playerCar.position + playerCar.forward * 4 + Vector3.up * 1;
        popup.position = popupPosition;

        // 팝업이 차량을 바라보도록 설정
        popup.LookAt(playerCar);

        // 2초 후 팝업 비활성화
        StartCoroutine(HidePopupAfterDelay(popup, 2f));
    }

    IEnumerator HidePopupAfterDelay(Transform popup, float delay)
    {
        yield return new WaitForSeconds(delay);
        popup.gameObject.SetActive(false); // 팝업 비활성화
    }


}
