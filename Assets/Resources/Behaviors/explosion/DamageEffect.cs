using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameobject;

public class DamageEffect : MonoBehaviour
{

  public int damage = 1;

  void OnTriggerEnter2D (Collider2D coll)
  {
    ApplyDamage (coll);
  }

  void OnTriggerStay2D (Collider2D coll)
  {
    ApplyDamage (coll);
  }

  private void ApplyDamage (Collider2D coll)
  {
    GameObject victim = coll.gameObject;
    Health health = PropertyManager.GetHealthComponent (coll.gameObject);
    if (health != null) {
      health.TakeDamage (damage);
    }
  }
}
