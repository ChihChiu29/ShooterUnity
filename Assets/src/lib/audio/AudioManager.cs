using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Director;
using System.IO;

namespace audio
{
  public class AudioManager
  {
    public static void PlayOneShot (AudioClip clip, float volumeScale = 5)
    {
      GetAudioSource ().PlayOneShot (clip, volumeScale: volumeScale);
    }

    private static AudioSource GetAudioSource ()
    {
      return Global.audioManager.GetComponent<AudioSource> ();
    }
  }
}
