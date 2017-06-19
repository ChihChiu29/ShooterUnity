using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace weapon
{
  public class WeaponProvider
  {
    public static Weapon CreateRandomWeapon (
      // The host.
      GameObject host,
      // Which direction (degree) to fire to; 0 being to the right.
      int fireDirection,
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
          Random.Range (
            fireDirection - halfSpread, fireDirection + halfSpread);
        pattern [direction] = 
          Random.Range (bulletSpeedLowerBound, bulletSpeedUpperBound + 1);
      }
      return new RadialBulletWeapon (host, pattern);
    }
  }
}