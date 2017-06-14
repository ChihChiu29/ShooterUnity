﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameobject;

public class BulletOnCollision : MonoBehaviour
{
  void OnCollisionEnter2D (Collision2D coll)
  {
    string myTag = PropertyManager.GetMetadata (gameObject).tag;
    string collTag = PropertyManager.GetMetadata (coll.gameObject).tag;

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
