using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    #region Attributes

    [SerializeField] private GameObject inGameWindow;
    [SerializeField] private GameObject pauseWindow;
    [SerializeField] private GameObject instructionsWindow;
    [SerializeField] private GameObject controlsWindow;
    
    #endregion


    #region Unity Event

    private void Update()
    {
        if (Input.GetKey(KeyCode.Backslash)) //*
        {
            Pause();
        }
    }

    #endregion

    #region Methodes

    public void Pause()
    {
        Cursor.visible = true;
        inGameWindow.SetActive(false);
        pauseWindow.SetActive(true);
        Time.timeScale = 0;
    }

    
    public void Resume()
    {
        inGameWindow.SetActive(true);
        pauseWindow.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
    }
    

    public void Controls()
    {
        pauseWindow.SetActive(false);
        controlsWindow.SetActive(true);
    }
    
    
    public void Back() //To go back to the pause menu
    {
        instructionsWindow.SetActive(false);
        controlsWindow.SetActive(false);
        pauseWindow.SetActive(true);
    }
    
    
    public void Instructions()
    {
        instructionsWindow.SetActive(true);
        pauseWindow.SetActive(false);
    }


    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    #endregion
}
