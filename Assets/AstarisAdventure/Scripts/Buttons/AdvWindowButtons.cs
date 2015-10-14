using UnityEngine;
using System.Collections;

public class AdvWindowButtons : MonoBehaviour {

	[SerializeField]
	private GameObject backBtn;

	[SerializeField]
	private GameObject nextBtn;

	public void OnEnable() {
		EventBroadcaster.sharedInstance.AddObserver(AdvNames.ON_WINDOW_BTN_CLICKED, UpdateWindowButtons);
		EventBroadcaster.sharedInstance.AddObserver(AdvNames.ON_POST_WINDOW_BTN_CLICKED, PostUpdateWindowButtons);
	}

	public void OnDisable() {
		EventBroadcaster.sharedInstance.RemoveObserverAction(AdvNames.ON_WINDOW_BTN_CLICKED, UpdateWindowButtons);
		EventBroadcaster.sharedInstance.RemoveObserverAction(AdvNames.ON_POST_WINDOW_BTN_CLICKED, PostUpdateWindowButtons);
	}

	public void OnNextButtonClick() {
		EventBroadcaster.sharedInstance.NotifyObserver(AdvNames.ON_NEXTBTN_CLICKED);
	}

	public void OnBackButtonClick() {
		EventBroadcaster.sharedInstance.NotifyObserver(AdvNames.ON_BACKBTN_CLICKED);
	}

	public void UpdateWindowButtons(Parameters param) {
		nextBtn.SetActive(!param.GetExtra(AdvNames.ON_LAST_NODE, false));
		backBtn.SetActive(!param.GetExtra(AdvNames.ON_FIRST_NODE, false));
	}

	public void PostUpdateWindowButtons(Parameters param) {
		if (param.GetExtra(AdvNames.ON_LAST_NODE, false)) {
			Utils.DisableAllChildren(transform);
		}
	}
}