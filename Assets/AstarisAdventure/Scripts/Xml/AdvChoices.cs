using System.Collections.Generic;
using System.Xml.Serialization;

public class AdvChoices {
	[XmlAttribute("Name")]
	public string name;

	[XmlElement("Text")]
	public string text;

	public AdvChoices() { }

	public AdvChoices(string name, string text) {
		this.name = name;
		this.text = text;
	}
}
