using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameobject;

namespace weapon
{
  // Fires bullets radically.
  public class RadicalBulletWeapon : Weapon
  {
    private GameObject host;
    private Dictionary<int, float> pattern;

    public RadicalBulletWeapon (
      // Host of the weapon.
      GameObject host,
      // A dictionary of {angle: bullet speed}.
      Dictionary<int, float> pattern)
    {
      this.host = host;
      this.pattern = pattern;
    }

    public void Fire ()
    {
      Vector2 position = ObjectQuery.GetPosition (host);
      float radius = ObjectQuery.GetRadius (host);
      foreach (int angle in pattern.Keys) {
        float speed = pattern [angle];
        ObjectFactory.CreateBullet (
          new Vector2 (position.x + radius * Mathf.Cos (Mathf.Deg2Rad * angle), 
            position.y + radius * Mathf.Sin (Mathf.Deg2Rad * angle)),
          facing: angle, 
          speed: speed);
      }
    }
  }
}