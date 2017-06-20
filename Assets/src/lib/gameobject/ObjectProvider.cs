using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// Remember to keep prefabs under Assets/Resources/Prefabs/ folder.
using game;

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
      Vector2 velocity = default(Vector2),
      // Health.
      int health = 0)
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

      float radius = PropertyManager.GetSpriteScale (obj) * radiusFactor;
      CircleCollider2D collider = obj.GetComponent<CircleCollider2D> ();
      collider.radius = radius;

      PropertyManager.GetHealthComponent (obj).health = health;

      return obj;
    }

    public static GameObject CreateExplosion (
      // Name of the object.
      string name,
      // Sprite for the object.
      Sprite sprite,
      // The initial scale of the sprite.
      float initialScale = 0.1f,
      // The final scale of the sprite.
      float finalScale = 2f,
      // How fast is the explosion.
      float expansionSpeed = 20f,
      // How much should the sprite be rotated counter-clockwisely.
      float rotation = 0.0f,
      // Radius of the object, used for collision detection.
      // The actual radius is calcualed as (width + height) / 2 * radiusFactor.
      float radiusFactor = 0.5f,
      // The location of the object.
      Vector2 location = default(Vector2))
    {
      GameObject obj = 
        MonoBehaviour.Instantiate (
          Resources.Load<GameObject> (GetFullPath ("BasicExplosion")), 
          location,
          Quaternion.identity);
      obj.name = name;

      SpriteRenderer renderer = obj.GetComponent<SpriteRenderer> ();
      renderer.sprite = sprite;

      obj.transform.localScale = new Vector3 (initialScale, initialScale, 1);

      obj.transform.Rotate (Vector3.forward * rotation);

      float radius = PropertyManager.GetSpriteScale (obj) * radiusFactor;
      CircleCollider2D collider = obj.GetComponent<CircleCollider2D> ();
      collider.radius = radius;
      collider.isTrigger = true;

      // Set parameters on expansion.
      ExpansionEffect expansionEffect = obj.GetComponent<ExpansionEffect> ();
      expansionEffect.currentScale = initialScale;
      expansionEffect.finalScale = finalScale;
      expansionEffect.expansionSpeed = expansionSpeed;

      return obj;
    }

    private static string GetFullPath (string name)
    {
      return Path.Combine (PREFAB_FOLDER, name);
    }

    public static GameObject CreateStaticRectangularObject (
      string name,
      Rect area)
    {
      GameObject obj = 
        MonoBehaviour.Instantiate (
          Resources.Load<GameObject> (GetFullPath ("StaticBody")),
          area.center,
          Quaternion.identity);
      obj.name = name;
      PropertyManager.SetTag (obj, Tag.Static);

      obj.transform.localScale = new Vector3 (area.width, area.height, 1);

      return obj;
    }

    public static GameObject CreateAnimationManager ()
    {
      GameObject obj = 
        MonoBehaviour.Instantiate (
          Resources.Load<GameObject> (GetFullPath ("AnimationManager")),
          Vector2.zero,
          Quaternion.identity);
      obj.name = "animation manager";
      PropertyManager.SetTag (obj, Tag.ManagerObject);

      Global.animationManager = obj;
      return obj;
    }
  }
}