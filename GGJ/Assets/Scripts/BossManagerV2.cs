using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossManagerV2 : MonoBehaviour
{
    [SerializeField] GameObject projectilePoint;
    [SerializeField] GameObject projectileTrait;
    [SerializeField] private float speedBallCouloir= 10f;
    public List<GameObject> ProjectileList = new List<GameObject>();
    private Player _player;
    
    

    public void Update()
    {
        _player=GetComponentInParent<Player>(); // ligne à changer avec la vraie position du joueur
    }
    
    
    void PatternCouloir()
    {
        StartCoroutine(CouloirLaser());
        for (int i = 0; i < 10; i += 1)
        {
            Vector3 direction = Vector3.Normalize(_player.transform.position - gameObject.transform.position);
            StartCoroutine(CreateBoule(1.5f, speedBallCouloir * direction, projectilePoint));
        }
    }

IEnumerator CouloirLaser()
{
    Vector2 depart; 
    depart= new  Vector2(10, 20); 
    Vector2 origine;
    origine= new Vector2(0, 20); 
    float speed=10f;
        
    // création de l'origine des lasers
    GameObject point1 = Instantiate(projectilePoint);
    ProjectileList.Add(point1);
    point1.transform.position = depart;
    GameObject point2 = Instantiate(projectilePoint);
    ProjectileList.Add(point2);
    point2.transform.position = new Vector3((origine.x - depart.x),depart.y );
    yield return new WaitForSeconds(2);
        
    // création des lasers
    GameObject trait1 = Instantiate(projectileTrait);
    ProjectileList.Add(trait1);
    GameObject trait2 = Instantiate(projectileTrait);
    ProjectileList.Add(trait2);
    trait1.transform.position = new Vector3(point1.transform.position.x, point1.transform.position.y / 2);
    trait2.transform.position = new Vector3(point2.transform.position.x, point2.transform.position.y / 2);
    
    //mouvement des lasers 
    trait1.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed , 0);
    trait2.GetComponent<Rigidbody2D>().velocity = new Vector2(speed , 0);
    yield return new WaitForSeconds(30);
    Destroy(point1);
    Destroy(trait1);
    Destroy(point2);
    Destroy(trait2);
}

private IEnumerator CreateBoule(float f, Vector3 direction, GameObject ballPrefab)
{
    yield return new WaitForSeconds(f);

    GameObject ball = Instantiate(ballPrefab, gameObject.transform.position, gameObject.transform.rotation);
    ball.GetComponent<Rigidbody2D>().velocity = direction;

    yield return new WaitForSeconds(0.1f);

    ball.GetComponent<SpriteRenderer>().enabled = true;
}
}
