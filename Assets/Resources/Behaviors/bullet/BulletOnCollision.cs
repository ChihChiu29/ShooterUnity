using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameobject;

public class BulletOnCollision : MonoBehaviour
{
  void OnCollisionEnter2D (Collision2D coll)
  {
    string myTag = PropertyManager.GetTagComponent (gameObject).easyTag;
    string collTag = PropertyManager.GetTagComponent (coll.gameObject).easyTag;

    if (collTag == Tag.Boundary || collTag == Tag.Static) {
      Object.Destroy (gameObject);
    }

    if (ShouldExplode (myTag, collTag)) {
      PropertyManager.ApplyDamage (gameObject, 1);
      PropertyManager.ApplyDamage (coll.gameObject, 1);
    }
  }

  private static bool ShouldExplode (string myTag, string collTag)
  {
    return (myTag == Tag.Player && collTag == Tag.Enemy) ||
    (myTag == Tag.Enemy && collTag == Tag.Player);
  }
}
