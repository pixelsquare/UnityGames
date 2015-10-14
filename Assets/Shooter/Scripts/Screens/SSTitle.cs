using UnityEngine;
using System.Collections;

public class SSTitle : MonoBehaviour {

	private bool disableMouseClick;

	public void OnEnable() {
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_TITLE_CLICKED, OnTitleClicked);
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_GOTOMENU_CLICKED, OnGoToMenuClicked);
	}

	public void OnDisable() {
		EventBroadcaster.sharedInstance.RemoveObserverAction(SSNames.ON_TITLE_CLICKED, OnTitleClicked);
		EventBroadcaster.sharedInstance.RemoveObserverAction(SSNames.ON_GOTOMENU_CLICKED, OnGoToMenuClicked);
	}

	public void Update() {
		if (Input.GetMouseButtonDown(0) && !disableMouseClick) {
			EventBroadcaster.sharedInstance.NotifyObserver(SSNames.ON_TITLE_CLICKED);
		}
	}

	public void OnTitleClicked() {
		Utils.DisableAllChildren(transform);
		disableMouseClick = true;
	}

	public void OnGoToMenuClicked() {
		Utils.EnableAllChildren(transform);
		disableMouseClick = false;
	}
}
