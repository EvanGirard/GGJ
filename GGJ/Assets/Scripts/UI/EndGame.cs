using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject winWindow;
    [SerializeField] private GameObject gameOverWindow;

    public static bool gameOver = false;
    public static bool win = false;

    private void Update()
    {
        if (win)
        {
            Time.timeScale = 0;
            winWindow.SetActive(true);
        }
        
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverWindow.SetActive(true);
        }
    }
}
