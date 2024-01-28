using System;
using UnityEngine;



public class Player : MonoBehaviour
{
    #region Attributes

    [SerializeField] private UIHealthBar uiHealthBarScript;
    private CharacterController _characterController;
    
    //son
    [SerializeField] private AudioClip deathSound=null;
    [SerializeField] private AudioClip damagesound = null;
    private AudioSource _playerAudioSource;
    
    // Animations
    private Animator _animator;
    private int IsWalkingID;
    
    private const float Speed = 5f;
    private static bool _canMove = true;
    private bool _isDead = false;

    #endregion


    #region Other Functions

    public bool GetIsDead()
    {
        return _isDead;
    }
    
    public void SetIsDead()
    {
        _isDead = true;
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
        _playerAudioSource.PlayOneShot( damagesound);
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
        
        _playerAudioSource = GetComponent<AudioSource>();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        IsWalkingID = Animator.StringToHash("isWalking");
    }


    private void Update()
    {
        if (uiHealthBarScript.GetCapacity() <= 0)
        {
            _playerAudioSource.PlayOneShot(deathSound);
            _isDead = true;
            EndGame.gameOver = true;
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

            if (transform.position == position)
            {
                _animator.SetBool(IsWalkingID, false);
            }
            else
            {
                transform.position = position;
                _animator.SetBool(IsWalkingID, true);
            }
        }
        
    }

    
    #endregion
}
