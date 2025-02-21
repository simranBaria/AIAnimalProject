using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class UpdateThirstAT : ActionTask {
		public BBParameter<float> thirst;
		public BBParameter<bool> increase;

		public float increaseChange, decreaseChange;

		protected override string OnInit() {
			return null;
		}

		protected override void OnUpdate() {
			// Change the thirst value
			if (increase.value) thirst.value += Time.deltaTime * increaseChange;
			else thirst.value -= Time.deltaTime * decreaseChange;

			thirst.value = Mathf.Clamp(thirst.value, 0, 100);
		}
	}
}