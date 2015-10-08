using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;

public class AdvNode {
	[XmlAttribute("Name")]
	public string name;

	[XmlArray("Texts"), XmlArrayItem("Text")]
	public string[] texts;

	[XmlArray("Choices"), XmlArrayItem("Choice")]
	public AdvChoices[] choices;

	[XmlArray("Nodes"), XmlArrayItem("Node")]
	public List<AdvNode> nodes = new List<AdvNode>();

	public AdvNode() { }

	public AdvNode(string name, string[] texts) {
		this.name = name;
		this.texts = texts;
	}

	public AdvNode(string name, string[] texts, AdvChoices choice) {
		this.name = name;
		this.texts = texts;

		this.choices = new AdvChoices[1];
		this.choices[0] = choice;
	}

	public AdvNode(string name, string[] texts, AdvChoices[] choices) {
		this.name = name;
		this.texts = texts;
		this.choices = choices;
	}

	public void AddNode(AdvNode node) {
		this.nodes.Add(node);
	}
}
