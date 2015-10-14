using System.Collections.Generic;

public class ObjectListener {

	// Public Variables

	// Private Variables
	private List<System.Action> noParamEvents;
	private List<System.Action<Parameters>> paramEvents;

	// Static Variables

	public ObjectListener() {
		noParamEvents = new List<System.Action>();
		paramEvents = new List<System.Action<Parameters>>();
	}

	public void AddObserver(System.Action action, bool prepend = false) {
		if (prepend) {
			noParamEvents.Insert(0, action);
			return;
		}

		noParamEvents.Add(action);
	}

	public void AddObserver(System.Action<Parameters> action, bool prepend = false) {
		if (prepend) {
			paramEvents.Insert(0, action);
			return;
		}

		paramEvents.Add(action);
	}

	public void RemoveObserver(System.Action action) {
		noParamEvents.Remove(action);
	}

	public void RemoveObserver(System.Action<Parameters> action) {
		paramEvents.Remove(action);
	}

	public void RemoveAllObservers() {
		noParamEvents.Clear();
		paramEvents.Clear();
	}

	public void NotifyObservers() {
		for (int i = 0; i < noParamEvents.Count; i++) {
			System.Action action = noParamEvents[i];
			action();
		}
	}

	public void NotifyObservers(Parameters param) {
		for (int i = 0; i < paramEvents.Count; i++) {
			System.Action<Parameters> action = paramEvents[i];
			action(param);
		}
	}

	public int GetAllListenerCount() {
		return paramEvents.Count + noParamEvents.Count;
	}
}