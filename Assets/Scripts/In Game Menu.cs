using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InGameMenu : MonoBehaviour
{
    public GameObject inGameMenu;
    [SerializeField] TextMeshProUGUI timePausedText;
    [SerializeField] TextMeshProUGUI timer;

    public GameObject restOfUI; 
    void Start()
    {
        inGameMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.tabKey.wasPressedThisFrame) 
        {
            ToggleGameMenu();
        }
    }

    private void ToggleGameMenu()
    {
        if(inGameMenu.activeSelf)
        {
            inGameMenu.SetActive(false);
            Time.timeScale = 1f;
            restOfUI.SetActive(true);
        }
        else if (!inGameMenu.activeSelf)
        {
            inGameMenu.SetActive(true);
            Time.timeScale = 0f;
            timePausedText.text = timer.text;
            restOfUI.SetActive(false);
        }
    }

}
