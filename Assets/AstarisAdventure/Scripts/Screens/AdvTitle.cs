using UnityEngine;
using System.Collections;

public class AdvTitle : MonoBehaviour {

	private bool disableMouseClick;

	public void OnEnable() {
		EventBroadcaster.sharedInstance.AddObserver(AdvNames.ON_TITLE_CLICK, OnTitleClick);
		EventBroadcaster.sharedInstance.AddObserver(AdvNames.ON_GOTOMENU_CLICK, OnGoToMenuClick);
	}

	public void OnDisable() {
		EventBroadcaster.sharedInstance.RemoveObserver(AdvNames.ON_TITLE_CLICK);
		EventBroadcaster.sharedInstance.RemoveObserver(AdvNames.ON_GOTOMENU_CLICK);
	}

	public void Update() {
		if (Input.GetMouseButtonDown(0) && !disableMouseClick) {
			EventBroadcaster.sharedInstance.CallObserver(AdvNames.ON_TITLE_CLICK);
		}
	}

	public void OnTitleClick() {
		AdvUtils.DisableAllChildren(transform);
		disableMouseClick = true;
	}

	public void OnGoToMenuClick() {
		AdvUtils.EnableAllChildren(transform);
		disableMouseClick = false;
	}
}
