using UnityEngine;
using System.Collections;

public class AdvTitle : MonoBehaviour {

	private bool disableMouseClick;

	public void OnEnable() {
		EventBroadcaster.sharedInstance.AddObserver(AdvNames.ON_TITLE_CLICKED, OnTitleClick);
		EventBroadcaster.sharedInstance.AddObserver(AdvNames.ON_GOTOMENU_CLICKED, OnGoToMenuClick);
	}

	public void OnDisable() {
		EventBroadcaster.sharedInstance.RemoveObserver(AdvNames.ON_TITLE_CLICKED);
		EventBroadcaster.sharedInstance.RemoveObserver(AdvNames.ON_GOTOMENU_CLICKED);
	}

	public void Update() {
		if (Input.GetMouseButtonDown(0) && !disableMouseClick) {
			EventBroadcaster.sharedInstance.NotifyObserver(AdvNames.ON_TITLE_CLICKED);
		}
	}

	public void OnTitleClick() {
		Utils.DisableAllChildren(transform);
		disableMouseClick = true;
	}

	public void OnGoToMenuClick() {
		Utils.EnableAllChildren(transform);
		disableMouseClick = false;
	}
}
