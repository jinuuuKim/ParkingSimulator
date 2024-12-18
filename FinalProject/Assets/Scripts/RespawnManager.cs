using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public Vector3 respawnPosition = new Vector3(-56.42f, 0.8f, -4.48f); // 리스폰 위치
    public Vector3 respawnRotation = new Vector3(0f, 90f, 0f);          // 리스폰 회전값

    void Update()
    {
        // y 값이 -20보다 작은 경우
        if (transform.position.y < -20)
        {
            Respawn(); // 리스폰 실행
        }
    }

    void Respawn()
    {
        // 위치와 회전을 설정
        transform.position = respawnPosition; // 리스폰 위치로 이동
        transform.rotation = Quaternion.Euler(respawnRotation); // 리스폰 회전값 적용

        Debug.Log($"Respawned to {respawnPosition} with rotation {respawnRotation}"); // 디버그 메시지 출력
    }
}
