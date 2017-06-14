using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPushEffect : MonoBehaviour
{
  // Push force goes with 1/r.
  public float pushForceScale = 3f;

  void OnTriggerEnter2D (Collider2D coll)
  {
    ApplyForce (coll);
  }

  void OnTriggerStay2D (Collider2D coll)
  {
    ApplyForce (coll);
  }

  private void ApplyForce (Collider2D coll)
  {
    GameObject victim = coll.gameObject;
    Vector2 explosionCenter = 
      new Vector2 (transform.position.x, transform.position.y);
    Vector2 victimCenter =
      new Vector2 (victim.transform.position.x, victim.transform.position.y);
    Vector2 direction = victimCenter - explosionCenter;
    float distance = direction.magnitude;

    Rigidbody2D rigidbody = coll.gameObject.GetComponent<Rigidbody2D> ();
    rigidbody.AddForce (direction / (distance * distance) * pushForceScale);
  }
}
