using UnityEngine;

public class CarCollision : MonoBehaviour
{
    public float maxImpactForce = 50f;  // �ִ� �浹 �� ����
    public float impactForceMultiplier = 0.5f;  // ��� ���� ���� ����
    public float barricadeForceReduction = 0.7f; // �ٸ����̵� �浹 �� �� ���� ����

    void OnCollisionEnter(Collision collision)
    {
        // ������ ������ �浹�� ����
        if (collision.gameObject.CompareTag("ParkedCar"))
        {
            // �浹 �� �� �� ���� ��� �ӵ�
            Vector3 impactForce = collision.relativeVelocity * collision.rigidbody.mass;

            // �ִ� ���� �ʰ����� �ʵ��� ����
            if (impactForce.magnitude > maxImpactForce)
            {
                impactForce = impactForce.normalized * maxImpactForce;
            }

            // ������ ���� �������� ���
            collision.rigidbody.AddForce(impactForce * impactForceMultiplier, ForceMode.Impulse);

            // �� ������ ����� �ֱ� ���� ���� ����
            Rigidbody myCarRigidbody = GetComponent<Rigidbody>();
            if (myCarRigidbody != null)
            {
                myCarRigidbody.AddForce(-impactForce * impactForceMultiplier, ForceMode.Impulse);
            }
        }
        if (collision.gameObject.CompareTag("Barricades"))
        {
            // �浹 ���� ���� (�ӵ� ���� ȿ��)
            Rigidbody myCarRigidbody = GetComponent<Rigidbody>();
            if (myCarRigidbody != null)
            {
                // �浹 �� ���� ���
                Vector3 reducedImpactForce = collision.relativeVelocity * barricadeForceReduction;

                // ������ �ӵ��� ���ҽ�Ű�� ���� �� ����
                myCarRigidbody.AddForce(-reducedImpactForce, ForceMode.Impulse);
            }
        }
    }
}
