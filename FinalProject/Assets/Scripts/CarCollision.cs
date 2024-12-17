using UnityEngine;

public class CarCollision : MonoBehaviour
{
    public float maxImpactForce = 50f;  // 최대 충돌 힘 설정
    public float impactForceMultiplier = 0.5f;  // 충격 반응 강도 설정
    public float barricadeForceReduction = 0.7f; // 바리케이드 충돌 시 힘 감소 비율

    void OnCollisionEnter(Collision collision)
    {
        // 주차된 차와의 충돌을 감지
        if (collision.gameObject.CompareTag("ParkedCar"))
        {
            // 충돌 시 두 차 간의 상대 속도
            Vector3 impactForce = collision.relativeVelocity * collision.rigidbody.mass;

            // 최대 힘을 초과하지 않도록 제한
            if (impactForce.magnitude > maxImpactForce)
            {
                impactForce = impactForce.normalized * maxImpactForce;
            }

            // 주차된 차에 가해지는 충격
            collision.rigidbody.AddForce(impactForce * impactForceMultiplier, ForceMode.Impulse);

            // 내 차에도 충격을 주기 위해 힘을 가함
            Rigidbody myCarRigidbody = GetComponent<Rigidbody>();
            if (myCarRigidbody != null)
            {
                myCarRigidbody.AddForce(-impactForce * impactForceMultiplier, ForceMode.Impulse);
            }
        }
        if (collision.gameObject.CompareTag("Barricades"))
        {
            // 충돌 감속 로직 (속도 감소 효과)
            Rigidbody myCarRigidbody = GetComponent<Rigidbody>();
            if (myCarRigidbody != null)
            {
                // 충돌 힘 감소 계산
                Vector3 reducedImpactForce = collision.relativeVelocity * barricadeForceReduction;

                // 차량의 속도를 감소시키기 위한 힘 적용
                myCarRigidbody.AddForce(-reducedImpactForce, ForceMode.Impulse);
            }
        }
    }
}
