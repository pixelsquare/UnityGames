using UnityEngine;
using System.Collections;

public class AdvMain : MonoBehaviour {

	public void OnEnable() {
		EventBroadcaster.sharedInstance.AddObserver(AdvNames.ON_TITLE_CLICKED, OnTitleClick);
		EventBroadcaster.sharedInstance.AddObserver(AdvNames.ON_GOTOMENU_CLICKED, OnGoToMenuClick);
	}

	public void OnDisable() {
		EventBroadcaster.sharedInstance.RemoveObserver(AdvNames.ON_TITLE_CLICKED);
		EventBroadcaster.sharedInstance.RemoveObserver(AdvNames.ON_GOTOMENU_CLICKED);
	}

	public void OnTitleClick() {
		Utils.EnableAllChildren(transform);
	}

	public void OnGoToMenuClick() {
		Utils.DisableAllChildren(transform);
	}
}
