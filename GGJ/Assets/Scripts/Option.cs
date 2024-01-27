using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

// Option is a class that manage the option menu
public class Option : MonoBehaviour
{
    
    
    List<string> screenMode = new List<string> {"Fenêtré", "Plein écran", "Plein écran fenêtré"};
    // Set the screen mode
    public void SetFullscreenMode(int index)
    {
        var mode = screenMode[index];
        Screen.fullScreenMode = mode switch
        {
            "Fenêtré" => FullScreenMode.Windowed,
            "Plein écran" => FullScreenMode.ExclusiveFullScreen,
            _ => FullScreenMode.FullScreenWindow
        };

    }
    
    
    List<int> widths = new List<int> {1920,1600,1280,960};
    List<int> heights = new List<int> {1080,900,800,540};

    // Set the screen size
    // @param index the index of the screen size
    public void SetScreenSize(int index)
    {
        bool fullScreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, Screen.fullScreen);
    }
}
