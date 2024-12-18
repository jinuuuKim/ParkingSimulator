using UnityEngine;
using UnityEngine.UI; // UI 요소를 제어하기 위해 필요
using System.Collections;

public class StartAreaManager : MonoBehaviour
{
    public Transform enterStartAreaPopup; // EnterStartArea 팝업 UI 오브젝트
    public Image popupImage; // 팝업에 표시할 이미지 (Inspector에서 연결)

    private bool isInsideStartAreaZone = false; // 차량이 StartZone에 있는지 여부

    void OnTriggerEnter(Collider other)
    {
        // StartZone에 진입한 오브젝트가 "Player" 태그를 가진 경우
        if (other.CompareTag("Player"))
        {
            isInsideStartAreaZone = true;
            ShowPopup(enterStartAreaPopup); // StartZone 팝업 활성화
            Debug.Log("Car entered the StartZone.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // StartZone을 벗어난 오브젝트가 "Player" 태그를 가진 경우
        if (other.CompareTag("Player"))
        {
            isInsideStartAreaZone = false;
            Debug.Log("Car exited the StartZone.");
        }
    }

    void ShowPopup(Transform popup)
    {
        popup.gameObject.SetActive(true); // 팝업 활성화

        // 팝업의 이미지 설정
        if (popupImage != null)
        {
            popupImage.sprite = Resources.Load<Sprite>("Minimap"); // Resources 폴더에서 Minimap 이미지 로드
        }

        // 팝업을 자동차 앞에 위치
        Transform playerCar = GameObject.FindWithTag("Player").transform;
        Vector3 popupPosition = playerCar.position + playerCar.forward * 9 + Vector3.up * 1;
        popup.position = popupPosition;

        // 팝업이 차량을 바라보도록 설정
        popup.LookAt(playerCar);

        // 4초 후 팝업 비활성화
        StartCoroutine(HidePopupAfterDelay(popup, 6f));
    }

    IEnumerator HidePopupAfterDelay(Transform popup, float delay)
    {
        yield return new WaitForSeconds(delay);
        popup.gameObject.SetActive(false); // 팝업 비활성화
    }
}
