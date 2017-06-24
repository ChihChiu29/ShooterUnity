using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using audio;

public class PlaySoundOnHit : MonoBehaviour
{
  void OnCollisionEnter2D (Collision2D coll)
  {
    AudioPlayer.PlayHitSound01 ();
  }
}
