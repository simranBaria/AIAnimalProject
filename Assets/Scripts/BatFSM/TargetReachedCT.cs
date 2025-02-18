using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class TargetReachedCT : ConditionTask {
		public BBParameter<Vector3> target, position;
		public BBParameter<float> stoppingDistance;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			// Check if the position of the model has reached the target
			return Vector3.Distance(position.value, target.value) <= stoppingDistance.value;
		}
	}
}