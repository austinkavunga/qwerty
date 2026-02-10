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

    // Update is called once per frame
    void Update()
    {


        if (PlayerController.sprintPressed == true && stamina > 0)
        {
            PlayerController.isRunning = true;
            stamina -= 0.5f*Time.timeScale;

        }
        else
        {
            PlayerController.isRunning = false;
        }
        
        if (PlayerController.isRunning == false && stamina < totalStamina)
        {
            stamina += 0.25f*Time.timeScale;
        }

        if (staminaBar != null)
        {
            staminaBar.transform.localScale = new Vector2(stamina / totalStamina, staminaBar.transform.localScale.y);
        }
    }
}
