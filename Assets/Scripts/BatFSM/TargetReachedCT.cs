using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class TargetReachedCT : ConditionTask {
		public BBParameter<Vector3> target, position;
		public BBParameter<float> stoppingDistance;

		protected override string OnInit(){
			return null;
		}

		protected override bool OnCheck() {
			// Check if the position of the model has reached the target
			return Vector3.Distance(position.value, target.value) <= stoppingDistance.value;
		}
	}
}