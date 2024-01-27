using UnityEngine;



public class Player : MonoBehaviour
{
    #region Attributes

    private CharacterController _characterController;
    
    private float _pv = 100f;
    private const float Speed = 5f;
    private bool _canMove = true;

    #endregion


    #region Other Functions

    public bool GetCanMove()
    {
        return _canMove;
    }

    public void ApplyDamage(float damage)
    {
        _pv -= damage;

        if (_pv <= 0)
        {
            //anim
            _canMove = false;
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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ApplyDamage(50f);
        }
        
        
        /*
         * Movements of the player
         */
        if (_canMove)
        {
            var position = transform.position;
        
            if (Input.GetKey(KeyCode.UpArrow)) // Forward
            {
                position += Speed * Time.deltaTime * transform.up;
            }
        
            if (Input.GetKey(KeyCode.DownArrow)) // Backward
            {
                position -= Speed * Time.deltaTime * transform.up;
            }
        
            if (Input.GetKey(KeyCode.RightArrow)) // Right
            {
                position += Speed * Time.deltaTime * transform.right;
            }
        
            if (Input.GetKey(KeyCode.LeftArrow)) // Forward
            {
                position -= Speed * Time.deltaTime * transform.right;
            }
        
            var newPosition = Vector3.MoveTowards(
                transform.position,
                position,
                Speed * Time.deltaTime);
        
            _characterController.Move(newPosition - transform.position);
        }
        
    }

    #endregion
}
