using System.Collections.Generic;

public class EventBroadcaster {
	// Private Variables
	private Dictionary<string, ObjectListener> objListener;

	private static EventBroadcaster instance;
	public static EventBroadcaster sharedInstance {
		get {
			if (instance == null) {
				instance = new EventBroadcaster();
			}

			return instance;
		}
	}

	private EventBroadcaster() {
		objListener = new Dictionary<string, ObjectListener>();
	}

	public void AddObserver(string name, System.Action action) {
		ObjectListener listener = null;
		if (objListener.ContainsKey(name)) {
			listener = objListener[name];
			listener.AddObserver(action);
		}
		else {
			listener = new ObjectListener();
			listener.AddObserver(action);
			objListener.Add(name, listener);
		}
	}

	public void AddObserver(string name, System.Action<Parameters> action) {
		ObjectListener listener = null;
		if (objListener.ContainsKey(name)) {
			listener = objListener[name];
			listener.AddObserver(action);
		}
		else {
			listener = new ObjectListener();
			listener.AddObserver(action);
			objListener.Add(name, listener);
		}
	}

	public void RemoveObserverAction(string name, System.Action action) {
		if (objListener.ContainsKey(name)) {
			ObjectListener listener = objListener[name];
			listener.RemoveObserver(action);
		}
	}

	public void RemoveObserverAction(string name, System.Action<Parameters> action) {
		if (objListener.ContainsKey(name)) {
			ObjectListener listener = objListener[name];
			listener.RemoveObserver(action);
		}
	}

	public void NotifyObserver(string name) {
		if (objListener.ContainsKey(name)) {
			ObjectListener listener = objListener[name];
			listener.NotifyObservers();
		}
	}

	public void NotifyObserver(string name, Parameters param) {
		if (objListener.ContainsKey(name)) {
			ObjectListener listener = objListener[name];
			listener.NotifyObservers(param);
		}
	}

	public void RemoveObserver(string name) {
		if (objListener.ContainsKey(name)) {
			ObjectListener listener = objListener[name];
			listener.RemoveAllObservers();
			objListener.Remove(name);
		}
	}

	public void ClearObservers() {
		foreach (ObjectListener listener in objListener.Values) {
			listener.RemoveAllObservers();
		}

		objListener.Clear();
	}
}