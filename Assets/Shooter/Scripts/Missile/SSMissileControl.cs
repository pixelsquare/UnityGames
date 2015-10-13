using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class SSMissileControl : MonoBehaviour {
	[SerializeField]
	private float missileForce = 150.0f;

	public void Start() {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.AddForce(Vector2.up * missileForce, ForceMode2D.Force);
	}
}
