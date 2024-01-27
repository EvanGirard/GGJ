using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    private float _variationTime;
    private float _random;
    private bool _isMoving;
    private bool _isLeft = true;
    private bool _canAttack = true;
    Vector3 _goToPosition;
    void Start()
    {
        gameObject.transform.position = new Vector3(-5, 4, 0);
    }

    void Update()
    {
        _variationTime += Time.deltaTime;
        
        if (_variationTime >= 3f)
        {
            _variationTime = 0f;
            if (_isLeft)
            {
                _goToPosition = new Vector3(5, 4, 0);
                _isLeft = false;
            }
            else
            {
                _goToPosition = new Vector3(-5, 4, 0);
                _isLeft = true;
            }

            _isMoving = true;
        }

        if (_isMoving)
        {
            if (Vector3.SqrMagnitude(gameObject.transform.position - _goToPosition) >= 0.01f)
            {
                gameObject.transform.position += 0.066f * Vector3.Normalize(_goToPosition - gameObject.transform.position);
            }
            else
            {
                _isMoving = false;
            }
        }
    }
}
