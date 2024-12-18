using UnityEngine;
using System.Collections;

public class GarageManager : MonoBehaviour
{
    public Transform enterGaragePopup; // EnterGarage 팝업 UI 오브젝트

    private bool isInsideGarageZone = false; // 차량이 GarageZone에 있는지 여부

    void OnTriggerEnter(Collider other)
    {
        // GarageZone에 진입한 오브젝트가 "Player" 태그를 가진 경우
        if (other.CompareTag("Player"))
        {
            isInsideGarageZone = true;
            ShowPopup(enterGaragePopup); // EnterGarage 팝업 활성화
            Debug.Log("Car entered the GarageZone.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // GarageZone을 벗어난 오브젝트가 "Player" 태그를 가진 경우
        if (other.CompareTag("Player"))
        {
            isInsideGarageZone = false;
            Debug.Log("Car exited the GarageZone.");
        }
    }

    void ShowPopup(Transform popup)
    {
        popup.gameObject.SetActive(true); // 팝업 활성화

        // 팝업을 자동차 앞에 위치
        Transform playerCar = GameObject.FindWithTag("Player").transform;
        Vector3 popupPosition = playerCar.position + playerCar.forward * 6 + Vector3.up * 1;
        popup.position = popupPosition;

        // 팝업이 차량을 바라보도록 설정
        popup.LookAt(playerCar);

        // 4초 후 팝업 비활성화
        StartCoroutine(HidePopupAfterDelay(popup, 4f));
    }

    IEnumerator HidePopupAfterDelay(Transform popup, float delay)
    {
        yield return new WaitForSeconds(delay);
        popup.gameObject.SetActive(false); // 팝업 비활성화
    }
}
