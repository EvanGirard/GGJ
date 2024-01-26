using System;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class Message : MonoBehaviour
{
    #region Attributes

    [SerializeField] private TextMeshProUGUI msgToPrint;
    private string _startBalise = "<color=red>";
    private string _endBalise = "</color>";

    private string _msg = "TEST";
    private int _cursor = 0;

    #endregion


    #region Unity Event Functions

    private void Update()
    {
        /*
         * We test if the correct answer is given
         */
        var letter = _msg.Substring(_cursor, 1);
        foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key) && key.ToString() == letter)
            {
                _cursor += 1;
            }
        }
        
        
        
        /*
         * We print the message with the letter correctly answer in red
         */
        msgToPrint.text = _startBalise + _msg.Substring(0, _cursor) + _endBalise + _msg.Substring(_cursor);
    }

    #endregion
}
