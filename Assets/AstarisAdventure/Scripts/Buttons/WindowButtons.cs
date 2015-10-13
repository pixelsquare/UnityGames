using UnityEngine;
using System.Collections;

public class WindowButtons : MonoBehaviour {

	[SerializeField]
	private GameObject backBtn;

	[SerializeField]
	private GameObject nextBtn;

	public void OnEnable() {
		EventBroadcaster.sharedInstance.AddObserver(AdvNames.ON_WINDOW_BTN_CLICK, UpdateWindowButtons);
		EventBroadcaster.sharedInstance.AddObserver(AdvNames.ON_POST_WINDOW_BTN_CLICK, PostUpdateWindowButtons);
	}

	public void OnDisable() {
		EventBroadcaster.sharedInstance.RemoveObserverAction(AdvNames.ON_WINDOW_BTN_CLICK, UpdateWindowButtons);
		EventBroadcaster.sharedInstance.RemoveObserverAction(AdvNames.ON_POST_WINDOW_BTN_CLICK, PostUpdateWindowButtons);
	}

	//public void Start() {
	//    AdvUtils.EnableAllChildren(transform);
	//}

	public void OnNextButtonClick() {
		EventBroadcaster.sharedInstance.NotifyObserver(AdvNames.ON_NEXTBTN_CLICK);
	}

	public void OnBackButtonClick() {
		EventBroadcaster.sharedInstance.NotifyObserver(AdvNames.ON_BACKBTN_CLICK);
	}

	public void UpdateWindowButtons(Parameters param) {
		nextBtn.SetActive(!param.GetExtra(AdvNames.ON_LAST_NODE, false));
		backBtn.SetActive(!param.GetExtra(AdvNames.ON_FIRST_NODE, false));
	}

	public void PostUpdateWindowButtons(Parameters param) {
		if (param.GetExtra(AdvNames.ON_LAST_NODE, false)) {
			AdvUtils.DisableAllChildren(transform);
		}
	}
}