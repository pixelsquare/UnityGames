using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdvTextHandler : MonoBehaviour {
	[SerializeField]
	private AdvTextReader advReader;

	[SerializeField]
	private AdvTextWriter advWriter;

	public void OnEnable() {
		EventBroadcaster.sharedInstance.AddObserver(AdvNames.ON_NEXTBTN_CLICKED, PrintNextText);
		EventBroadcaster.sharedInstance.AddObserver(AdvNames.ON_BACKBTN_CLICKED, PrintPreviousText);
		EventBroadcaster.sharedInstance.AddObserver(AdvNames.ON_CHOICE_BTN_CLICKED, UpdateXMLText);
		EventBroadcaster.sharedInstance.AddObserver(AdvNames.ON_TITLE_CLICKED, OnTitleClick);
	}

	public void OnDisable() {
		EventBroadcaster.sharedInstance.RemoveObserverAction(AdvNames.ON_NEXTBTN_CLICKED, PrintNextText);
		EventBroadcaster.sharedInstance.RemoveObserverAction(AdvNames.ON_BACKBTN_CLICKED, PrintPreviousText);
		EventBroadcaster.sharedInstance.RemoveObserverAction(AdvNames.ON_CHOICE_BTN_CLICKED, UpdateXMLText);
		EventBroadcaster.sharedInstance.RemoveObserver(AdvNames.ON_TITLE_CLICKED);
	}

	public void OnTitleClick() {
		advReader.InitXMLRoot();
		advWriter.Write(advReader.GetCurText());
		UpdateWindowButtons();
	}

	public void PrintNextText() {
		if (advReader.OnLastTextNode())
			return;

		advReader.InitNextText();
		advWriter.ForceStop();
		advWriter.Write(advReader.GetCurText());
		UpdateWindowButtons();
	}

	public void PrintPreviousText() {
		if (advReader.OnFirstTextNode())
			return;

		advReader.InitPrevText();
		advWriter.ForceStop();
		advWriter.Write(advReader.GetCurText());
		UpdateWindowButtons();
	}

	public void UpdateXMLText(Parameters param) {
		string nodeId = param.GetExtra(AdvNames.CHOICE_BTN_ID, "empty!");
		if (nodeId == "end") {
			EventBroadcaster.sharedInstance.NotifyObserver(AdvNames.ON_GOTOMENU_CLICKED);
			return;
		}
		
		advReader.LoadNodeParent(nodeId);
		advWriter.Write(advReader.GetCurText());
		UpdateWindowButtons();
	}

	public void UpdateWindowButtons() {
		Parameters btnUpdate = new Parameters();
		btnUpdate.PutExtra(AdvNames.ON_FIRST_NODE, advReader.OnFirstTextNode());
		btnUpdate.PutExtra(AdvNames.ON_LAST_NODE, advReader.OnLastTextNode());
		EventBroadcaster.sharedInstance.NotifyObserver(AdvNames.ON_WINDOW_BTN_CLICKED, btnUpdate);

		if (advReader.OnLastTextNode()) {
			StartCoroutine(PostButtonUpdate());
		}
	}

	public IEnumerator PostButtonUpdate() {
		while (!advWriter.isDone) {
			yield return null;
		}

		Parameters btnUpdate = new Parameters();
		btnUpdate.PutExtra(AdvNames.ON_FIRST_NODE, advReader.OnFirstTextNode());
		btnUpdate.PutExtra(AdvNames.ON_LAST_NODE, advReader.OnLastTextNode());

		ArrayList choices = new ArrayList(advReader.GetChoices());
		btnUpdate.PutExtra(AdvNames.WINDOW_CHOICES, choices);

		EventBroadcaster.sharedInstance.NotifyObserver(AdvNames.ON_POST_WINDOW_BTN_CLICKED, btnUpdate);
	}
}