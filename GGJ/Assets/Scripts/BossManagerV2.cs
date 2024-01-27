using System;
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
    private GameObject trait1;
    private GameObject trait3;
    private GameObject trait2;
    

    public void Update()
    {
        _player=GetComponentInParent<Player>(); // ligne à changer avec la vraie position du joueur
        if (trait1.transform.position.x == 5f && trait2.transform.position.x == -5f)
        {
            trait1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            trait2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    IEnumerator SJKaleido()
    {
        float speed = 2f;
        float offset = 2f;
        for (int i = 0; i < 4; i += 1)
        {
            Vector3 origine = _player.transform.position;
            for (int j = 0; j < 6; j += 1)
            {
                GameObject point = Instantiate(projectilePoint,new Vector3(origine.x + offset * Mathf.Cos(Mathf.PI*i /8),origine.y + offset * Mathf.Sin(Mathf.PI*i /8)),gameObject.transform.rotation);
                Vector3 direction = Vector3.Normalize(_player.transform.position - gameObject.transform.position);
                point.GetComponent<Rigidbody2D>().velocity = direction;
                
            }

            yield return new WaitForSeconds(10);
        }
        
        
    }
    
    void PaternKaleido()
    {
        StartCoroutine(SJKaleido());
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
            GameObject point1 = Instantiate(projectilePoint);
            ProjectileList.Add(point1);
            point1.transform.position = depart1;
            GameObject point2 = Instantiate(projectilePoint);
            ProjectileList.Add(point2);
            point2.transform.position = depart2;
            yield return new WaitForSeconds(2);
        
            // création des lasers
            trait1 = Instantiate(projectileTrait);
            ProjectileList.Add(trait1);
            trait2 = Instantiate(projectileTrait);
            ProjectileList.Add(trait2);
            trait1.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(0, 1, 0));
            trait2.transform.rotation= Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(0, 1, 0));
            trait1.transform.position = new Vector3(0, point1.transform.position.y );
            trait2.transform.position = new Vector3(0, point2.transform.position.y );
            yield return new WaitForSeconds(5);
            
            //suppression des lasers
            Destroy(point1);
            Destroy(trait1);
            Destroy(point2);
            Destroy(trait2);
            
            // deuxième attaques
            depart1= new  Vector2(-20, 0); 
            depart2= new Vector2(-20, -5);
            Vector2 depart3;
            depart3 = new Vector2(-20, 5);
        
            // création de l'origine des lasers
            point1 = Instantiate(projectilePoint);
            point1.transform.position = depart1;
            point2 = Instantiate(projectilePoint);
            point2.transform.position = depart2;
            GameObject point3 = Instantiate(projectilePoint);
            point3.transform.position = depart3;
            yield return new WaitForSeconds(2);
        
            // création des lasers
            trait1 = Instantiate(projectileTrait);
            trait2 = Instantiate(projectileTrait);
            trait3 = Instantiate(projectileTrait);
            trait1.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(0, 1, 0));
            trait2.transform.rotation= Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(0, 1, 0));
            trait3.transform.rotation= Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(0, 1, 0));
            trait1.transform.position = new Vector3(0, point1.transform.position.y );
            trait2.transform.position = new Vector3(0, point2.transform.position.y );
            trait3.transform.position = new Vector3(0, point2.transform.position.y );
            yield return new WaitForSeconds(5);
            
            //suppression des lasers
            Destroy(point1);
            Destroy(trait1);
            Destroy(point2);
            Destroy(trait2);
            Destroy(point3);
            Destroy(trait3);
            
            // troisième attaques
            depart1= new  Vector2(-20, -1); 
            depart2= new Vector2(-20, -15);
            depart3 = new Vector2(-20, 8);
        
            // création de l'origine des lasers
            point1 = Instantiate(projectilePoint);
            point1.transform.position = depart1;
            point2 = Instantiate(projectilePoint);
            point2.transform.position = depart2;
            point3 = Instantiate(projectilePoint);
            point3.transform.position = depart3;
            yield return new WaitForSeconds(2);
        
            // création des lasers
            trait1 = Instantiate(projectileTrait);
            trait2 = Instantiate(projectileTrait);
            trait3 = Instantiate(projectileTrait);
            trait1.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(0, 1, 0));
            trait2.transform.rotation= Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(0, 1, 0));
            trait3.transform.rotation= Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(0, 1, 0));
            trait1.transform.position = new Vector3(0, point1.transform.position.y );
            trait2.transform.position = new Vector3(0, point2.transform.position.y );
            trait3.transform.position = new Vector3(0, point2.transform.position.y );
            yield return new WaitForSeconds(5);
            
            //suppression des lasers
            Destroy(point1);
            Destroy(trait1);
            Destroy(point2);
            Destroy(trait2);
            Destroy(point3);
            Destroy(trait3);
            
            // troisième attaques
            depart1= new  Vector2(-20, 1); 
            depart2= new Vector2(-20, -8);
            depart3 = new Vector2(-20, 15);
        
            // création de l'origine des lasers
            point1 = Instantiate(projectilePoint);
            point1.transform.position = depart1;
            point2 = Instantiate(projectilePoint);
            point2.transform.position = depart2;
            point3 = Instantiate(projectilePoint);
            point3.transform.position = depart3;
            yield return new WaitForSeconds(2);
        
            // création des lasers
            trait1 = Instantiate(projectileTrait);
            trait2 = Instantiate(projectileTrait);
            trait3 = Instantiate(projectileTrait);
            trait1.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(0, 1, 0));
            trait2.transform.rotation= Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(0, 1, 0));
            trait3.transform.rotation= Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(0, 1, 0));
            trait1.transform.position = new Vector3(0, point1.transform.position.y );
            trait2.transform.position = new Vector3(0, point2.transform.position.y );
            trait3.transform.position = new Vector3(0, point2.transform.position.y );
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
    
    void PatternBlaster()
    {
        StartCoroutine(GBlaster());
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
    trait1 = Instantiate(projectileTrait);
    ProjectileList.Add(trait1);
    trait2 = Instantiate(projectileTrait);
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
