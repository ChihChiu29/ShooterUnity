using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameobject;

public class Health : MonoBehaviour
{
  // Health >= 0 means the object is alive.
  public int health = 0;

  // Update is called once per frame
  void Update ()
  {
    if (health < 0) {
      ObjectFactory.CreateExplosion (
        new Vector2 (transform.position.x, transform.position.y),
        initialScale: 0.1f,
        finalScale: 0.6f,
        expansionSpeed: 1.5f);

      Object.Destroy (gameObject);
    }
  }

  public int TakeDamage (int damage)
  {
    return ChangeHealth (-damage);
  }

  private int ChangeHealth (
    // Change health by this amount.
    int delta)
  {
    health += delta;
    return health;
  }
}
