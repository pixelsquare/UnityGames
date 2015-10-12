using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class AdvTextWriter : MonoBehaviour {
	[SerializeField]
	private Text windowText;

	[SerializeField]
	private float writerSpeed = 15f;

	private string curText;
	private StringBuilder textSb;

	private int curTextIndx;
	private int textLen;

	public bool isDone {
		get { return curTextIndx == textLen; }
	}

	private const float TYPEWRITE_DELAY = 0.1f;

	public void OnEnable() {
		EventBroadcaster.sharedInstance.AddObserver(AdvNames.ON_GOTOMENU_CLICK, OnGoToMenu);
	}

	public void OnDisable() {
		EventBroadcaster.sharedInstance.RemoveObserver(AdvNames.ON_GOTOMENU_CLICK);
	}

	public void Start() {
		curTextIndx = 0;
		textLen = 0;
	}

	public void OnGoToMenu() {
		curTextIndx = 0;
		textLen = 0;
		windowText.text = string.Empty;
	}

	public void Write(string text) {
		curText = text;
		textSb = new StringBuilder();
		curTextIndx = 0;
		textLen = text.Length;

		InvokeRepeating("Typewrite", TYPEWRITE_DELAY, 1 / writerSpeed);
	}

	public void Typewrite() {
		int tmpIndx = curTextIndx;
		tmpIndx++;

		if(tmpIndx > textLen) {
			CancelInvoke("Typewrite");
			return;
		}

		textSb.Append(curText[curTextIndx]);
		SetWindowTextDirty();

		curTextIndx = tmpIndx;
	}

	public void SetWriterSpeed(float speed) {
		writerSpeed = speed;
	}

	public void SetWindowTextDirty() {
		windowText.text = textSb.ToString();
	}

	public void ForceStop() {
		CancelInvoke();
	}
}