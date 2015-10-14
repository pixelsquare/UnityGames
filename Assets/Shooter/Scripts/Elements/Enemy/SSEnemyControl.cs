using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class SSEnemyControl : MonoBehaviour {
	[SerializeField]
	private SpriteRenderer enemySprite;
	public SpriteRenderer EnemySprite {
		get { return enemySprite; }
	}

	[SerializeField]
	private float enemyForce = 100.0f;

	private SSEnemy enemy;
	private int enemyLives;

	private Rigidbody2D rb;
	private Vector3 screenBounds;

	public void Awake() {
		enemy = GetComponent<SSEnemy>();
		Vector3 screenSize = new Vector3(Screen.width, Screen.height);
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(screenSize.x, screenSize.y));
	}

	public void OnEnable() {
		enemyLives = enemy.EnemyLives;
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.AddForce(-Vector2.up * enemyForce, ForceMode2D.Force);
	}

	public void Update() {
		if (transform.position.y < -screenBounds.y) {
			gameObject.SetActive(false);
		}
	}

	public void OnTriggerEnter2D(Collider2D col) {
		SSGameElement gameElement = col.GetComponent<SSGameElement>();
		if (gameElement != null) {
			if (gameElement.GetObjectTypeID() == SSObjectType.SHIP_MISSILE || gameElement.GetObjectTypeID() == SSObjectType.GAME_SHIP) {
				enemyLives--;
				if (enemyLives <= 0) {
					enemy.DestroyElement();
				}
			}
		}
	}
}
