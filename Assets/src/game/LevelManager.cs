using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
  public class LevelManager
  {
    public static void GenerateLevel (
      int playerLevel,
      int difficulty,
      // Should be at least 4x4.
      Rect gameArea)
    {
      Camera.main.orthographicSize = 
        Mathf.Max (gameArea.width, gameArea.height) / 2;

      ObjectFactory.CreateBoundary (gameArea);

      GameObject player = ObjectFactory.CreatePlayer (playerLevel);
      player.transform.position = 
        new Vector2 (gameArea.center.x, gameArea.yMin + 2);

      int numberOfEnemies = difficulty * 5;
      for (var i = 0; i < numberOfEnemies; i++) {
        GameObject enemy = 
          ObjectFactory.CreateEnemy (
            ObjectFactory.GetRandomEnemyType (), difficulty);
        enemy.transform.position = 
          new Vector2 (
          Random.Range (gameArea.xMin + 2, gameArea.xMax - 2), 
          Random.Range (gameArea.center.y, gameArea.yMax - 2));
      }
    }
  }
}
