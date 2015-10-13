using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class SSPlaneControl : MonoBehaviour {
	[SerializeField]
	private SpriteRenderer shipSprite;

	[SerializeField]
	private SSBarrel shipBarrel;

	[SerializeField]
	private bool freezeX;

	[SerializeField]
	private bool freezeY = true;

	private Vector3 screenBounds;

	public void Start() {
		Vector3 screenSize = new Vector3(Screen.width, Screen.height);
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(screenSize.x, screenSize.y));

		Vector3 spriteBounds = shipSprite.sprite.bounds.size;
		Vector3 spriteSize = Camera.main.WorldToViewportPoint(spriteBounds);
		screenBounds -= spriteSize;
	}

	public void Shoot() {

	}

	public void Update() {
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
}