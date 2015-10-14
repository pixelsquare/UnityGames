using UnityEngine;
using System.Collections;

public class SSMissile : SSGameElement {
	[SerializeField]
	private int missileDurability = 1;
	public int MissileDurability {
		get { return missileDurability; }
	}

	public override void DestroyElement() {
		GameObject explosion = SSObjectPool.sharedInstance.GetObject(SSObjectID.EXPLOSION_MISSILE);
		if (explosion != null) {
			explosion.transform.position = transform.position;
			explosion.SetActive(true);
		}

		Parameters param = new Parameters();
		param.PutExtra(SSNames.ADDITIONAL_SCORE, SSGameSettings.SCORE_POINTS);
		EventBroadcaster.sharedInstance.NotifyObserver(SSNames.ON_SCORE_CHANGED, param);

		base.DestroyElement();
	}

	public override SSObjectType GetObjectTypeID() {
		return SSObjectType.SHIP_MISSILE;
	}
}
