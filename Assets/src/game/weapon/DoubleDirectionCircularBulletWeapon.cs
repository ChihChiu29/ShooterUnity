using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameobject;

namespace weapon
{
  // Fires bullets from angleLowerBound to angleUpperBound, each time angle
  // change by angleIncrement.
  public class DoubleDirectionCircularBulletWeapon : Weapon
  {
    private GameObject host;
    private float bulletSpeed;
    private int angleLowerBound;
    private int angleUpperBound;
    private int angleIncrement;

    private int currentAngle;
    // +/- 1.
    private int currentAngleIncrementDirection = 1;

    private Dictionary<int, float> pattern;

    public DoubleDirectionCircularBulletWeapon (
      // Host of the weapon.
      GameObject host,
      int bulletSpeed,
      int angleLowerBound,
      int angleUpperBound,
      int angleIncrement)
    {
      this.host = host;
      this.bulletSpeed = bulletSpeed;
      this.angleLowerBound = angleLowerBound;
      this.angleUpperBound = angleUpperBound;
      this.angleIncrement = angleIncrement;
      this.currentAngle = angleLowerBound;
    }

    public void Fire ()
    {
      Vector2 position = PropertyManager.GetPosition (host);
      float radius = PropertyManager.GetRadius (host);

      ObjectFactory.CreateBullet (
        new Vector2 (
          position.x + radius * Mathf.Cos (Mathf.Deg2Rad * currentAngle), 
          position.y + radius * Mathf.Sin (Mathf.Deg2Rad * currentAngle)),
        PropertyManager.GetTagComponent (host).easyTag,
        facing: currentAngle, 
        speed: bulletSpeed);

      currentAngle += angleIncrement * currentAngleIncrementDirection;
      if (currentAngle >= angleUpperBound) {
        currentAngleIncrementDirection = -1;
      }
      if (currentAngle <= angleLowerBound) {
        currentAngleIncrementDirection = 1;
      }
    }
  }
}