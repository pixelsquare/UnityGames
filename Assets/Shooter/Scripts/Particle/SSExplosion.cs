using UnityEngine;
using System.Collections;

public class SSExplosion : MonoBehaviour {
	[SerializeField]
	private ParticleSystem particle;

	public void OnEnable() {
		StartCoroutine(DisableParticle());
	}

	public IEnumerator DisableParticle() {
		while (!particle.isStopped) {
			yield return null;
		}

		gameObject.SetActive(false);
	}
}
