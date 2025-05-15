using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    public Joystick joystick;
    private Animator animator;

    
    void Start()
    {
        animator = GetComponent<Animator>();
        
        if (joystick == null)
        {
            joystick = FindObjectOfType<Joystick>();
            if (joystick == null)
            {
                Debug.LogError("Joystick sahnede bulunamadı");
            }
        }
    }

    void Update()
    {
        if (joystick == null) return;

        Vector3 movement = new Vector3(joystick.Horizontal, 0, joystick.Vertical);

        if (movement != Vector3.zero) // herhangi bir hareket varsa
        {
            transform.Translate(movement * speed * Time.deltaTime, Space.World);//hareket et

            transform.rotation = Quaternion.LookRotation(movement);// karakteri hareket yönüne döndür

            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (animator.GetBool("isAttacking") && GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            animator.SetBool("isAttacking", false);
            Debug.Log("Düşman yok, saldırı durduruldu.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            animator.SetBool("isAttacking", true); // Atak animasyonunu başlat
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void EnemyDefeated(GameObject enemy)
    {
        if (enemy.CompareTag("Enemy"))
        {
            animator.SetBool("isAttacking", false);
            Debug.Log("Düşman öldürüldü");
        }
    }
    
    public void EndAttack()
    {
        animator.SetBool("isAttacking", false);
    }
}
