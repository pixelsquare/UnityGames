using UnityEngine;
using System.Collections;

public class AdvMain : MonoBehaviour {

	public void OnEnable() {
		EventBroadcaster.sharedInstance.AddObserver(AdvNames.ON_TITLE_CLICK, OnTitleClick);
		EventBroadcaster.sharedInstance.AddObserver(AdvNames.ON_GOTOMENU_CLICK, OnGoToMenuClick);
	}

	public void OnDisable() {
		EventBroadcaster.sharedInstance.RemoveObserver(AdvNames.ON_TITLE_CLICK);
		EventBroadcaster.sharedInstance.RemoveObserver(AdvNames.ON_GOTOMENU_CLICK);
	}

	public void OnTitleClick() {
		AdvUtils.EnableAllChildren(transform);
	}

	public void OnGoToMenuClick() {
		AdvUtils.DisableAllChildren(transform);
	}
}
