using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.NetworkInformation;
using sprite;
using gameobject;

public class ObjectFactory
{
  public static GameObject GetPlayer ()
  {
    GameObject player = 
      ObjectProvider.CreateRigidObject (
        "player",
        SpriteProvider.GetPlayer ());
    return player;
  }

  public static GameObject GetAirship ()
  {
    GameObject airship =
      ObjectProvider.CreateRigidObject (
        "airship",
        SpriteProvider.GetAirship (),
        radiusFactor: 0.3f);
    return airship;
  }

  public static GameObject GetBullet ()
  {
    GameObject bullet =
      ObjectProvider.CreateRigidObject (
        "bullet", 
        SpriteProvider.GetBullet ());
    return bullet;
  }
}
