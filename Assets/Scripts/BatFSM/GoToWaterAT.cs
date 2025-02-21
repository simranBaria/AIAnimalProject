using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class GoToWaterAT : ActionTask {
		public BBParameter<Vector3> position, target;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			// Water is at the centre of the map
			// Just send the agent to the centre, the check for being above water will pull it out of the state
			target.value = new(0, position.value.y, 0);
		}
	}
}