using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace audio
{
  public class AudioClipProvider
  {
    private static string CLIP_FOLDER = "AudioClips/";

    private static Dictionary<string, AudioClip> cache = 
      new Dictionary<string, AudioClip> ();

    public static AudioClip GetAudioClipByRelativePath (
      /* The path under CLIP_FOLDER, no extension. */
      string relativePath)
    {
      AudioClip unused;
      if (!cache.TryGetValue (relativePath, out unused)) {
        cache [relativePath] = 
          Resources.Load<AudioClip> (GetFullPath (relativePath));
      }
      return cache [relativePath];
    }

    private static string GetFullPath (string name)
    {
      return Path.Combine (CLIP_FOLDER, name);
    }
  }
}
