using NodeCanvas.Framework;
using UnityEngine;
using System.Collections;

namespace NodeCanvas.Tasks.Actions {

	public class EcholocateAT : ActionTask {
		public BBParameter<Vector3> position, target;
		public BBParameter<bool> bugFound;
		public BBParameter<GameObject> bugToEat;

		public float frequency, distance;
		public LayerMask bugMask;
		public SoundEffect soundEffect;

		Collider[] bugs;
		bool echolocate;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			echolocate = true;
		}

		protected override void OnUpdate() {
			// Send a signal to check for bugs
			if (echolocate)
			{
				AudioPlayer.instance.PlaySound(soundEffect);
				StartCoroutine(SendSignal());
			}

			// Found a bug
			if (bugs.Length > 0)
			{
				bugToEat.value = bugs[0].gameObject;
				target.value = bugToEat.value.transform.position;
				bugFound.value = true;
			}
		}

		IEnumerator SendSignal()
		{
			echolocate = false;
			bugs = Physics.OverlapSphere(position.value, distance, bugMask);

			// Wait until the cooldown is done to echolocate again
			yield return new WaitForSeconds(frequency);
			echolocate = true;
        }
	}
}