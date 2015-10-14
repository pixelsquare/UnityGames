using UnityEngine;
using System.Collections;

public class SSMain : MonoBehaviour {

	public void OnEnable() {
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_TITLE_CLICKED, OnTitleClicked);
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_GOTOMENU_CLICKED, OnGoToMenuClicked);
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_GAME_OVER, OnGameOver);
	}

	public void OnDisable() {
		EventBroadcaster.sharedInstance.RemoveObserverAction(SSNames.ON_TITLE_CLICKED, OnTitleClicked);
		EventBroadcaster.sharedInstance.RemoveObserverAction(SSNames.ON_GOTOMENU_CLICKED, OnGoToMenuClicked);
		EventBroadcaster.sharedInstance.RemoveObserverAction(SSNames.ON_GAME_OVER, OnGameOver);
	}

	public void OnTitleClicked() {
		Utils.EnableAllChildren(transform);
	}

	public void OnGoToMenuClicked() {
		Utils.DisableAllChildren(transform);
	}

	public void OnGameOver() {
		//Utils.DisableAllChildren(transform);
	}
}
