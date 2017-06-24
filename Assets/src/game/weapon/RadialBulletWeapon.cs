using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameobject;

namespace weapon
{
  // Fires bullets radically.
  public class RadialBulletWeapon : Weapon
  {
    private GameObject host;
    private Dictionary<int, float> pattern;

    public RadialBulletWeapon (
      // Host of the weapon.
      GameObject host,
      // A dictionary of {angle: bullet speed}.
      Dictionary<int, float> pattern)
    {
      this.host = host;
      this.pattern = pattern;
    }

    public void Fire (float direction = 0)
    {
      Vector2 position = PropertyManager.GetPosition (host);
      float radius = PropertyManager.GetRadius (host);
      foreach (int angle in pattern.Keys) {
        float speed = pattern [angle];
        float angleInDirection = angle + direction;
        ObjectFactory.CreateBullet (
          new Vector2 (position.x + radius * Mathf.Cos (
            Mathf.Deg2Rad * angleInDirection), 
            position.y + radius * Mathf.Sin (Mathf.Deg2Rad * angleInDirection)),
          PropertyManager.GetTagComponent (host).easyTag,
          facing: angleInDirection, 
          speed: speed);
      }
    }
  }
}