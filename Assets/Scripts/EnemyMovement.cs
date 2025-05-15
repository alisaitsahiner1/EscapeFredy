using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Transform targetPoint;
    private Vector3 moveDirection;

    void Start()
    {
        targetPoint = pointB;   // ilk hedef noktayı belirle
    }

    void Update()
    {
        MoveToTarget();

        RotateTowardsDirection();
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)// eğer hedefe ulaştıysa diğer noktaya geçiş yap
        {
            if (targetPoint == pointA)
                {
                    targetPoint = pointB;
                }
            else
                {
                    targetPoint = pointA;
                }
        }
        moveDirection = (targetPoint.position - transform.position).normalized;// hareket yönünü hesapla
    }

    void RotateTowardsDirection()
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
}
