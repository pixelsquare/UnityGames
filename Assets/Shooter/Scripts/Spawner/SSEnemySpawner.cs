using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SSEnemySpawner : MonoBehaviour {
	[SerializeField]
	private float interval = 1.0f;

	private List<SSObjectID> enemyIds;
	private Vector3 screenBounds;

	public void Awake() {
		Vector3 screenSize = new Vector3(Screen.width, Screen.height);
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(screenSize.x, screenSize.y));
	}

	public void OnEnable() {
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_TITLE_CLICKED, InitSpawner);
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_GAME_OVER, OnGameOver);
	}

	public void OnDisable() {
		EventBroadcaster.sharedInstance.RemoveObserverAction(SSNames.ON_TITLE_CLICKED, InitSpawner);
		EventBroadcaster.sharedInstance.RemoveObserverAction(SSNames.ON_GAME_OVER, OnGameOver);
	}

	public void InitSpawner() {
		enemyIds = new List<SSObjectID>();
		enemyIds.Add(SSObjectID.ENEMY_SHIP_1);
		enemyIds.Add(SSObjectID.ENEMY_SHIP_2);
		enemyIds.Add(SSObjectID.ENEMY_SHIP_3);
		enemyIds.Add(SSObjectID.ENEMY_SHIP_4);
		enemyIds.Add(SSObjectID.ENEMY_SHIP_5);
		enemyIds.Add(SSObjectID.ENEMY_SHIP_6);
		enemyIds.Add(SSObjectID.ENEMY_SHIP_7);
		enemyIds.Add(SSObjectID.ENEMY_SHIP_8);

		InvokeRepeating("SpawnEnemy", 1.0f, interval);
	}

	public void OnGameOver() {
		CancelInvoke();
	}

	public void SpawnEnemy() {
		int indx = GetEnemyIndx();
		GameObject enemy = SSObjectPool.sharedInstance.GetObject(enemyIds[indx]);
		if (enemy != null) {
			Vector3 spawnPos = transform.position;
			spawnPos.x = GetRandomXPos(enemy.GetComponent<SSEnemyControl>().EnemySprite);
			enemy.transform.position = spawnPos;
			enemy.SetActive(true);
		}
	}

	public int GetEnemyIndx() {
		System.Random rand = new System.Random();
		return rand.Next(0, enemyIds.Count);
	}

	public float GetRandomXPos(SpriteRenderer spr) {
		Vector3 spriteBounds = spr.sprite.bounds.size;
		Vector3 spriteSize = Camera.main.WorldToViewportPoint(spriteBounds);
		Vector3 screenBound = screenBounds;
		screenBound -= spriteSize;
		return Random.Range(-screenBound.x, screenBound.x);
	}
}
