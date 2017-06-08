using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.NetworkInformation;
using sprite;
using gameobject;
using weapon;

namespace gameobject
{
  public class ObjectFactory
  {
    public static GameObject CreatePlayer ()
    {
      GameObject obj = 
        ObjectProvider.CreateRigidObject (
          "player",
          SpriteProvider.GetSpriteByRelativePath ("airship"),
          scale: 0.25f,
          radiusFactor: 0.3f);

      // Fix rotation.
      Rigidbody2D rigidBody = obj.GetComponent<Rigidbody2D> ();
      rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

      // Attach controller.
      RigidbodyKeyboardController controller = 
        obj.AddComponent<RigidbodyKeyboardController> ();
      controller.speed = 7f;

      // Attach a weapon and a controller.
      WeaponKeyboardController weaponController = 
        obj.AddComponent<WeaponKeyboardController> ();
      weaponController.weapon = 
        WeaponProvider.CreateRandomWeapon (obj, 90, 45, 5);

      return obj;
    }

    public static GameObject CreateEnemy ()
    {
      GameObject obj = 
        ObjectProvider.CreateRigidObject (
          "enemy",
          SpriteProvider.GetSpriteByRelativePath ("airship2"),
          scale: 0.5f,
          rotation: 180f,
          radiusFactor: 0.4f);

      // Fix rotation.
      Rigidbody2D rigidBody = obj.GetComponent<Rigidbody2D> ();
      rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

      // Attach a weapon.
      WeaponAutoController controller = 
        obj.AddComponent<WeaponAutoController> ();
      controller.weapon = 
        WeaponProvider.CreateRandomWeapon (obj, -90, 0, 1);

      return obj;
    }

    public static GameObject CreateBullet (
      Vector2 location,
      // Which direction in degree (counter-clockwisely) is the bullet facing; 
      // 0 means right (x+ direction).
      float facing = 0.0f,
      float speed = 5.0f)
    {
      GameObject obj =
        ObjectProvider.CreateRigidObject (
          "bullet", 
          GetBulletSprite (),
          rotation: 180 + facing,
          radiusFactor: 0.05f,
          location: location,
          velocity: new Vector2 (
            speed * Mathf.Cos (Mathf.Deg2Rad * facing),
            speed * Mathf.Sin (Mathf.Deg2Rad * facing)));

      // Handle collision.
      obj.AddComponent<BulletOnCollision> ();

      return obj;
    }

    private static Sprite GetBulletSprite ()
    {
      Sprite[] sheet = SpriteProvider.GetSpriteSheetByRelativePath ("sprites");
      return sheet [32];
    }

    public static GameObject CreateExplosion (
      Vector2 location,
      float initialScale = 1f,
      // Final scale = initialScale * maxExpansionFactor.
      float finalScale = 10f,
      float expansionSpeed = 100f)
    {
      GameObject explosion =
        ObjectProvider.CreateExplosion (
          "explosion",
          SpriteProvider.GetSpriteByRelativePath ("explosion"),
          initialScale: initialScale,
          finalScale: finalScale,
          expansionSpeed: expansionSpeed,
          rotation: Random.Range (0, 360),
          radiusFactor: 0.5f,
          location: location);
      return explosion;
    }
  }
}