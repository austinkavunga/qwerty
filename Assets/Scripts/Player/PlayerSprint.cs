using System.Collections;
using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    public float totalStamina;
    public float stamina;
    public GameObject staminaBar;

    public bool maxStamina;

    void Awake()
    {
        stamina = totalStamina;
    }

    void Update()
    {
        if(maxStamina == true)
        {
            staminaBar.GetComponent<SpriteRenderer>().color = Color.yellow;
            stamina = totalStamina;
        }
        if(maxStamina == false)
        {
            staminaBar.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (PlayerController.sprintButtonPressed == true && stamina > 0)
        {
            PlayerController.isRunning = true;
            stamina -= 0.5f;

        }
        else
        {
            PlayerController.isRunning = false;
        }
        
        if (PlayerController.isRunning == false && stamina < totalStamina)
        {
            stamina += 0.25f;
        }

        if (staminaBar != null)
        {
            staminaBar.transform.localScale = new Vector2(stamina / totalStamina, staminaBar.transform.localScale.y);
        }
    }

    public void UseEnergyDrink()
    {
        maxStamina = true;
        StartCoroutine(WaitTenSeconds());
    }

    public IEnumerator WaitTenSeconds()
    {
        yield return new WaitForSeconds(10f);
        maxStamina = false;
    }
}
