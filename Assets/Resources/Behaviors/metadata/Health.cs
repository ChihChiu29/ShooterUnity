using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameobject;
using game;

public class Health : MonoBehaviour
{
  // Health >= 0 means the object is alive.
  public int health = 0;

  // Update is called once per frame
  void Update ()
  {
    if (health < 0) {
      // Explosion based on the side of the object.
//      float radius = PropertyManager.GetRadius (gameObject);
//      ObjectFactory.CreateExplosion (
//        new Vector2 (transform.position.x, transform.position.y),
//        initialScale: 0.1f * radius,
//        finalScale: 1.2f * radius,
//        expansionSpeed: 0.5f);

      ObjectFactory.CreateExplosion (
        new Vector2 (transform.position.x, transform.position.y),
        initialScale: 0.1f,
        finalScale: 0.4f,
        expansionSpeed: 1.2f);

      Object.Destroy (gameObject);
    }
  }

  public void SetHealth (int newHealth)
  {
    health = newHealth;
  }

  public int ApplyDamage (int damage)
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
