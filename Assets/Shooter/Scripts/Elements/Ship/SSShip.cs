using UnityEngine;
using System.Collections;

public class SSShip : SSGameElement {
	[SerializeField]
	private int shipLives = 3;
	public int ShipLives {
		get { return shipLives; }
	}

	public override void DestroyElement() {
		GameObject explosion = SSObjectPool.sharedInstance.GetObject(SSObjectID.EXPLOSION_SHIP);
		if (explosion != null) {
			explosion.transform.position = transform.position;
			explosion.SetActive(true);
		}

		EventBroadcaster.sharedInstance.NotifyObserver(SSNames.ON_GAME_OVER);
		Utils.DisableAllChildren(transform);
		//base.DestroyElement();
	}

	public override SSObjectType GetObjectTypeID() {
		return SSObjectType.GAME_SHIP;
	}
}
