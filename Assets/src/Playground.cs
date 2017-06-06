using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameobject;
using sprite;

public class Playground : MonoBehaviour
{

  // Use this for initialization
  void Start ()
  {
    GameObject player = 
      ObjectProvider.CreateRigidObject (
        "test2", SpriteProvider.GetPlayerSprite (), 
        location: new Vector2 (0, 1));
    RigidbodyKeyboardController controller = player.AddComponent<RigidbodyKeyboardController> ();
    controller.velocityScale = 1.0f;
  }
	
  // Update is called once per frame
  void Update ()
  {
		
  }
}
