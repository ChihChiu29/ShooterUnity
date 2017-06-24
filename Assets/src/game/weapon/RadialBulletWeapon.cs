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
    private GameObject target;
    private Dictionary<int, float> pattern;

    public RadialBulletWeapon (
      // Host of the weapon.
      GameObject host,
      GameObject target,
      // A dictionary of {angle: bullet speed}.
      Dictionary<int, float> pattern)
    {
      this.host = host;
      this.target = target;
      this.pattern = pattern;
    }

    public void Fire (float direction = 0)
    {
      if (target != null) {
        direction = math.Angle.GetAngleTowards (host.transform.position, target.transform.position);
      }

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