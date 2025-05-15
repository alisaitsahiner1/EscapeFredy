using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyVision : MonoBehaviour
{
    public int enemyLevel = 10;
    private Animator animator;
    private int playerCurrentLevel;
    private EnemyMovement enemyMovement;
    public float attackDuration = 2.0f;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        enemyMovement = GetComponentInParent<EnemyMovement>();

        UpdatePlayerLevel();
    }

    private void UpdatePlayerLevel()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            CharacterLevel playerLevel = player.GetComponent<CharacterLevel>();
            if (playerLevel != null)
            {
                playerCurrentLevel = playerLevel.currentLevel;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpdatePlayerLevel();

            if (playerCurrentLevel > enemyLevel)
            {
                StartCoroutine(DestroyEnemyWithDelay(2.0f));
            }
            else
            {
                StartCoroutine(AttackPlayerWithDelay(other.gameObject));
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (enemyMovement != null)
            {
                enemyMovement.enabled = true;
            }
            animator.SetBool("isAttacking", false);
        }
    }

    IEnumerator DestroyEnemyWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(transform.parent.gameObject);
        Debug.Log("Düşman öldü.");
    }

    IEnumerator AttackPlayerWithDelay(GameObject player)
    {
        animator.SetBool("isAttacking", true);

        yield return new WaitForSeconds(attackDuration);

        player.SetActive(false);
        Debug.Log("Yeniden başlanıyor...");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
