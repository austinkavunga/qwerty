using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Sword : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject activeWeapon;
    public GameObject basement;
    private EnemyHealth enemyHealth;
    [SerializeField] private int damage = 5;
    public BoxCollider2D swordCollider;

    void Start()
    {
        //swordCollider.enabled = false;
    }

    void Update()
    {
        if (basement.activeSelf && enemy.activeSelf)
        {
            if (player.transform.position.x > enemy.transform.position.x)
            {
                activeWeapon.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else
            {
                activeWeapon.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void ActivateWeapon()
    {
        swordCollider.enabled = true;
    }
    public void DeactivateWeapon()
    {
        swordCollider.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damage); // Adjust the damage value as needed
            Debug.Log("Enemy hit!");
        }
    }
}

