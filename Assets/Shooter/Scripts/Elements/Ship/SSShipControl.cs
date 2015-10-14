using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class SSShipControl : MonoBehaviour {
	[SerializeField]
	private SpriteRenderer shipSprite;

	[SerializeField]
	private SSBarrel shipBarrel;

	[SerializeField]
	private bool freezeX;

	[SerializeField]
	private bool freezeY = true;

	private SSShip ship;
	private int shipLives;
	private bool shipCanMove;

	private Vector3 screenBounds;

	public void Awake() {
		ship = GetComponent<SSShip>();
		Vector3 screenSize = new Vector3(Screen.width, Screen.height);
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(screenSize.x, screenSize.y));
	}

	public void OnEnable() {
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_TITLE_CLICKED, OnTitleClicked);
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_GAME_OVER, OnGameOver);
	}

	public void OnDisable() {
		EventBroadcaster.sharedInstance.RemoveObserverAction(SSNames.ON_TITLE_CLICKED, OnTitleClicked);
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_GAME_OVER, OnGameOver);
	}

	public void Start() {
		Vector3 spriteBounds = shipSprite.sprite.bounds.size;
		Vector3 spriteSize = Camera.main.WorldToViewportPoint(spriteBounds);
		screenBounds -= spriteSize;
	}

	public void Update() {
		if (!shipCanMove)
			return;

		ShipMovement();

		if (Input.GetMouseButtonDown(0)) {
			FireMissile();
		}
	}

	public void ShipMovement() {
		Vector3 pos = transform.position;
		if (!freezeX) {
			pos.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
			pos.x = Mathf.Clamp(pos.x, -screenBounds.x, screenBounds.x);
		}

		if (!freezeY) {
			pos.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
			pos.y = Mathf.Clamp(pos.y, -screenBounds.y, screenBounds.y);
		}
		transform.position = pos;
	}

	public void FireMissile() {
		for (int i = 0; i < shipBarrel.Barrels.Length; i++) {
			GameObject missile = SSObjectPool.sharedInstance.GetObject(SSObjectID.SHIP_MISSILE);
			if (missile != null) {
				missile.transform.position = shipBarrel.Barrels[i].position;
				missile.SetActive(true);
			}
		}
	}

	public void OnTitleClicked() {
		shipLives = ship.ShipLives;
		shipCanMove = true;
		Utils.EnableAllChildren(transform);
	}

	public void OnGameOver() {
		shipCanMove = false;
		Utils.DisableAllChildren(transform);
	}

	public void OnTriggerEnter2D(Collider2D col) {
		SSGameElement gameElement = col.GetComponent<SSGameElement>();
		if (gameElement != null) {
			if (gameElement.GetObjectTypeID() == SSObjectType.GAME_ENEMY) {
				shipLives--;
				EventBroadcaster.sharedInstance.NotifyObserver(SSNames.ON_LIVES_CHANGED);
				if (shipLives <= 0) {
					ship.DestroyElement();
				}
			}
		}
	}
}