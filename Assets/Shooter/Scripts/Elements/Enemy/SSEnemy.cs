using UnityEngine;
using System.Collections;

public class SSEnemy : SSGameElement {
	[SerializeField]
	private int enemyLives = 1;
	public int EnemyLives {
		get { return enemyLives; }
	}

	public override void DestroyElement() {
		GameObject explosion = SSObjectPool.sharedInstance.GetObject(SSObjectID.EXPLOSION_ENEMY);
		if (explosion != null) {
			explosion.transform.position = transform.position;
			explosion.SetActive(true);
		}

		base.DestroyElement();
	}

	public override SSObjectType GetObjectTypeID() {
		return SSObjectType.GAME_ENEMY;
	}
}
