using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace weapon
{
  public interface Weapon
  {
    void Fire (
      // The default direction of a weapon.
      float direction = 0);
  }
}
