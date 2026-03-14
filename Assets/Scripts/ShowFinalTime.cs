using TMPro;
using UnityEngine;

public class ShowFinalTime : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resultText;

    void Start()
    {
        float time = Timer.finalTime;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        resultText.text = "Time Survived: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}