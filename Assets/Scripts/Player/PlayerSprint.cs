using System.Collections;
using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    public float totalStamina;
    public float stamina;
    public GameObject staminaBar;
    public SoundEffects soundEffects;

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
            stamina -= 0.5f * Time.timeScale;

        }
        else
        {
            PlayerController.isRunning = false;
        }
        
        if (PlayerController.isRunning == false && stamina < totalStamina)
        {
            stamina += 0.25f * Time.timeScale;
        }

        if (staminaBar != null)
        {
            staminaBar.transform.localScale = new Vector2(stamina / totalStamina, staminaBar.transform.localScale.y);
        }
    }

    public void UseEnergyDrink()
    {
        maxStamina = true;
        soundEffects.EnergyDrinkSound();    
        StartCoroutine(WaitTenSeconds());
    }

    public IEnumerator WaitTenSeconds()
    {
        yield return new WaitForSeconds(10f);
        maxStamina = false;
    }

    public bool EnoughStaminaToAttack()
    {
        if (stamina > 30)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UseSword()
    {
        stamina -= 15;
        soundEffects.SwordSound();
    }
}
