using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using weapon;
using UnityEngine.Networking.NetworkSystem;

public class WeaponAutoController : MonoBehaviour
{
  public Weapon weapon = null;
  public float timeIntervalBetweenFires = 0.5f;

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
      weapon.Fire ();
      lastFireTime = currentTime;
    }
  }
}
