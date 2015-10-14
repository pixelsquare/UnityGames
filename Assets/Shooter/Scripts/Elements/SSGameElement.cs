using UnityEngine;
using System.Collections;

public class SSGameElement: MonoBehaviour {

	public virtual void DestroyElement() {
		gameObject.SetActive(false);
	}

	public virtual SSObjectType GetObjectTypeID() {
		return SSObjectType.NONE;
	}
}
