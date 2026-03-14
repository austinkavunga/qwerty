using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float totalHp;
    [SerializeField] public float HP;
    public GameObject hpBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        HP = totalHp;
    }

    // Update is called once per frame
    private void Update()
    {
        if (HP <= 0)
        {
            HP = 0;
            Destroy(gameObject);
        }
        if (HP > totalHp)
        {
            HP = totalHp;
        }
        if (hpBar != null)
        {
            hpBar.transform.localScale = new Vector2(HP / totalHp, hpBar.transform.localScale.y);
        }
        else
        {
            Debug.Log("Hp bar is null");
        }

    }
    public void UseBandage()
    {
        HP += 15;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
    }
}

