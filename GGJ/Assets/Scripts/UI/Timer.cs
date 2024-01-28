using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float _remainingTime = 90f;


    private void Update()
    {
        if (_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;
        }
        else if (_remainingTime <= 0 && !EndGame.win)
        {
            _remainingTime = 0;
            EndGame.gameOver = true;
        }
        
        int min = Mathf.FloorToInt(_remainingTime / 60);
        int sec = Mathf.FloorToInt(_remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
