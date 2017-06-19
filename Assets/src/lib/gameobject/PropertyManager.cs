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

    // Returning -1 if the object does not have health component.
    public static int ApplyDamage (GameObject obj, int damage)
    {
      Health healthComponent = GetHealthComponent (obj);
      if (healthComponent != null) {
        return healthComponent.ApplyDamage (damage);
      }
      return -1;
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