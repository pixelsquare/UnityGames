using UnityEngine;
using System.Collections;

public class SSObjectPool : MonoBehaviour {

	private static SSObjectPool instance;
	public static SSObjectPool sharedInstance {
		get {
			if (instance == null)
				instance = new SSObjectPool();

			return instance;
		}
	}
}
