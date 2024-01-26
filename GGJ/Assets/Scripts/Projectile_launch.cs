using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectillaunch : MonoBehaviour
{
    public Vector2 direction;
    public GameObject projectilePoint;
    public float velocity= 70f;
    
    /* Plagiat de mon autre jeu à revoir
     
    Transform dep = gameObject.transform;
    GameObject ball =Instantiate(projectile_point);
    ball.transform.position = dep.position;
    ball.transform.rotation = dep.rotation;
    ball.transform.Translate( direction * 0.25f);
    ball.GetComponent<Rigidbody2D>().velocity = dep.TransformDirection( velocity* direction ); */ 
}
