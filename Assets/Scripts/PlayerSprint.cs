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
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            PlayerController.isRunning = true;
            stamina -= 0.5f;
        }
        else
        {
            PlayerController.isRunning = false;
        }
        
        if (!Input.GetKey(KeyCode.LeftShift) && stamina < totalStamina)
        {
            stamina += 0.25f;
        }

        if (staminaBar != null)
        {
            staminaBar.transform.localScale = new Vector2(stamina / totalStamina, staminaBar.transform.localScale.y);
        }
    }
}
