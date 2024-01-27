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
      Destroy(gameObject);
      
   }
}
