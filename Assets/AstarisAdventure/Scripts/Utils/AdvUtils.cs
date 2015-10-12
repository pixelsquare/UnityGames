using UnityEngine;
using System.Collections;

public class AdvUtils {

	public static void EnableAllChildren(Transform root) {
		foreach (Transform child in root) {
			child.gameObject.SetActive(true);
		}
	}

	public static void DisableAllChildren(Transform root) {
		foreach (Transform child in root) {
			child.gameObject.SetActive(false);
		}
	}
}
