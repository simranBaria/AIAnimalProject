using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class DrinkAT : ActionTask {
		public BBParameter<bool> increaseThirst;
		public BBParameter<Vector3> target, position;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			// Increase the thirst rather than decrease
			increaseThirst.value = true;
		}

		protected override void OnUpdate() {
			// Move forward until no longer over water
			target.value = position.value + agent.transform.forward;
		}

		protected override void OnStop() {
			// Go back to decreaseing thirst
			increaseThirst.value = false;
		}
	}
}