using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

// Remember to keep prefabs under Assets/Resources/Prefabs/ folder.

namespace gameobject
{
  public class ObjectProvider
  {
    private static string PREFAB_FOLDER = "Prefabs/";

    public static GameObject CreateRigidObject (
      // Name of the object.
      string name,
      // Sprite for the object.
      Sprite sprite,
      // Radius of the object, used for collision detection.
      // The actual radius is calcualed as (width + height) / 2 * radiusFactor.
      float radiusFactor = 0.5f,
      // The location of the object.
      Vector2 location = default(Vector2),
      // The transform on the object.
      Quaternion transform = default(Quaternion))
    {
      GameObject obj = 
        MonoBehaviour.Instantiate (
          Resources.Load<GameObject> (GetFullPath ("BasicRigidBody")), 
          location, 
          transform);
      obj.name = name;

      SpriteRenderer renderer = obj.GetComponent<SpriteRenderer> ();
      renderer.sprite = sprite;

      float radius = 
        (sprite.bounds.extents.x + sprite.bounds.extents.y) * radiusFactor;
      CircleCollider2D collider = obj.GetComponent<CircleCollider2D> ();
      collider.radius = radius;  

      return obj;
    }

    private static string GetFullPath (string name)
    {
      return Path.Combine (PREFAB_FOLDER, name);
    }
  }
}
