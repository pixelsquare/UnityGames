using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class SSMissileControl : MonoBehaviour {
	[SerializeField]
	private float missileForce = 150.0f;

	private Rigidbody2D rb;
	private Vector3 screenBounds;

	public void Awake() {
		Vector3 screenSize = new Vector3(Screen.width, Screen.height);
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(screenSize.x, screenSize.y));
	}

	public void OnEnable() {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.AddForce(Vector2.up * missileForce, ForceMode2D.Force);
	}

	public void Update() {
		if (transform.position.y > screenBounds.y) {
			gameObject.SetActive(false);
		}
	}
}
