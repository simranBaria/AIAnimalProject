using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class DiveAT : ActionTask {
		public BBParameter<Vector3> target;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			// Send to the ground, do not move the x or z
			target.value = new(agent.transform.position.x, 0, agent.transform.position.z);
		}
	}
}