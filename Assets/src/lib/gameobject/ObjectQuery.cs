using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Remember to keep prefabs under Assets/Resources/Prefabs/ folder.

namespace gameobject
{
  public class ObjectQuery
  {
    public static Vector2 GetPosition (GameObject obj)
    {
      return new Vector2 (obj.transform.position.x, obj.transform.position.y);
    }

    public static float GetRadius (GameObject obj)
    {
      return obj.GetComponent<CircleCollider2D> ().radius;
    }
  }
}