using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SSGameOver : MonoBehaviour {
	[SerializeField]
	private Text scoreText;

	private int score;

	private const string SCORE_FORMAT = "Score: {0:000000}";

	public void OnEnable() {
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_GAME_OVER, OnGameOver);
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_FINAL_SCORE_CHANGED, OnFinalScoreChanged);
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_GOTOMENU_CLICKED, OnGoToMenuClicked);
	}

	public void OnDisable() {
		EventBroadcaster.sharedInstance.RemoveObserverAction(SSNames.ON_GAME_OVER, OnGameOver);
		EventBroadcaster.sharedInstance.RemoveObserverAction(SSNames.ON_FINAL_SCORE_CHANGED, OnFinalScoreChanged);
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_GOTOMENU_CLICKED, OnGoToMenuClicked);
	}

	public void OnGameOver() {
		Utils.EnableAllChildren(transform);
	}

	public void OnFinalScoreChanged(Parameters param) {
		score = param.GetExtra(SSNames.FINAL_SCORE, 0);
		SetScoreDirty();
	}

	public void OnGoToMenuClicked() {
		Utils.DisableAllChildren(transform);
	}

	public void GoToMenuClicked() {
		EventBroadcaster.sharedInstance.NotifyObserver(SSNames.ON_GOTOMENU_CLICKED);
	}

	public void SetScoreDirty() {
		scoreText.text = string.Format(SCORE_FORMAT, score);
	}
}
