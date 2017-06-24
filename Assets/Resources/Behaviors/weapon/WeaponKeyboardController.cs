using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using weapon;
using audio;

public class WeaponKeyboardController : MonoBehaviour
{
  public Weapon weapon = null;
  public float timeIntervalBetweenFires = 0.15f;

  private float lastFireTime;

  // Use this for initialization
  void Start ()
  {
    lastFireTime = Time.time;
  }

  // Update is called once per frame
  void Update ()
  {
    if (weapon == null) {
      return;
    }

    float currentTime = Time.time;
    if (currentTime > lastFireTime + timeIntervalBetweenFires) {
      if (Input.GetKey ("j")) {
        weapon.Fire (180);
      } else if (Input.GetKey ("k")) {
        weapon.Fire (-90);
      } else if (Input.GetKey ("l")) {
        weapon.Fire (0);
      } else if (Input.GetKey ("i")) {
        weapon.Fire (90);
      }
      lastFireTime = currentTime;
    }
  }
}
