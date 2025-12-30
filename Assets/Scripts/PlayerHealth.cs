using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float totalHp;
    public float HP;
    public GameObject hpBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        HP = totalHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(HP < 0)
        {
            HP = 0;
        }
        if(HP > totalHp)
        {
            HP = totalHp;
        }
        if(hpBar != null)
        {
            hpBar.transform.localScale = new Vector2(HP / totalHp, hpBar.transform.localScale.y);
        }
            
    }
}
