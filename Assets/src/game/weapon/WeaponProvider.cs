using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace weapon
{
  public class WeaponProvider
  {
    public static Weapon CreateRandomWeapon (
      GameObject host,
      GameObject target,
      // Fire direction.
      int fireDirectionAngle,
      // Level of the weapon.
      int level)
    {
      int weaponType = Random.Range (1, 3);

      if (weaponType == 1) {
        return CreateRandomRadialBulletWeapon (
          host,
          target,
          Random.Range (25, 45),
          fireDirectionAngle,
          power: level, 
          bulletSpeedLowerBound: 1 + level, 
          bulletSpeedUpperBound: 5 + level);
      } else if (weaponType == 2) {
        return CreateRandomDoubleDirectionCircularBulletWeapon (
          host,
          target,
          fireDirectionAngle);
      }

      return null;
    }

    public static RadialBulletWeapon CreateRandomRadialBulletWeapon (
      // The host.
      GameObject host,
      GameObject target,
      // Half of the spread of the overall fire direction.
      int halfSpread,
      int fireDirection,
      // The higher the power, the more powerful the weapon.
      int power,
      // Speed of the bullets.
      int bulletSpeedLowerBound = 1,
      int bulletSpeedUpperBound = 10)
    {
      Dictionary<int, float> pattern = new Dictionary<int, float> ();
      for (int i = 0; i < power; i++) {
        int direction = 
          Random.Range (fireDirection - halfSpread, fireDirection + halfSpread);
        pattern [direction] = 
          Random.Range (bulletSpeedLowerBound, bulletSpeedUpperBound + 1);
      }
      return new RadialBulletWeapon (host, target, pattern);
    }

    public static DoubleDirectionCircularBulletWeapon 
    CreateRandomDoubleDirectionCircularBulletWeapon (
      // The host.
      GameObject host,
      GameObject target,
      int fireDirection)
    {
      return new DoubleDirectionCircularBulletWeapon (
        host,
        target,
        bulletSpeed: Random.Range (2, 10),
        angleLowerBound: Random.Range (fireDirection - 45, fireDirection),
        angleUpperBound: Random.Range (fireDirection, fireDirection + 45),
        angleIncrement: Random.Range (1, 20));
    }
  }
}