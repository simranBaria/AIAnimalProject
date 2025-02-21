using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Conditions {

	public class CheckTimeCT : ConditionTask {
		public bool checkIfNight;

		protected override string OnInit(){
			return null;
		}

		protected override bool OnCheck() {
			// Check if it's night or day
			if (checkIfNight) return TimeCycle.isNight;
			else return !TimeCycle.isNight;
		}
	}
}