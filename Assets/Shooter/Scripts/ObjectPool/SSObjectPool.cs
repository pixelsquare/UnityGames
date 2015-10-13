using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SSObjectPool : MonoBehaviour {
	[SerializeField]
	private SSObject[] pooledObjects;

	private Dictionary<SSObjectID, SSPooledObject> objectList;

	[System.Serializable]
	public class SSObject {
		public GameObject obj;
		public SSObjectID objID;
		public int pooledSize = 5;
	}

	public class SSPooledObject {
		public GameObject obj;
		public Transform parent;
		public List<GameObject> objList;
	}

	public static SSObjectPool sharedInstance;

	public void Start() {
		sharedInstance = this;
		objectList = new Dictionary<SSObjectID, SSPooledObject>();

		for (int i = 0; i < pooledObjects.Length; i++) {
			GameObject objParent = new GameObject(pooledObjects[i].obj.name + " Parent");
			objParent.transform.parent = transform;

			SSPooledObject pooledObj = new SSPooledObject();
			List<GameObject> objList = new List<GameObject>();

			for (int j = 0; j < pooledObjects[i].pooledSize; j++) {
				GameObject obj = (GameObject)Instantiate(pooledObjects[i].obj);
				obj.name = pooledObjects[i].obj.name;
				obj.transform.parent = objParent.transform;
				obj.SetActive(false);
				objList.Add(obj);
			}

			pooledObj.obj = pooledObjects[i].obj;
			pooledObj.parent = objParent.transform;
			pooledObj.objList = objList;
			objectList.Add(pooledObjects[i].objID, pooledObj);
		}
	}

	public void AddObject(SSObjectID name, GameObject obj) {
		List<GameObject> gameObjList = null;
		if (objectList.ContainsKey(name)) {
			gameObjList = objectList[name].objList;
			gameObjList.Add(obj);
		}
		else {
			gameObjList = new List<GameObject>();
			gameObjList.Add(obj);

			SSPooledObject pooledObj = new SSPooledObject();
			pooledObj.obj = obj;

			GameObject objParent = new GameObject(obj.name + " Parent");
			pooledObj.parent = objParent.transform;
			objectList.Add(name, pooledObj);
		}
	}

	public void RemoveObject(SSObjectID name, GameObject obj) {
		if (objectList.ContainsKey(name)) {
			List<GameObject> gameObjList = objectList[name].objList;
			gameObjList.Remove(obj);
		}
	}

	public GameObject GetObject(SSObjectID name) {
		if (objectList.ContainsKey(name)) {
			List<GameObject> objList = objectList[name].objList;
			for (int i = 0; i < objList.Count; i++) {
				if (!objList[i].activeInHierarchy) {
					return objList[i];
				}
			}

			// Creates additional objects if needed
			GameObject obj = (GameObject)Instantiate(objectList[name].obj);
			obj.name = objectList[name].obj.name;
			obj.transform.parent = objectList[name].parent;
			objList.Add(obj);
			objectList[name].objList = objList;
			return obj;
		}

		return null;
	}
}
