using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class used to not destroy the music when changing scene
public class DoNotDestroy : MonoBehaviour
{
    
    public void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if(musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
