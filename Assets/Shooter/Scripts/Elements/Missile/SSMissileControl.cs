using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class SSMissileControl : MonoBehaviour {
	[SerializeField]
	private float missileForce = 150.0f;

	private SSMissile missile;
	private int missileDurability;

	private Rigidbody2D rb;
	private Vector3 screenBounds;

	public void Awake() {
		missile = GetComponent<SSMissile>();
		Vector3 screenSize = new Vector3(Screen.width, Screen.height);
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(screenSize.x, screenSize.y));
	}

	public void OnEnable() {
		missileDurability = missile.MissileDurability;
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.AddForce(Vector2.up * missileForce, ForceMode2D.Force);
	}

	public void Update() {
		if (transform.position.y > screenBounds.y) {
			gameObject.SetActive(false);
		}
	}

	public void OnTriggerEnter2D(Collider2D col) {
		SSGameElement gameElement = col.GetComponent<SSGameElement>();
		if (gameElement != null) {
			if (gameElement.GetObjectTypeID() == SSObjectType.GAME_ENEMY) {
				missileDurability--;
				if (missileDurability <= 0) {
					missile.DestroyElement();
				}
			}
		}
	}
}
