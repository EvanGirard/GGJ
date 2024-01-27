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

    [SerializeField] GameObject player;
    [SerializeField] GameObject lazerPrefab;
    [SerializeField] GameObject startLazerPrefab;
    [SerializeField] GameObject ballPrefab;
    
    public List<GameObject> LazerList = new List<GameObject>();
    public List<GameObject> StartLazerList = new List<GameObject>();
    
    public static BossManager instance;
    
    Vector3 _goToPosition;
    
    //Animations
    private Animator _animator;
    private int IsAttackingID;
    
    
    
    void Start()
    {
        gameObject.transform.position = new Vector3(-5, 4, 0);
        DeathKaleidoscope();
    }
    
    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);    // Suppression d'une instance pr�c�dente (s�curit�...s�curit�...)

        instance = this;

        _animator = GetComponent<Animator>();
        IsAttackingID = Animator.StringToHash("isAttacking");
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

    private void DeathPath()
    {
        _variationTime = -100f;
        _goToPosition = new Vector3(0, 4, 0);
        _isMoving = true;
        
        StartCoroutine(CouloirLaser());
        
        StartCoroutine(CreateBoulePath());

        _variationTime = 3f;
    }

    private void DeathBlasters()
    {
        StartCoroutine(GBlaster());
    }

    private void DeathKaleidoscope()
    {
        StartCoroutine(SJKaleido());
    }
    
    void Update()
    {
        /*
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
        }*/

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
    
    IEnumerator CouloirLaser()
    {
        float speed=2f;
        
        // création de l'origine des lasers
        GameObject point1 = Instantiate(startLazerPrefab, new Vector3(7, 10, 0), gameObject.transform.rotation);
        GameObject point2 = Instantiate(startLazerPrefab, new Vector3(-7, 10, 0), gameObject.transform.rotation);
        
        yield return new WaitForSeconds(2);
        
        // création des lasers
        GameObject trait1 = Instantiate(lazerPrefab, new Vector3(point1.transform.position.x, point1.transform.position.y / 2, 0), gameObject.transform.rotation);
        GameObject trait2 = Instantiate(lazerPrefab, new Vector3(point2.transform.position.x, point2.transform.position.y / 2, 0), gameObject.transform.rotation);
    
        //mouvement des lasers 
        trait1.GetComponent<Rigidbody2D>().velocity = new Vector3(-speed , 0, 0);
        trait2.GetComponent<Rigidbody2D>().velocity = new Vector3(speed , 0, 0);

        while (trait1.transform.position.x >= 5f)
        {
            yield return new WaitForFixedUpdate();
        }
        
        trait1.GetComponent<Rigidbody2D>().velocity = new Vector3(0 , 0, 0);
        trait2.GetComponent<Rigidbody2D>().velocity = new Vector3(0 , 0, 0);
        
        yield return new WaitForSeconds(7);
        
        Destroy(point1);
        Destroy(trait1);
        Destroy(point2);
        Destroy(trait2);
    }

    IEnumerator CreateBoulePath()
    {
        yield return new WaitForSeconds(5f);
        
        for (int i = 0; i < 8; i += 1)
        {
            yield return new WaitForSeconds(1.5f);

            GameObject ball;
            if (i % 2 == 0)
            {
                ball = Instantiate(ballPrefab, gameObject.transform.position + 1f * Vector3.right, gameObject.transform.rotation);
            }
            else
            {
                ball = Instantiate(ballPrefab, gameObject.transform.position - 1f * Vector3.right, gameObject.transform.rotation);
            }
            ball.GetComponent<Rigidbody2D>().velocity = Vector3.down;
        
            yield return new WaitForSeconds(0.1f);

            ball.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    
    IEnumerator GBlaster()
    {
        for (int i = 0; i < 2; i += 1)
        {
            Vector2 depart1; 
            depart1= new  Vector2(-20, 20); 
            Vector2 depart2;
            depart2= new Vector2(-20, -20); 
            float speed=10f;
        
            // création de l'origine des lasers
            GameObject point1 = Instantiate(startLazerPrefab, depart1, gameObject.transform.rotation);
            GameObject point2 = Instantiate(startLazerPrefab, depart2, gameObject.transform.rotation);
            
            yield return new WaitForSeconds(2);
        
            // création des lasers
            GameObject trait1 = Instantiate(lazerPrefab, new Vector3(0, point1.transform.position.y ), Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(1, 0, 0)));
            GameObject trait2 = Instantiate(lazerPrefab, new Vector3(0, point2.transform.position.y ), Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(1, 0, 0)));
            
            yield return new WaitForSeconds(5);
            
            //suppression des lasers
            Destroy(point1);
            Destroy(trait1);
            Destroy(point2);
            Destroy(trait2);
            
            // deuxièmes attaques
            depart1= new  Vector2(-20, 0); 
            depart2= new Vector2(-20, -5);
            Vector2 depart3;
            depart3 = new Vector2(-20, 5);
        
            // création de l'origine des lasers
            point1 = Instantiate(startLazerPrefab, depart1, gameObject.transform.rotation);
            point2 = Instantiate(startLazerPrefab, depart2, gameObject.transform.rotation);
            GameObject point3 = Instantiate(startLazerPrefab, depart3, gameObject.transform.rotation);
            
            yield return new WaitForSeconds(2);
        
            // création des lasers
            trait1 = Instantiate(lazerPrefab, new Vector3(0, point1.transform.position.y ), Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(1, 0, 0)));
            trait2 = Instantiate(lazerPrefab, new Vector3(0, point2.transform.position.y ), Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(1, 0, 0)));
            GameObject trait3;
            trait3 = Instantiate(lazerPrefab, new Vector3(0, point3.transform.position.y ), Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(1, 0, 0)));
            
            yield return new WaitForSeconds(5);
            
            //suppression des lasers
            Destroy(point1);
            Destroy(trait1);
            Destroy(point2);
            Destroy(trait2);
            Destroy(point3);
            Destroy(trait3);
            
            // troisièmes attaques
            depart1= new  Vector2(-20, -1); 
            depart2= new Vector2(-20, -15);
            depart3 = new Vector2(-20, 8);
        
            // création de l'origine des lasers
            point1 = Instantiate(startLazerPrefab, depart1, gameObject.transform.rotation);
            point2 = Instantiate(startLazerPrefab, depart2, gameObject.transform.rotation);
            point3 = Instantiate(startLazerPrefab, depart3, gameObject.transform.rotation);
            
            yield return new WaitForSeconds(2);
        
            // création des lasers
            trait1 = Instantiate(lazerPrefab, new Vector3(0, point1.transform.position.y ), Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(1, 0, 0)));
            trait2 = Instantiate(lazerPrefab, new Vector3(0, point2.transform.position.y ), Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(1, 0, 0)));
            trait3 = Instantiate(lazerPrefab, new Vector3(0, point3.transform.position.y ), Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(1, 0, 0)));
            
            yield return new WaitForSeconds(5);
            
            //suppression des lasers
            Destroy(point1);
            Destroy(trait1);
            Destroy(point2);
            Destroy(trait2);
            Destroy(point3);
            Destroy(trait3);
            
            // quatriemes attaques
            depart1= new  Vector2(-20, 1); 
            depart2= new Vector2(-20, -8);
            depart3 = new Vector2(-20, 15);
        
            // création de l'origine des lasers
            point1 = Instantiate(startLazerPrefab, depart1, gameObject.transform.rotation);
            point2 = Instantiate(startLazerPrefab, depart2, gameObject.transform.rotation);
            point3 = Instantiate(startLazerPrefab, depart3, gameObject.transform.rotation);
            
            yield return new WaitForSeconds(2);
        
            // création des lasers
            trait1 = Instantiate(lazerPrefab, new Vector3(0, point1.transform.position.y ), Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(1, 0, 0)));
            trait2 = Instantiate(lazerPrefab, new Vector3(0, point2.transform.position.y ), Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(1, 0, 0)));
            trait3 = Instantiate(lazerPrefab, new Vector3(0, point3.transform.position.y ), Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(1, 0, 0)));

            yield return new WaitForSeconds(5);
            
            //suppression des lasers
            Destroy(point1);
            Destroy(trait1);
            Destroy(point2);
            Destroy(trait2);
            Destroy(point3);
            Destroy(trait3);
        }
    }
    
    IEnumerator SJKaleido()
    {
        float speed = 2f;
        float offset = 2f;
        for (int i = 0; i < 4; i += 1)
        {
            Vector3 origine = player.transform.position;
            for (int j = 0; j < 6; j += 1)
            {
                GameObject point = Instantiate(ballPrefab,new Vector3(origine.x + offset * Mathf.Cos(Mathf.PI * j /3),origine.y + offset * Mathf.Sin(Mathf.PI*j /3), 0),gameObject.transform.rotation);
                Vector3 direction = Vector3.Normalize(player.transform.position - point.transform.position);
                point.GetComponent<Rigidbody2D>().velocity = direction;
            }

            yield return new WaitForSeconds(5);
        }
        
        
    }
}
