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

    if (collTag == myTag) {
      return;
    }

    if (collTag != myTag && collTag != Tag.Boundary) {
      ObjectFactory.CreateExplosion (
        new Vector2 (transform.position.x, transform.position.y),
        initialScale: 0.1f,
        finalScale: 0.6f,
        expansionSpeed: 1.5f);
    }

    Object.Destroy (gameObject);
  }
}
