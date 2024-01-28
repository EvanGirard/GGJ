using UnityEngine;

public class Laser : MonoBehaviour
{
    private BoxCollider2D _collider2D;
    private Animator _animator;
    private int IsChargedID;
    private float _spawnTime;


    private void Awake()
    {
        _collider2D = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _collider2D.gameObject.SetActive(false);

        IsChargedID = Animator.StringToHash("isCharged");
        _spawnTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - _spawnTime >= 2f)
        {
            _animator.SetBool(IsChargedID,true);
            _collider2D.gameObject.SetActive(true);
        }
    }
}