using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace weapon
{
  public interface Weapon
  {
    void Fire (
      // 0 being to the right, counter-clockwisely.
      float direction = 0);
  }
}
