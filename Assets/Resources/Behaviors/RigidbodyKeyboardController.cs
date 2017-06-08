using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RigidbodyKeyboardController : MonoBehaviour
{
  // How fast does the object move when the key is down.
  public float speed = 40.0f;

  private Rigidbody2D rigidBody;

  // Use this for initialization
  void Start ()
  {
    rigidBody = GetComponent<Rigidbody2D> ();
  }
	
  // Update is called once per frame
  void Update ()
  {
    Vector2 velocity = Vector2.zero;

    if (Input.GetKey ("w")) {
      velocity += Vector2.up;
    }

    if (Input.GetKey ("s")) {
      velocity += Vector2.down;
    }

    if (Input.GetKey ("a")) {
      velocity += Vector2.left;
    }

    if (Input.GetKey ("d")) {
      velocity += Vector2.right;
    }

    rigidBody.velocity = velocity * speed;
  }
}
