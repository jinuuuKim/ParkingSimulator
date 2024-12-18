using UnityEngine;
using System.Collections;

public class ParkingManager : MonoBehaviour
{
    public Transform successPopup; // ���� �˾� UI ������Ʈ
    public Transform failurePopup; // ���� �˾� UI ������Ʈ

    private static ParkingManager activeParkingZone; // ���� Ȱ�� ���� ����

    private bool isInsideParkingZone = false; // ������ ���� ������ �ִ��� ����

    void OnTriggerEnter(Collider other)
    {
        // ���� ������ ������ ������Ʈ�� "Player" �±׸� ���� ���
        if (other.CompareTag("Player"))
        {
            isInsideParkingZone = true;
            activeParkingZone = this; // ���� ���� ������ Ȱ��ȭ
            Debug.Log("Car entered the parking zone.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // ���� ������ ��� ������Ʈ�� "Player" �±׸� ���� ���
        if (other.CompareTag("Player"))
        {
            isInsideParkingZone = false;
            if (activeParkingZone == this) activeParkingZone = null; // Ȱ�� ���� ���� ����
            Debug.Log("Car exited the parking zone.");
        }
    }

    void Update()
    {
        // P Ű�� ������ ����/���� �˾��� ǥ��
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (activeParkingZone == this && isInsideParkingZone)
            {
                ShowPopup(successPopup); // ���� �˾� Ȱ��ȭ
                Debug.Log("Parking Success!");
            }
            else if (activeParkingZone == null || (activeParkingZone == this && !isInsideParkingZone))
            {
                ShowPopup(failurePopup); // ���� �˾� Ȱ��ȭ
                Debug.Log("Parking Failure!");
            }
        }
    }


    void ShowPopup(Transform popup)
    {
        popup.gameObject.SetActive(true); // �˾� Ȱ��ȭ

        // �˾��� �ڵ��� �տ� ��ġ
        Transform playerCar = GameObject.FindWithTag("Player").transform;
        Vector3 popupPosition = playerCar.position + playerCar.forward * 4 + Vector3.up * 1;
        popup.position = popupPosition;

        // �˾��� ������ �ٶ󺸵��� ����
        popup.LookAt(playerCar);

        // 2�� �� �˾� ��Ȱ��ȭ
        StartCoroutine(HidePopupAfterDelay(popup, 2f));
    }

    IEnumerator HidePopupAfterDelay(Transform popup, float delay)
    {
        yield return new WaitForSeconds(delay);
        popup.gameObject.SetActive(false); // �˾� ��Ȱ��ȭ
    }


}
