using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class AdvXML : MonoBehaviour {
	[SerializeField]
	private bool saveInResources = true;

	[SerializeField]
	private bool saveLocal = true;

	private AdvRoot root;

	private void Start() {
		root = new AdvRoot();
		root.nodes = new AdvNode[5];

		StartNode();
		Node1();
		Node2();
		Node3();
		EndNode();

		if (saveInResources) {
			root.Save(Path.Combine(Application.dataPath + "/Resources/", "astarisAdventure.xml"));
		}

		if (saveLocal) {
			root.Save(Path.Combine(Application.dataPath + "/AstarisAdventure/StreamingASsets/", "astarisAdventure.xml"));
		}
	}

	public void StartNode() {
		AdvNode startNode = new AdvNode("start", new string[7] { 
			"Waking up in the middle of the desert was never a good thing. Would you know anyone who would like to wake up in such a way? How about when you wake up without memories in the middle of the desert?", 
			"I know this sounds cliche but...",
			"That's what happened to me. The single clue I have on me of who I am is just this brooch with a word, 'Astaris'.",
			"Is that my name? I don't know, but, I'm sure I'll be using it.",
			"Dusting off, I looked upon the loooooong desert. It was only dunes upon dunes. It was neverending dunes.",
			"\"Hah, no one really is around.\"",
			"But, as I looked behind me, I managed to see something from a distance. It's a/an..."
		}, new AdvChoices[3] {
			new AdvChoices("oasis", "Oasis"),
			new AdvChoices("camel", "Person riding a camel"),
			new AdvChoices("caravan", "Long Caravan")
		});

		root.nodes[0] = startNode;
	}

	public void Node1() { 
		AdvNode oasis = new AdvNode("oasis", new string[3] {
			"It's an oasis.",
			"\"Is that really an oasis though?\" I scrutinized.",
			"Well, it was dry out here and I do need some water. I think I should..."
		}, new AdvChoices[2] {
			new AdvChoices("walk", "Walk to the oasis"),
			new AdvChoices("stay", "Stay here")
		});
		
		AdvNode node1 = new AdvNode("walk", new string[8] {
			"I think I should walk to the oasis. It makes sense to drink water from it right?",
			"\"I really don't want to be dehydrated.\"",
			"With quenching my thirst in mind, I walked towards the oasis. It was a long walk but, it was worth it because, it was a real oasis.",
			"Forming my hands, I scooped up some water to drink.",
			"\"Ah, that was refreshing!\"",
			"Only to realize that the color of the supposed water was different. I drank something that's not water.",
			"But, it was too late. The surroundings around me grew dim as I felt my heart coming slowly to a stop.",
			"Sigh, I guess I'll never found out who I am. I'm so lame."
		}, new AdvChoices("end", "END!"));
		oasis.AddNode(node1);

		AdvNode node2 = new AdvNode("stay", new string[5] {
			"I think I should stay here and keep on the look out for real stuff. I mean that might just be an illusion.",
			"When I reach that place, that oasis will probably disappear.",
			"Minutes turned to hours as I kept on the look out for other things, remaining on the same spot. And in a little while, dizziness caught up to me due to dehydration.",
			"Falling into a slump on the sandy ground, I passed out.",
			"Really, no one stays in one spot under this heat. I should've died with a little more effort of moving around the place."
		}, new AdvChoices("end", "END!"));
		oasis.AddNode(node2);

		root.nodes[1] = oasis;
	}

	public void Node2() {
		AdvNode camel = new AdvNode("camel", new string[14] {
			"It's a person riding a camel. Maybe he'll let me ride on that and take me on the nearest town?",
			"I should call out to him.",
			"\"Hey! Over here!\"",
			"Oh, that person's making the camel go faster. Well, as fast as a camel can move I guess.",
			"I should probably thank this person later... that is if he helps me. Maybe he knows something about Astaris?",
			"Gesturing his camel to stop, what I saw on the camel was a man in his robes that was a bit tattered though shining on his waist was a scimitar, oddly new and was that...that hild golden? I was not entirely sure.",
			"But, I'm amazed by his fast-changing facial expressions. When he arrived, his eyes were staring down at me like he was analyzing me then in the next moment, he grinned with glee. I wonder why.",	
			"Oh right, I should ask him where the nearest town is to get started.",
			"\"I want to ask for directions for the nearest town?\"",
			"\"Hm, you're lost there, little guy?\"",
			"Ugh, I might be short but, I ain't a little guy. I think I can totally say that I'm average. Wait, I should answer him. He might go away.",
			"\"Yeah, that's why I'm asking.\"",
			"\"Heh. I can let you ride on the camel and I'll take you there. How's that?\"",
			"\"I...",
		}, new AdvChoices[2] {
			new AdvChoices("directions", "only need to know the directions. I can manage.\""),
			new AdvChoices("ride", "guess I'll go for a ride. It makes things easier.\"")
		});

		AdvNode node1 = new AdvNode("directions", new string[3] {
			"\"I only need to know the directions. I can manage.\"",
			"With those words, the man on his camel left on a huff. He seemed to be angry at me as he left.",
			"Was that really necessary? I didn't know not riding on the camel was offensive in this place. Now, what do I do?"
		}, new AdvChoices[2] {
			new AdvChoices("stay", "Stay Here"),
			new AdvChoices("follow", "Follow the direction the man on the camel went to:")
		});

		AdvNode node1_1 = new AdvNode("stay", new string[4] {
			"I think I should stay here and keep on the look out.",
			"Minutes turned to hours as I kept on the look out for other things, remaining on the same spot. And in a little while, dizziness caught to me due to dehydration.",
			"Falling into a slump on the sandy ground, I passed out.",
			"Really, no one stays in one spot under this heat. I should've died with a little more effort of moving around the place."
		}, new AdvChoices("end", "END!"));
		node1.AddNode(node1_1);

		AdvNode node1_2 = new AdvNode("follow", new string[22] {
			"Well, it's a very long walk. Somehow, I was wishing I rode that camel.",
			"But, it was because that guy looked too suspicious to me. I wanted to be safe and sure.",
			"Ah, I could've stolen the camel and rode it myself.",
			"Just then, I felt a small buzz from the brooch, \"What was that?\"",
			"Shrugging, I ignored the sensation from the brooch and continued with my ranting thoughts as I quickly followed the hoofprints of the camel.",
			"I want that camel. Maybe, the next man on a camel I see... I could steal it?",
			"There it was again. A small buzz was felt from the brooch.",
			"Hmm, it looks like the brooch doesn't want me to do something bad.",
			"Hearing the sound of people talking, I looked up from staring at the hoof prints to see the place.",
			"It was a small town. I could tell, because, as soon as I arrived I was immediately on its marketplace.",
			"People were bustling around left and right. I wonder if I could get something to eat. The only problem is I don't have any money.",
			"I know, I know, brooch. I'm not stealing anything.",
			"I'm getting a job.",
			"Looking around, I saw a familiar man around town whipping some people with no clothes.",
			"Ooh, scary.",
			"Anyways, I'm gonna steer clear away from that guy. There should be a decent job here somewhere.",
			"Ah, there! It was a delivery wagon. Probably, a part of a caravan.",
			"Stated on the paper stuck on it was an advertised job position of a porter though for a measly sum. There was free food during travels.",
			"\"Okay, I'm in!\" I may look like this but, I have some body strength in me to carry a lot of heavy stuff. I hope.",
			"Talking to the leader of the caravan, I applied for the position. He had a look of doubt but, when I demonstrated my strength. It was enough for him.",
			"In the end, I journeyed with the caravan as I enjoyed my job. They became family.",
			"Long forgotten is my quest for my identity and Astaris."
		}, new AdvChoices("end", "end!"));
		node1.AddNode(node1_2);
		camel.AddNode(node1);

		AdvNode node2 = new AdvNode("ride", new string[15] {
			"\"I guess I'll go for a ride. It makes things easier.\"",
			"Helping my self up on the camel, we rode towards the nearest town. Good thing I rode with the man.",
			"It would probably be a long walk ahead of me if I'd decided to just follow him later on.",
			"Man, I'm thirsty. The heat is still getting to me.",
			"\"Do you want some water?\" Was he a mind-reader or what?",
			"\"Are you sure, sir?\"",
			"\"You need it more than I do.\"",
			"Eyeing the waterbottle curiously, \"Erm, thanks,\" I drank the contents of it with the liquid spilling all over my lips.",
			"Looks like I was that thirsty.",
			"After that, the journey to the nearest town dragged on as I felt a bit sleepy. Even though I wanted to stay awake, I was too tired and the ride was making me too relaxed.",
			"Almost an hour passed, I woke up abruptly as I felt the hot sandy ground on my face. Who pushed me down?",
			"Glaring at the possible culprit, my eyes only narrowed to see the man on the camel with a smirk plastered on his lips. Our stares never lasted however, due to the fact that he had whipped me on the face as if trying to state that I was beneath him.",
			"Great. I was captured by a slave trader.",
			"And with that, the start of the tales of my life as a slave, where I had died the year after I was turned into a slave, began.",
			"Talk about bad decisions."
		}, new AdvChoices("end", "END!"));
		camel.AddNode(node2);

		root.nodes[2] = camel;
	}

	public void Node3() {
		AdvNode caravan = new AdvNode("caravan", new string[8] {
			"It's a long caravan.",
			"Approaching the caravan, I asked if I could travel with them. Perhaps, I can find clues about Astaris during the travel?",
			"Sadly, I was denied of entry not until I saw in one of their delivery wagons, an advertisement.",
			"They were looking for a porter.",
			"I don't know if I'm confident enough with my strength, but, this is my last chance!",
			"\"Sir! If you're not able to allow me to travel with you, can I apply as a porter instead?\"",
			"The leader of the caravan sighed, \"Why are you so desperate, young man?\"",
			"Should I tell the truth or not about Astaris and about my amnesia?"
		}, new AdvChoices[3] {
			new AdvChoices("truth", "I'm going to tell the truth"),
			new AdvChoices("whitelie", "I'm going to tell a little white lie."),
			new AdvChoices("lie", "I'm not going to tell the truth"),
		});

		AdvNode node1 = new AdvNode("truth", new string[37] {
			"And that's when I told everything. As soon as I showed the word behind the brooch to the leader of the caravan, he quickly decided to change the direction of the caravan.",
			"\"Where are we going, sir?\"",
			"\"To Astaris.\"",
			"\"You know about it?\"",
			"\"Know about it? I lived in it. It's my hometown, young man.\"",
			"Turning to the north-eastern direction, Panra, the leader's name which he gave me just awhile ago after we made our turn, talked about various of things about Astaris.",
			"\"Astaris is the home of merchants. You can say it's one of the richest city in the country.\"",
			"\"It's also the main city because, it's where the palace of the Gierroh Royal Family is located.\"",
			"\"By the way, why do you have that royal family seal on you?\"",
			"\"But, this is a brooch,\" I raised an eyebrow.",
			"\"No high-class merchant is fooled by such item. Well, at least the noble-type merchants.\"",
			"\"If you turn nudge and turn the gleaming side... yes, yes that red gem. Turn that, and you'll see the royal seal.\"",
			"\"One stamp of that and it will authorize everything that is stated on the paper that it had the stamp on.\"",
			"\"Unless, of course... you were in another country.\"",
			"Now, I get it. This leader guy called Panra, \"You're a noble-type merchant, aren't you?\"",
			"\"Don't be too slow, my boy. I revealed myself to you through that explanation, didn't I?\" Panra shook his head, \"You don't need my life story on how I ended up in this normal merchant caravan.\"",
			"\"Also, you never answered my question.\"",
			"Scratching behind my head, I didn't know what I could say. Honestly, I didn't know either. I already told him I had amnesia.",
			"I looked at the brooch. Astaris, \"Well, sir. I just woke up with it.\"",
			"Panra looked at me in the eye and called out to someone from one of the delivery wagons, \"Hey Isma. You worked for the royal family, right?\"",
			"An old lady came out in a small smile with eyes dancing in mirth as she stared at me and my brooch, \"Why yes, Panra.\"",
			"\"You happened to see this guy in the castle?\"",
			"\"Yes, yes I did.\"",
			"Panra turned his head back to me after conversing with the old lady called Isma, \"Maybe you were a worker there trusted to carry that seal as a carrier to hide it from possible enemies during that grand palace event a month ago.\"",
			"Brushing around the brooch with my hand, \"Then, I should give this back as soon as possible.\"",
			"Isma chuckled, \"I never said I saw you working there, dearie.\"",
			"Panra, who was drinking his fill from his waterbottle, had almost spit out the water from his mouth, \"Don't tell me?!\"",
			"\"After the grand palace event a month ago, the youngest prince was found missing and his highness, King Omunra ordered for a search of Prince Ehki.\"",
			"\"You'll get a handsome reward for returning Prince Ehki, Panra. Enough to rebuild your noble merchant clan, right?\"",
			"\"Isma, you-?\"",
			"Everything was going fast. My name's Ehki and more importantly, I was a prince?",
			"Judging from the story, I was probably kidnapped in an attempt to find the royal family seal with me, only to not succeed because, no one other than the royal family and noble merchant clans knew how it looked like.",
			"Probably the reason why I was left alone in the desert to fend for myself.",
			"As I tried to process my thoughts, I looked up to see the walls of Astaris, my home.",
			"\"I am... Prince Ehki.\"",
			"I closed my eyes and slowly opened them as the brooch glowed with my memories slowly returning.",
			"\"I'm home.\""
		}, new AdvChoices("end", "END!"));
		caravan.AddNode(node1);

		AdvNode node2 = new AdvNode("whitelie", new string[6] {
			"I'm going to tell a little white lie. I'll leave out the thing about the Astaris and just mention about my amnesia.",
			"\"You see, sir. Your caravan will give me opportunities to seek out the truth of who I am and where I came from. I woke up in the middle of the desert with no memories and your caravan is the first help I could find. I just want to survive and find out who I am.\"",
			"Not totally convinced, it tooks some time for the leader to decide but, he finally agreed.",
			"I did my job properly. And in the end, I stayed with the caravan. I greatly enjoyed the caravan too much that they became my family.",
			"My priorities also got twisted along the way as well and I had forgotten about my original quest.",
			"Past is past...right?"
		}, new AdvChoices("end", "END!"));
		caravan.AddNode(node2);

		AdvNode node3 = new AdvNode("lie", new string[14] {
			"I'm not going to tell the truth.",
			"\"I really need the job, sir. I have no money and food. That is why I'm desperate. I want to continue living.\"",
			"Reluctantly, the leader of the caravan agreed but with a condition of just having me take the job until the nearest town.",
			"Well, good enough for me!",
			"As we traveled to the nearest town, I could feel the buzzing sensation of my brooch going stronger. Was that a bad sign?",
			"Probably because I lied to the leader of the caravan. Well, that was annoying.",
			"Grabbing the brooch, I threw it outside the wagon and left it to the dust.",
			"There. That takes care of it.",
			"It was already an hour and we still haven't arrived. It was supposed to be faster, but the growing strength of the winds was making it diffiult for the caravan to go faster.",
			"\"Hey, Isma!\" The leader of the caravan called out, \"I thought there was no sandstorm today! Was your prediction wrong?\"",
			"An old lady came out with a frown on her face, but, weirdly, her eyes danced with mirth at me as if she knows something I didn't, \"The prediction was correct. There was supposed to be no sandstorm today. At least, not natural ones.\"",
			"The leader didn't get what she said as she disappeared back inside the wagon.",
			"\"Ugh, she got the prediction wrong. That's a first.\"",
			"With that, the caravan never reached that nearest town."
		}, new AdvChoices("end", "END!"));
		caravan.AddNode(node3);

		root.nodes[3] = caravan;
	}

	public void EndNode() {
		AdvNode end = new AdvNode("end", new string[1] { "END!"});
		root.nodes[4] = end;
	}
}
