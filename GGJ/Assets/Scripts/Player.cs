using UnityEngine;



public class Player : MonoBehaviour
{
    #region Attributes

    private CharacterController _characterController;
    
    private float _pv = 100f;
    private float _speed = 5f;

    #endregion


    #region Other Functio,s

    public float GetPv()
    {
        return _pv;
    }


    public void SetPv(float pv)
    {
        _pv = pv;

        if (_pv <= 0f)
        {
            Debug.Log("Mort");
        }
    }

    #endregion


    #region Unity Event Functions

    private void Awake()
    {
        /*
         * We hide the cursor and confined it within the game window
         */
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        
        _characterController = GetComponent<CharacterController>();
    }


    private void Update()
    {
        /*
         * Movements of the player
         */
        
        var position = transform.position;
        
        if (Input.GetKey(KeyCode.UpArrow)) // Forward
        {
            position += _speed * Time.deltaTime * transform.up;
        }
        
        if (Input.GetKey(KeyCode.DownArrow)) // Backward
        {
            position -= _speed * Time.deltaTime * transform.up;
        }
        
        if (Input.GetKey(KeyCode.RightArrow)) // Right
        {
            position += _speed * Time.deltaTime * transform.right;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow)) // Forward
        {
            position -= _speed * Time.deltaTime * transform.right;
        }
        
        var newPosition = Vector3.MoveTowards(
            transform.position,
            position,
            _speed * Time.deltaTime);
        
        _characterController.Move(newPosition - transform.position);
        
    }

    #endregion
}