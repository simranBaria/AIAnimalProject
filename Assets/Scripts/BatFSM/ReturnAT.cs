using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ReturnAT : ActionTask {
		public Transform sleepSpot;

		public BBParameter<Vector3> target;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			// Set the target as the sleeping position
			target.value = sleepSpot.position;
		}
	}
}