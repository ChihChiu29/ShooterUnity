using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using weapon;
using UnityEngine.Networking.NetworkSystem;

public class WeaponAutoController : MonoBehaviour
{
  public Weapon weapon = null;
  public float fireDirectionDegree = 90;
  public GameObject target = null;
  public float timeIntervalBetweenFires = 0.5f;
  // Turn speed in degrees.
  public float turretTurnSpeed = 20;

  private float lastFireTime;

  // Use this for initialization
  void Start ()
  {
    lastFireTime = Time.time;
  }
	
  // Update is called once per frame
  void Update ()
  {
    if (weapon == null || gameObject.layer != Layer.DefaultLayer) {
      return;
    }

    // Turn weapon
    float turretTurnDegree = turretTurnSpeed * Time.deltaTime;
    float angleDifference = 
      math.Angle.GetAngleBetween (
        new Vector2 (
          Mathf.Cos (fireDirectionDegree * Mathf.Deg2Rad), 
          Mathf.Sin (fireDirectionDegree * Mathf.Deg2Rad)),
        target.transform.position - gameObject.transform.position);

    if (angleDifference > 0) {
      if (angleDifference > turretTurnDegree) {
        fireDirectionDegree += turretTurnDegree;
      } else {
        fireDirectionDegree += angleDifference;
      }
    } else {
      if (angleDifference < -turretTurnDegree) {
        fireDirectionDegree -= turretTurnDegree;
      } else {
        fireDirectionDegree += angleDifference;
      }
    }

    // Fire weapon
    float currentTime = Time.time;
    if (currentTime > lastFireTime + timeIntervalBetweenFires) {
      weapon.Fire (fireDirectionDegree);
      lastFireTime = currentTime;
    }
  }
}
