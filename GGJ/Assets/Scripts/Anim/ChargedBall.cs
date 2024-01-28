using UnityEngine;

public class ChargedBall : MonoBehaviour
{
    private CircleCollider2D _collider2D;
    private Animator _animator;
    private int IsChargedID;
    private float _spawnTime;


    private void Awake()
    {
        _collider2D = GetComponent<CircleCollider2D>();
        _animator = GetComponent<Animator>();
        _collider2D.enabled = false;

        IsChargedID = Animator.StringToHash("isCharged");
        _spawnTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - _spawnTime <= 2f) return;
        
        _animator.SetBool(IsChargedID,true);
        _collider2D.enabled = true;
    }
}
