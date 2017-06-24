using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace math
{
  public class Angle
  {
    private static Vector2 xAxis = new Vector2 (1, 0);
    
    // Returns: 0 means to the right.
    public static float GetAngleTowards (Vector2 baseLocation, Vector2 targetLocation)
    {
      Vector2 baseToTarget = targetLocation - baseLocation;
      if (baseToTarget.y > 0) {
        return Vector2.Angle (xAxis, baseToTarget);
      } else {
        return -Vector2.Angle (xAxis, baseToTarget);
      }
    }
  }
}
