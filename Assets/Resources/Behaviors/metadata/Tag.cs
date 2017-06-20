using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tag : MonoBehaviour
{
  // Obsoleted.
  public static string Boundary = "boundary";

  // Manager objects are not visible and they do not interact with other
  // objects in the usual way (physics engine, collision, etc.). They are only
  // hosts of scripts.
  public static string ManagerObject = "manager_object";
  // Static objects do not feel force from rigidbodies.
  public static string Static = "static";
  public static string Player = "player";
  public static string Enemy = "enemy";
  public static string Explosion = "explosion";

  public string easyTag;
}
