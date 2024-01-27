using UnityEngine;



public class Player : MonoBehaviour
{
    #region Attributes

    [SerializeField] private UIHealthBar uiHealthBarScript;
    private CharacterController _characterController;
    
    private const float Speed = 5f;
    private static bool _canMove = true;
    private bool _isDead = false;

    #endregion


    #region Other Functions

    public bool GetIsDead()
    {
        return _isDead;
    }
    
    
    public void SetCanMove(bool state)
    {
        _canMove = state;
    }

    
    /**
     * Function called when the player is hit by a projectile
     */
    public void ApplyDamage(float damage)
    {
        uiHealthBarScript.ChangeCapacity(-damage);
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
        if (uiHealthBarScript.GetCapacity() <= 0)
        {
            //anim
            _isDead = true;
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

            transform.position = position;
        }
        
    }

    #endregion
}
