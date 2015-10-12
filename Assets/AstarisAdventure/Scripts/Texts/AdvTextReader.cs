using UnityEngine;
using System.Collections;
using System.Linq;

public class AdvTextReader : MonoBehaviour {

	private AdvRoot xmlRoot;
	private AdvNode curNode;

	private int curNodeIndx;
	private int curTextIndx;
	
	public const string XML_NAME = "astarisAdventure";
	public const string XML_EXT = ".xml";

	public void OnEnable() {
		curNodeIndx = 0;
		curTextIndx = 0;

		InitXMLRoot();
	}
	
	public void InitXMLRoot() {
		System.Text.StringBuilder pathString = new System.Text.StringBuilder();
		pathString.Append(XML_NAME);
		pathString.Append(XML_EXT);

		TextAsset xml = (TextAsset)Resources.Load(XML_NAME);
		xmlRoot = AdvRoot.ParseXML(xml.text);
		curNode = xmlRoot.nodes[curNodeIndx];
		curNode.nodes.AddRange(xmlRoot.nodes);

		// Locally load xml file
		//xmlRoot = AdvRoot.Load(System.IO.Path.Combine(Application.streamingAssetsPath, pathString.ToString()));
	}

	public void LoadNodeParent(string id) {
		if (GetNodeIndx(id) != -1) {
			curNode = curNode.nodes[GetNodeIndx(id)];
			curNodeIndx = 0;
		}

		curTextIndx = 0;

		//Debug.Log(curNode.name);
		//foreach (AdvNode node in curNode.nodes) {
		//    Debug.Log(node.name + " " + node.nodes.Count + " " + node.texts.Length);
		//}
	}

	public int GetNodeIndx(string id) {
		if (curNode.nodes.Count <= 0)
			return -1;

		for (int i = 0; i < curNode.nodes.Count; i++) {
			string nodeId = curNode.nodes[i].name;
			if (nodeId == id) {
				return i;
			}
		}

		return -1;
	}

	public string GetCurText() {
		return curNode.texts[curTextIndx];
	}

	public AdvChoices[] GetChoices() {
		return curNode.choices;
	}

	public bool OnFirstTextNode() {
		return curTextIndx == 0;
	}

	public bool OnLastTextNode() {
		return curTextIndx == curNode.texts.Length - 1;
	}

	public void InitNextText() {
		int tmpIndx = curTextIndx;
		tmpIndx++;

		if (tmpIndx >= curNode.texts.Length)
			return;

		curTextIndx = tmpIndx;
	}

	public void InitPrevText() {
		int tmpIndx = curTextIndx;
		tmpIndx--;

		if (tmpIndx < 0)
			return;

		curTextIndx = tmpIndx;
	}
}