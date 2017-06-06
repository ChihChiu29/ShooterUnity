using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

namespace sprite
{
	public class SpriteRepository
	{
		public static Dictionary<string, Sprite[]> dict = new Dictionary<string, Sprite[]> ();

		public static Sprite GetSpriteFromSheet (string name)
		{
			string query = @"((\w|-|_|\s)+/)*((\w|-|_|\s)+)(_)(\d+)$";

			Match match = Regex.Match (name, query);

			string sprName = match.Groups [3].Value;
			string sprPath = name.Remove (name.LastIndexOf ('_'));
			int sprIndex = int.Parse (match.Groups [6].Value);

			Sprite[] group;
			if (!dict.TryGetValue (name, out group)) {
				dict [name] = Resources.LoadAll<Sprite> (sprPath);
			}

			return dict [name] [sprIndex];
		}
	}
}