using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float totalHp;
    [SerializeField] public float HP;
    public GameObject hpBar;
    private SceneController sceneController;
    public SoundEffects soundEffects;

    public void Awake()
    {
        HP = totalHp;
        sceneController = new SceneController();
    }


    private void Update()
    {
        if(HP <= 0)
        {
            HP = 0;
            FindFirstObjectByType<Timer>().SaveTime();
            sceneController.LoseGame();
        }
        if(HP > totalHp)
        {
            HP = totalHp;
        }
        if(hpBar != null)
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
        soundEffects.HealingSound();
    }

    public void TakeDamage(int damage)
    { 
        HP -= damage;
        soundEffects.TakeDamageSound();
    }
}
