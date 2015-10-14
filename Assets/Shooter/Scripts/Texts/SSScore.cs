using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SSScore : MonoBehaviour {

	private int score;
	private Text scoreText;

	private const string SCORE_FORMAT = "Score: {0:000000}";

	public void OnEnable() {
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_TITLE_CLICKED, OnTitleClicked);
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_SCORE_CHANGED, OnScoreChanged);
		EventBroadcaster.sharedInstance.AddObserver(SSNames.ON_GAME_OVER, OnGameOver, true);
	}

	public void OnDisable() {
		EventBroadcaster.sharedInstance.RemoveObserverAction(SSNames.ON_TITLE_CLICKED, OnTitleClicked);
		EventBroadcaster.sharedInstance.RemoveObserverAction(SSNames.ON_SCORE_CHANGED, OnScoreChanged);
		EventBroadcaster.sharedInstance.RemoveObserverAction(SSNames.ON_GAME_OVER, OnGameOver);
	}

	public void OnTitleClicked() {
		score = 0;
		scoreText = GetComponent<Text>();
		SetScoreDirty();
	}

	public void OnScoreChanged(Parameters param) {
		score += param.GetExtra(SSNames.ADDITIONAL_SCORE, 0);
		SetScoreDirty();
	}

	public void SetScoreDirty() {
		scoreText.text = string.Format(SCORE_FORMAT, score);
	}

	public void OnGameOver() {
		Parameters param = new Parameters();
		param.PutExtra(SSNames.FINAL_SCORE, score);
		EventBroadcaster.sharedInstance.NotifyObserver(SSNames.ON_FINAL_SCORE_CHANGED, param);
	}
}
