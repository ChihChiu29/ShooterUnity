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
    private GameObject target;
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
      GameObject target,
      int bulletSpeed,
      int angleLowerBound,
      int angleUpperBound,
      int angleIncrement)
    {
      this.host = host;
      this.target = target;
      this.bulletSpeed = bulletSpeed;
      this.angleLowerBound = angleLowerBound;
      this.angleUpperBound = angleUpperBound;
      this.angleIncrement = angleIncrement;
      this.currentAngle = angleLowerBound;
    }

    public void Fire (float direction = 0)
    {
      if (target != null) {
        direction = math.Angle.GetAngleTowards (host.transform.position, target.transform.position);
      }
      float currentAngleInDirection = currentAngle + direction;

      Vector2 position = PropertyManager.GetPosition (host);
      float radius = PropertyManager.GetRadius (host);

      ObjectFactory.CreateBullet (
        new Vector2 (
          position.x + radius * Mathf.Cos (
            Mathf.Deg2Rad * currentAngleInDirection), 
          position.y + radius * Mathf.Sin (
            Mathf.Deg2Rad * currentAngleInDirection)),
        PropertyManager.GetTagComponent (host).easyTag,
        facing: currentAngleInDirection,
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