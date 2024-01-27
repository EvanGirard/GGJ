using System;
using UnityEngine;
using TMPro;


public class Message : MonoBehaviour
{
    #region Attributes

    [SerializeField] private TextMeshProUGUI msgToPrint;
    private readonly string _startTag = "<color=red>";
    private readonly string _endTag = "</color>";

    private string _msg = "û ô ê";
    private int _cursor = 0;

    #endregion


    #region Unity Event Functions

    private void Update()
    {
        var letter = _msg.Substring(_cursor, 1);
        
        
        //The player doesn't have to wright spaces
        if (letter == " ") 
        {
            _cursor += 1;
            letter = _msg.Substring(_cursor, 1);
        }
        
        
        //AZERTY Keybord
        foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                KeyCode newKey;
                switch (key)
                {
                    case(KeyCode.A): //Q
                        newKey = KeyCode.Q;
                        break;
                    case(KeyCode.Q): //A
                        newKey = KeyCode.A;
                        break;
                    case(KeyCode.Z): //Z
                        newKey = KeyCode.W;
                        break;
                    case(KeyCode.W): //Z
                        newKey = KeyCode.Z;
                        break;
                    case(KeyCode.Semicolon): //M
                        newKey = KeyCode.M;
                        break; 
                    case(KeyCode.M): //,
                        newKey = KeyCode.Comma;
                        break;
                    case(KeyCode.Comma): //;
                        newKey = KeyCode.Period;
                        break;
                    default:
                        newKey = key;
                        break;
                }

                string keyString;
                switch (newKey.ToString())
                {
                    case("Comma"): //,
                        keyString = ",";
                        break;
                    case("Period"): //;
                        keyString = ";";
                        break;
                    case ("Alpha4"): //'
                        keyString = "'";
                        break;
                    case("Alpha0"): //à
                        keyString = "À";
                        break;
                    case("Alpha2"): //à
                        keyString = "é";
                        break;
                    case("Alpha7"): //à
                        keyString = "è";
                        break;
                    case("Slash"): //!
                        keyString = "!";
                        break;
                    default:
                        keyString = newKey.ToString();
                        break;
                }
                
                //Special character
                if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                    && Input.GetKey(KeyCode.M))
                {
                    keyString = "?";
                }
                if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                    && Input.GetKey(KeyCode.LeftBracket)
                    && Input.GetKey(KeyCode.I)) //ï
                {
                    keyString = "Ï";
                }
                if (Input.GetKey(KeyCode.LeftBracket)
                    && Input.GetKey(KeyCode.U)) //û
                {
                    keyString = "Û";
                }
                if (Input.GetKey(KeyCode.LeftBracket)
                    && Input.GetKey(KeyCode.O)) //ô
                {
                    keyString = "Ô";
                }
                if (Input.GetKey(KeyCode.LeftBracket)
                    && Input.GetKey(KeyCode.E)) //ê
                {
                    keyString = "Ê";
                }
                
                
                
                if (keyString == letter.ToUpper())
                {
                    _cursor += 1;   
                }
            }
        }
        
        
        
        /*
         * We print the message with the letter correctly answer in red
         */
        msgToPrint.text = _startTag + _msg.Substring(0, _cursor) + _endTag + _msg.Substring(_cursor);
    }

    #endregion
}
