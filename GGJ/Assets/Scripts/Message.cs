using System;
using UnityEngine;
using TMPro;


public class Message : MonoBehaviour
{
    #region Attributes

    [SerializeField] private TextMeshProUGUI msgToPrint;
    [SerializeField] private Player playerScript;
    [SerializeField] private UIHealthBar uiHealthBarScript;
    
    private readonly string _startTag = "<color=red>";
    private readonly string _endTag = "</color>";

    private string _msg;
    private int _cursor = 0;
    private bool _finalSentence = false;

    #endregion


    #region Unity Event Functions

    private void Start()
    {
        _msg = MsgData.GetSentence();
    }

    private void Update()
    {
        if (uiHealthBarScript.GetCapacity() >= 200 && !_finalSentence)
        {
            _finalSentence = true;
            _msg = MsgData.GetBossSentence();
            _cursor = 0;
        }
        if (_cursor == _msg.Length)
        {
            if (_finalSentence)
            {
                _msg = MsgData.GetBossSentence();
                _cursor = 0; 
            }
            else
            {
                _msg = MsgData.GetSentence();
                _cursor = 0;
            }
        }
        
        
        
        var letter = _msg.Substring(_cursor, 1);
        
        //The player doesn't have to wright spaces
        if (letter == " ") 
        {
            _cursor += 1;
            letter = _msg.Substring(_cursor, 1);
            uiHealthBarScript.ChangeCapacity(5f); //On word is correctly written
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
                    case("Alpha0"): //à
                        keyString = "À";
                        break;
                    case("Alpha2"): //à
                        keyString = "É";
                        break;
                    case ("Alpha4"): //'
                        keyString = "'";
                        break;
                    case ("Alpha6"): //-
                        keyString = "-";
                        break;
                    case("Alpha7"): //à
                        keyString = "È";
                        break;
                    case("Alpha9"): //ç
                        keyString = "Ç";
                        break;
                    case("Slash"): //!
                        keyString = "!";
                        break;
                    case("Quote"): //!
                        keyString = "Ù";
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
                if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                    && Input.GetKey(KeyCode.Alpha9)) //9
                {
                    keyString = "9";
                }
                if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                    && Input.GetKey(KeyCode.Comma)) //.
                {
                    keyString = ".";
                }
                
                if (keyString == letter.ToUpper())
                {
                    _cursor += 1;   
                }
                else
                {
                    if (_cursor == 0) return;
                    if (!(letter == "." || letter == "ô" || letter == "ê" || letter == "û" || letter == "ï" ||
                          letter == "?" || letter == "9"))
                    {
                        _cursor -= 1;
                        if (_msg.Substring(_cursor, 1) == " ") _cursor -= 1;
                    }
                }
            }
        }
        
        
        
        /*
         * We print the message with the letter correctly answer in red
         */
        if (!playerScript.GetIsDead()) msgToPrint.text = _startTag + _msg.Substring(0, _cursor) + _endTag + _msg.Substring(_cursor);
    }

    #endregion
}
