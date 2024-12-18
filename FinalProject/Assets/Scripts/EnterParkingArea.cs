using UnityEngine;
using System.Collections;

public class ParkingAreaManager : MonoBehaviour
{
    public Transform enterParkingAreaPopup; // EnterGarage �˾� UI ������Ʈ

    private bool isInsideParkingAreaZone = false; // ������ GarageZone�� �ִ��� ����

    void OnTriggerEnter(Collider other)
    {
        // GarageZone�� ������ ������Ʈ�� "Player" �±׸� ���� ���
        if (other.CompareTag("Player"))
        {
            isInsideParkingAreaZone = true;
            ShowPopup(enterParkingAreaPopup); // EnterGarage �˾� Ȱ��ȭ
            Debug.Log("Car entered the GarageZone.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // GarageZone�� ��� ������Ʈ�� "Player" �±׸� ���� ���
        if (other.CompareTag("Player"))
        {
            isInsideParkingAreaZone = false;
            Debug.Log("Car exited the GarageZone.");
        }
    }

    void ShowPopup(Transform popup)
    {
        popup.gameObject.SetActive(true); // �˾� Ȱ��ȭ

        // �˾��� �ڵ��� �տ� ��ġ
        Transform playerCar = GameObject.FindWithTag("Player").transform;
        Vector3 popupPosition = playerCar.position + playerCar.forward * 6 + Vector3.up * 1;
        popup.position = popupPosition;

        // �˾��� ������ �ٶ󺸵��� ����
        popup.LookAt(playerCar);

        // 4�� �� �˾� ��Ȱ��ȭ
        StartCoroutine(HidePopupAfterDelay(popup, 5f));
    }

    IEnumerator HidePopupAfterDelay(Transform popup, float delay)
    {
        yield return new WaitForSeconds(delay);
        popup.gameObject.SetActive(false); // �˾� ��Ȱ��ȭ
    }
}
