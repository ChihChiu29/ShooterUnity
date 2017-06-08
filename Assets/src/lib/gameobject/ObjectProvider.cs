using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    // The scale of the sprite.
      float scale = 1.0f,
    // How much should the sprite be rotated counter-clockwisely.
      float rotation = 0.0f,
    // Radius of the object, used for collision detection.
    // The actual radius is calcualed as (width + height) / 2 * radiusFactor.
      float radiusFactor = 0.5f,
    // The location of the object.
      Vector2 location = default(Vector2),
    // The initial velocity of the object.
      Vector2 velocity = default(Vector2))
    {
      GameObject obj = 
        MonoBehaviour.Instantiate (
          Resources.Load<GameObject> (GetFullPath ("BasicRigidBody")), 
          location,
          Quaternion.identity);
      obj.name = name;

      SpriteRenderer renderer = obj.GetComponent<SpriteRenderer> ();
      renderer.sprite = sprite;

      obj.transform.localScale = new Vector3 (scale, scale, 1);

      obj.transform.Rotate (Vector3.forward * rotation);

      Rigidbody2D rigidBody = obj.GetComponent<Rigidbody2D> ();
      rigidBody.velocity = velocity;

      float radius = 
        (sprite.bounds.extents.x + sprite.bounds.extents.y) * radiusFactor;
      CircleCollider2D collider = obj.GetComponent<CircleCollider2D> ();
      collider.radius = radius;  

      return obj;
    }

    public static float GetRadius (GameObject obj)
    {
      CircleCollider2D collider = obj.GetComponent<CircleCollider2D> ();
      return collider.radius;
    }

    private static string GetFullPath (string name)
    {
      return Path.Combine (PREFAB_FOLDER, name);
    }
  }
}