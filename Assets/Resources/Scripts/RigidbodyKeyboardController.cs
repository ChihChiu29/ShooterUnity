using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyKeyboardController : MonoBehaviour
{
  public float velocityScale = 10.0f;

  private Rigidbody2D rigidBody;

  // Use this for initialization
  void Start ()
  {
    rigidBody = GetComponent<Rigidbody2D> ();
  }
	
  // Update is called once per frame
  void Update ()
  {
    if (Input.GetKeyDown ("w")) {
      rigidBody.velocity = Vector2.up * velocityScale;
      rigidBody.AddForce (Vector2.up * velocityScale);      
    }

    if (Input.GetKeyDown ("s")) {
      rigidBody.velocity = Vector2.down * velocityScale;
      rigidBody.AddForce (Vector2.down * velocityScale);      
    }

    if (Input.GetKeyDown ("a")) {
      rigidBody.velocity = Vector2.left * velocityScale;
      rigidBody.AddForce (Vector2.left * velocityScale);      
    }

    if (Input.GetKeyDown ("d")) {
      rigidBody.velocity = Vector2.right * velocityScale;
      rigidBody.AddForce (Vector2.right * velocityScale);      
    }
  }
}
