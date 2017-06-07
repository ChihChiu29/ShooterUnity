using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameobject;
using sprite;

public class Playground : MonoBehaviour
{
  public float bulletVelocity = 10.0f;

  // Use this for initialization
  void Start ()
  {
    GameObject enemy = 
      ObjectProvider.CreateRigidObject (
        "enemy", SpriteProvider.GetAirship (),
        radiusFactor: 0.3f,
        location: new Vector2 (0, 4));
    RigidbodyKeyboardController controller = 
      enemy.AddComponent<RigidbodyKeyboardController> ();
    controller.velocityScale = 1.0f;

    GameObject bullet1 = 
      ObjectProvider.CreateRigidObject (
        "bullet", 
        SpriteProvider.GetBullet (),
        location: new Vector2 (0.5f, -2),
        velocity: new Vector2 (0, bulletVelocity));

    GameObject bullet2 = 
      ObjectProvider.CreateRigidObject (
        "bullet", 
        SpriteProvider.GetBullet (),
        location: new Vector2 (0.6f, -3),
        velocity: new Vector2 (0, bulletVelocity));

    GameObject bullet3 = 
      ObjectProvider.CreateRigidObject (
        "bullet", 
        SpriteProvider.GetBullet (),
        location: new Vector2 (0.8f, -4),
        velocity: new Vector2 (0, bulletVelocity));
  }
	
  // Update is called once per frame
  void Update ()
  {
		
  }
}
