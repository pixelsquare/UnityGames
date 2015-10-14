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

	/// <summary>
	/// Adds an observer with no parameters
	/// </summary>
	/// <param name="name">Name Identifier</param>
	/// <param name="action">Function</param>
	/// <param name="prepend">Add at the beginning</param>
	public void AddObserver(string name, System.Action action, bool prepend = false) {
		ObjectListener listener = null;
		if (objListener.ContainsKey(name)) {
			listener = objListener[name];
			listener.AddObserver(action, prepend);
		}
		else {
			listener = new ObjectListener();
			listener.AddObserver(action, prepend);
			objListener.Add(name, listener);
		}
	}

	/// <summary>
	/// Adds an observer with parameters
	/// </summary>
	/// <param name="name">Name Identifer</param>
	/// <param name="action">Function</param>
	/// <param name="prepend">Add at the beginning</param>
	public void AddObserver(string name, System.Action<Parameters> action, bool prepend = false) {
		ObjectListener listener = null;
		if (objListener.ContainsKey(name)) {
			listener = objListener[name];
			listener.AddObserver(action, prepend);
		}
		else {
			listener = new ObjectListener();
			listener.AddObserver(action, prepend);
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