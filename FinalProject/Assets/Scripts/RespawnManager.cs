using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public Vector3 respawnPosition = new Vector3(-56.42f, 0.8f, -4.48f); // ������ ��ġ
    public Vector3 respawnRotation = new Vector3(0f, 90f, 0f);          // ������ ȸ����

    void Update()
    {
        // y ���� -20���� ���� ���
        if (transform.position.y < -20)
        {
            Respawn(); // ������ ����
        }
    }

    void Respawn()
    {
        // ��ġ�� ȸ���� ����
        transform.position = respawnPosition; // ������ ��ġ�� �̵�
        transform.rotation = Quaternion.Euler(respawnRotation); // ������ ȸ���� ����

        Debug.Log($"Respawned to {respawnPosition} with rotation {respawnRotation}"); // ����� �޽��� ���
    }
}
