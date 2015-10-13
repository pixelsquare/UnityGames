using UnityEngine;
using System.Collections;

public class SSBarrel : MonoBehaviour {
	[SerializeField]
	private Transform[] barrels;
	public Transform[] Barrels {
		get { return barrels; }
	}
}
