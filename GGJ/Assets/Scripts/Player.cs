using UnityEngine;



public class Player : MonoBehaviour
{
    #region Attributes

    [SerializeField] private UIHealthBar uiHealthBarScript;
    private CharacterController _characterController;
    
    private const float Speed = 5f;
    private bool _canMove = true;

    #endregion


    #region Other Functions

    /**
     * Getter for _canMove boolean
     */
    public bool GetCanMove()
    {
        return _canMove;
    }

    /**
     * Function called when the player is hit by a projectile
     */
    public void ApplyDamage(float damage)
    {
        var newHp = uiHealthBarScript.GetCapacity() - damage;
        uiHealthBarScript.SetCapacity(newHp);

        if (uiHealthBarScript.GetCapacity() <= 0)
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
        // POUR LE DEBUG ça
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ApplyDamage(20f);
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
