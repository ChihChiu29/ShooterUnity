using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameobject;
using sprite;
using NUnit.Framework;
using script;

public class IntegrationTest : MonoBehaviour
{

  // Use this for initialization
  void Start ()
  {
    TestObjectProvider ();
    TestAddScript ();
  }

  public void TestObjectProvider ()
  {
    GameObject test1 = 
      ObjectProvider.CreateRigidObject (
        "test1",
        SpriteProvider.GetAirship (),
        radiusFactor: 0.3f,
        location: new Vector2 (5, 5));
    Assert.AreEqual ("test1", test1.name);
    Assert.NotNull (test1.GetComponent<SpriteRenderer> ().sprite);

    GameObject test2 = 
      ObjectProvider.CreateRigidObject (
        "test2", SpriteProvider.GetPlayerSprite (), 
        location: new Vector2 (0, 1));
    Assert.AreEqual ("test2", test2.name);
    Assert.NotNull (test1.GetComponent<SpriteRenderer> ().sprite);
  }

  public void TestAddScript ()
  {
    GameObject player = 
      ObjectProvider.CreateRigidObject (
        "palyer", SpriteProvider.GetPlayerSprite ());
    RigidbodyKeyboardController controller = 
      ScriptProvider.AddScript<RigidbodyKeyboardController> (player);
    controller.velocityScale = 1.0f;
  }
}
