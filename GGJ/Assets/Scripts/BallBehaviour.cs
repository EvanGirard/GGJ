using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.TryGetComponent(out Player playerScript))
      {
         playerScript.ApplyDamage(5f);
      }
      if (other.TryGetComponent(out BallBehaviour ball))
      {
         //Debug.Log(other);
         return;
      }
      Destroy(gameObject);
      
   }

   /*private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         Debug.Log(other);
      }
      Destroy(gameObject);
   }*/
}
