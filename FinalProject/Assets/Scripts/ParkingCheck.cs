using UnityEngine;

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
        if (Input.GetKeyDown(KeyCode.P) && activeParkingZone == this)
        {
            if (isInsideParkingZone)
            {
                ShowPopup(successPopup); // ���� �˾� Ȱ��ȭ
                Debug.Log("Parking Success!");
            }
            else
            {
                ShowPopup(failurePopup); // ���� �˾� Ȱ��ȭ
                Debug.Log("Parking Failure!");
            }
        }
    }

    void ShowPopup(Transform popup)
    {
        // �˾� Ȱ��ȭ
        popup.gameObject.SetActive(true);

        // �˾��� �ڵ��� �տ� ��ġ
        Transform playerCar = GameObject.FindWithTag("Player").transform; // "Player" �±׸� ���� ����
        Vector3 popupPosition = playerCar.position + playerCar.forward * 4 + Vector3.up * 1; // �ڵ��� �� 2 ����
        popup.position = popupPosition;

        // �˾��� ������ �ٶ󺸵��� ����
        popup.LookAt(playerCar);
    }
}
