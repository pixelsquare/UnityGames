using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("AstarisAdventure")]
public class AdvRoot {
	[XmlArray("Nodes"), XmlArrayItem("Node")]
	public AdvNode[] nodes;

	public void Save(string path) {
		XmlSerializer serializer = new XmlSerializer(typeof(AdvRoot));
		using (FileStream stream = new FileStream(path, FileMode.Create)) {
			serializer.Serialize(stream, this);
		}
	}

	public static AdvRoot Load(string path) {
		XmlSerializer serializer = new XmlSerializer(typeof(AdvRoot));
		using (FileStream stream = new FileStream(path, FileMode.Open)) {
			return serializer.Deserialize(stream) as AdvRoot;
		}
	}
}
