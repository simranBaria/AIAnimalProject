using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class CheckTimeCT : ConditionTask {
		public bool checkIfNight;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			// Check if it's night or day
			if (checkIfNight) return TimeCycle.isNight;
			else return !TimeCycle.isNight;
		}
	}
}