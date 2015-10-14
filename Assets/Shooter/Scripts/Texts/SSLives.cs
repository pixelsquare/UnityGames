using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SSLives : MonoBehaviour {

	private int lives;
	private Text livesText;

	private const string LIVES_FORMAT = "Lives: {0}";

	public void OnEnable() {
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_TITLE_CLICKED, OnTitleClicked);
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_LIVES_CHANGED, OnLivesChanged);
	}

	public void OnDisable() {
		EventBroadcaster.sharedInstance.RemoveObserverAction(SSNames.ON_TITLE_CLICKED, OnTitleClicked);
		EventBroadcaster.sharedInstance.RemoveObserverAction(SSNames.ON_LIVES_CHANGED, OnLivesChanged);
	}

	public void OnTitleClicked() {
		lives = SSGameSettings.PLAYER_LIVES;
		livesText = GetComponent<Text>();
		SetLivesDirty();
	}

	public void OnLivesChanged() {
		lives -= 1;
		SetLivesDirty();
	}

	public void SetLivesDirty() {
		livesText.text = string.Format(LIVES_FORMAT, lives);
	}
}
