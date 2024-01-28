using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menuWindow;
    [SerializeField] private GameObject instructionsWindow;
    [SerializeField] private GameObject controlsWindow;
    [SerializeField] private GameObject optionWIndow;
    
    
    
    public void Quit()
    {
        Application.Quit();
    }

   public void Play()
    {
        SceneManager.LoadScene("Main");
    }
   
   public void Controls()
   {
       menuWindow.SetActive(false);
       controlsWindow.SetActive(true);
   }
    
    
   public void Back() //To go back to the pause menu
   {
       instructionsWindow.SetActive(false);
       controlsWindow.SetActive(false);
       optionWIndow.SetActive(false);
       menuWindow.SetActive(true);
   }
    
    
   public void Instructions()
   {
       instructionsWindow.SetActive(true);
       menuWindow.SetActive(false);
   }
   
}
