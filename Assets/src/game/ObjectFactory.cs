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
    public static Sprite[] defenderSheet = 
      SpriteProvider.GetSpriteSheetByRelativePath ("defender");
    public static Sprite[] spritesSheet = 
      SpriteProvider.GetSpriteSheetByRelativePath ("sprites");
    public static Sprite airshipSprite = 
      SpriteProvider.GetSpriteByRelativePath ("airship");

    public static GameObject CreatePlayer (int level)
    {
      GameObject obj = 
        ObjectProvider.CreateRigidObject (
          "player",
          defenderSheet [28],
          scale: 1.5f,
          radiusFactor: 0.3f,
          health: level * 2);
      PropertyManager.GetTagComponent (obj).easyTag = Tag.Player;

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
      weaponController.weapon = WeaponProvider.CreateRandomWeapon (
        obj, 90, level);

      return obj;
    }

    public static GameObject CreateEnemy (
      // Starts from 1, type of enemy.
      int type,
      // Starts from 1, the higher level the more powerful the weapon.
      int level)
    {
      Sprite enemySprite;
      if (type == 1) {
        enemySprite = defenderSheet [0];
      } else if (type == 2) {
        enemySprite = defenderSheet [8];
      } else if (type == 3) {
        enemySprite = defenderSheet [15];
      } else {
        throw new UnityException ("Enemy type " + type + " not supported!");
      }
      GameObject obj = 
        ObjectProvider.CreateRigidObject (
          "enemy",
          enemySprite,
          scale: 1.5f,
          rotation: 0f,
          radiusFactor: 0.4f,
          health: level * 2);

      PropertyManager.GetTagComponent (obj).easyTag = Tag.Enemy;

      // Fix rotation.
      Rigidbody2D rigidBody = obj.GetComponent<Rigidbody2D> ();
      rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

      // Attach a weapon.
      WeaponAutoController controller = 
        obj.AddComponent<WeaponAutoController> ();
      controller.weapon = WeaponProvider.CreateRandomWeapon (obj, 270, level);
      controller.timeIntervalBetweenFires = 0.5f / (level + 1);

      return obj;
    }

    public static GameObject CreateBullet (
      Vector2 location,
      // The tag of the bullet.
      string easyTag,
      // Which direction in degree (counter-clockwisely) is the bullet facing; 
      // 0 means right (x+ direction).
      float facing = 0.0f,
      float speed = 5.0f)
    {
      GameObject obj;
      if (easyTag == Tag.Player) {
        obj = ObjectProvider.CreateRigidObject (
          "bullet", 
          spritesSheet [61],
          rotation: 90 + facing,
          radiusFactor: 0.5f,
          location: location,
          velocity: new Vector2 (
            speed * Mathf.Cos (Mathf.Deg2Rad * facing),
            speed * Mathf.Sin (Mathf.Deg2Rad * facing)),
          health: 1);
      } else {
        obj = ObjectProvider.CreateRigidObject (
          "bullet", 
          spritesSheet [59],
          rotation: 90 + facing,
          radiusFactor: 0.5f,
          location: location,
          velocity: new Vector2 (
            speed * Mathf.Cos (Mathf.Deg2Rad * facing),
            speed * Mathf.Sin (Mathf.Deg2Rad * facing)),
          health: 0);
      }

      PropertyManager.GetTagComponent (obj).easyTag = easyTag;

      // Handle collision.
      obj.AddComponent<BulletOnCollision> ();

      return obj;
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

      PropertyManager.GetTagComponent (explosion).easyTag = Tag.Explosion;

      return explosion;
    }
  }
}