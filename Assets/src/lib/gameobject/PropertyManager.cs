using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Remember to keep prefabs under Assets/Resources/Prefabs/ folder.

namespace gameobject
{
  public class PropertyManager
  {
    public static Tag GetTagComponent (GameObject obj)
    {
      return obj.GetComponent<Tag> ();
    }

    public static Health GetHealthComponent (GameObject obj)
    {
      return obj.GetComponent<Health> ();
    }

    public static Vector2 GetPosition (GameObject obj)
    {
      return new Vector2 (obj.transform.position.x, obj.transform.position.y);
    }

    public static float GetSpriteScale (GameObject obj)
    {
      Sprite sprite = obj.GetComponent<SpriteRenderer> ().sprite;
      return sprite.bounds.extents.x + sprite.bounds.extents.y;
    }

    public static float GetRadius (GameObject obj)
    {
      return obj.GetComponent<CircleCollider2D> ().radius;
    }
  }
}