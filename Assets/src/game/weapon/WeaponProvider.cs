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
      int power)
    {
      Dictionary<int, float> pattern = new Dictionary<int, float> ();
      for (int i = 0; i < power; i++) {
        int direction = 
          Random.Range (
            fireDirection - halfSpread, fireDirection + halfSpread);
        pattern [direction] = Random.Range (5, 30);
      }
      return new RadicalBulletWeapon (host, pattern);
    }
  }
}