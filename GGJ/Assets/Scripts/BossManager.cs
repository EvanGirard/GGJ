using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    private float _variationTime;
    private int _random;
    private bool _isMoving;
    private bool _isLeft = true;
    private bool _canAttack = true;
    
    [SerializeField] GameObject lazerPrefab;
    [SerializeField] GameObject startLazerPrefab;
    [SerializeField] GameObject ballPrefab;
    
    public List<GameObject> LazerList = new List<GameObject>();
    
    
    public static BossManager instance;
    
    Vector3 _goToPosition;
    void Start()
    {
        gameObject.transform.position = new Vector3(-5, 4, 0);
        DeathCone();
    }
    
    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);    // Suppression d'une instance pr�c�dente (s�curit�...s�curit�...)

        instance = this;
    }

    private int RandomPatern()
    {
        float randf = Random.Range(0f, 10f);
        while (randf >= 10f)
        {
            //au cas ou on arrive sur la borne exterieur ce qui n'est pas pris en compte
            randf = Random.Range(0f, 10f);
        }
        return Mathf.FloorToInt(randf);
    }

    private void DeathWheel()
    {
        StartCoroutine(CreateDW());
        
        StartCoroutine(DestroyInSeconds(2f));
    }

    private void DeathCone()
    {
        for (int i = 1; i < 7; i += 1)
        {
            Vector3 direction = Vector3.Normalize(new Vector3(Mathf.Cos(- i * Mathf.PI / 8), Mathf.Sin(- i * Mathf.PI / 8), 0));
            StartCoroutine(Create_nBoule(12, 1, 2 * direction, ballPrefab));
        }
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
    private IEnumerator DestroyInSeconds(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        
        foreach(GameObject lazer in LazerList)
        {
            Destroy(lazer);
        }
    }

    private IEnumerator CreateDW()
    {
        /*faire apparaître la préparation du lazer*/
        
        yield return new WaitForSeconds(2f);
        
        GameObject newLazer;
        for (int i = 0; i < 2; i += 1)
        {
            newLazer = Instantiate(lazerPrefab, new Vector3(0,0,0), Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(i, 1 - i, 0)) );
            LazerList.Add(newLazer);
        }
        
        foreach(GameObject lazer in LazerList)
        {
            lazer.GetComponent<Rigidbody2D>().angularVelocity = 25;
        }
    }

    private IEnumerator CreateBoule(float f, Vector3 direction, GameObject ballPrefab)
    {
        yield return new WaitForSeconds(f);

        GameObject ball = Instantiate(ballPrefab, gameObject.transform.position, gameObject.transform.rotation);
        ball.GetComponent<Rigidbody2D>().velocity = direction;
        
        yield return new WaitForSeconds(0.1f);

        ball.GetComponent<SpriteRenderer>().enabled = true;
    }
    
    private IEnumerator Create_nBoule(int n, float f, Vector3 direction, GameObject ballPrefab)
    {
        for (int i = 0; i < n; i += 1)
        {
            yield return new WaitForSeconds(f);

            GameObject ball = Instantiate(ballPrefab, gameObject.transform.position, gameObject.transform.rotation);
            ball.GetComponent<Rigidbody2D>().velocity = direction;

            yield return new WaitForSeconds(0.1f);

            ball.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
