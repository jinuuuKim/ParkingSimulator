using UnityEngine;
using UnityEngine.UI; // UI ��Ҹ� �����ϱ� ���� �ʿ�
using System.Collections;

public class StartAreaManager : MonoBehaviour
{
    public Transform enterStartAreaPopup; // EnterStartArea �˾� UI ������Ʈ
    public Image popupImage; // �˾��� ǥ���� �̹��� (Inspector���� ����)

    private bool isInsideStartAreaZone = false; // ������ StartZone�� �ִ��� ����

    void OnTriggerEnter(Collider other)
    {
        // StartZone�� ������ ������Ʈ�� "Player" �±׸� ���� ���
        if (other.CompareTag("Player"))
        {
            isInsideStartAreaZone = true;
            ShowPopup(enterStartAreaPopup); // StartZone �˾� Ȱ��ȭ
            Debug.Log("Car entered the StartZone.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // StartZone�� ��� ������Ʈ�� "Player" �±׸� ���� ���
        if (other.CompareTag("Player"))
        {
            isInsideStartAreaZone = false;
            Debug.Log("Car exited the StartZone.");
        }
    }

    void ShowPopup(Transform popup)
    {
        popup.gameObject.SetActive(true); // �˾� Ȱ��ȭ

        // �˾��� �̹��� ����
        if (popupImage != null)
        {
            popupImage.sprite = Resources.Load<Sprite>("Minimap"); // Resources �������� Minimap �̹��� �ε�
        }

        // �˾��� �ڵ��� �տ� ��ġ
        Transform playerCar = GameObject.FindWithTag("Player").transform;
        Vector3 popupPosition = playerCar.position + playerCar.forward * 9 + Vector3.up * 1;
        popup.position = popupPosition;

        // �˾��� ������ �ٶ󺸵��� ����
        popup.LookAt(playerCar);

        // 4�� �� �˾� ��Ȱ��ȭ
        StartCoroutine(HidePopupAfterDelay(popup, 6f));
    }

    IEnumerator HidePopupAfterDelay(Transform popup, float delay)
    {
        yield return new WaitForSeconds(delay);
        popup.gameObject.SetActive(false); // �˾� ��Ȱ��ȭ
    }
}
