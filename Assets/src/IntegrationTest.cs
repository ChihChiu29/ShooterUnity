using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objectprovider;
using sprite;
using NUnit.Framework;

public class IntegrationTest : MonoBehaviour
{

  // Use this for initialization
  void Start ()
  {
    TestObjectProvider ();
  }

  public void TestObjectProvider ()
  {
    GameObject test1 = 
      ObjectProvider.CreateRigidObject (
        "test1", SpriteProvider.GetAirship (), 
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
}
