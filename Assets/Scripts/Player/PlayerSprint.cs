using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    public float totalStamina;
    public float stamina;
    public GameObject staminaBar;

    void Awake()
    {
        stamina = totalStamina;
    }

    void Update()
    {


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
}
