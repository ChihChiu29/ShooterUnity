using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace audio
{
  public class AudioPlayer
  {
    // QPS for playing the same audio clip < 1/throttleTime.
    public static float throttleTime = 0.05f;

    // {clipRelativePath: lastPlayedTime}
    private static Dictionary<string, float> lastPlayed = 
      new Dictionary<string, float> ();

    public static void PlayLaserSound ()
    {
      PlayOneShotThrottled ("laser");
    }

    public static void PlayBulletSound ()
    {
      PlayOneShotThrottled ("bullet");
    }

    public static void PlayHitSound01 ()
    {
      PlayOneShotThrottled ("hit01");
    }

    public static void PlayExplosionSound ()
    {
      PlayOneShotThrottled ("explosionPlayS");
    }


    private static void PlayOneShotThrottled (
      // The relative path to the clip file under the audio clip folder.
      string clipRelativePath)
    {
      float lastPlayTime = 0;
      lastPlayed.TryGetValue (clipRelativePath, out lastPlayTime);
      float currentTime = Time.time;
      if (currentTime > lastPlayTime + throttleTime) {
        lastPlayed [clipRelativePath] = currentTime;
        AudioManager.PlayOneShot (
          AudioClipProvider.GetAudioClipByRelativePath (clipRelativePath));
      }
    }
  }
}
