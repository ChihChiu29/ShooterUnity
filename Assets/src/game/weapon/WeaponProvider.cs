using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace weapon
{
  public class WeaponProvider
  {
    public static Weapon CreateRandomWeapon (
      GameObject host,
      // Level of the weapon.
      int level)
    {
      int weaponType = Random.Range (1, 3);

      if (weaponType == 1) {
        return CreateRandomRadialBulletWeapon (
          host,
          Random.Range (25, 45),
          power: level, 
          bulletSpeedLowerBound: 1 + level, 
          bulletSpeedUpperBound: 5 + level);
      } else if (weaponType == 2) {
        return CreateRandomDoubleDirectionCircularBulletWeapon (host);
      }

      return null;
    }

    public static RadialBulletWeapon CreateRandomRadialBulletWeapon (
      // The host.
      GameObject host,
      // Half of the spread of the overall fire direction.
      int halfSpread,
      // The higher the power, the more powerful the weapon.
      int power,
      // Speed of the bullets.
      int bulletSpeedLowerBound = 1,
      int bulletSpeedUpperBound = 10)
    {
      Dictionary<int, float> pattern = new Dictionary<int, float> ();
      for (int i = 0; i < power; i++) {
        int direction = 
          Random.Range (-halfSpread, halfSpread);
        pattern [direction] = 
          Random.Range (bulletSpeedLowerBound, bulletSpeedUpperBound + 1);
      }
      return new RadialBulletWeapon (host, pattern);
    }

    public static DoubleDirectionCircularBulletWeapon 
    CreateRandomDoubleDirectionCircularBulletWeapon (
      // The host.
      GameObject host)
    {
      return new DoubleDirectionCircularBulletWeapon (
        host,
        bulletSpeed: Random.Range (2, 10),
        angleLowerBound: Random.Range (-45, 0),
        angleUpperBound: Random.Range (0, 45),
        angleIncrement: Random.Range (1, 20));
    }
  }
}