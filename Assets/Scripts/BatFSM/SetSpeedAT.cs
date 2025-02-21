using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Actions {

	public class SetSpeedAT : ActionTask {
		public BBParameter<float> currentHorizontalSpeed, currentVerticalSpeed;

		public float horizontalSpeed, verticalSpeed;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			// Set the speeds
			currentHorizontalSpeed.value = horizontalSpeed;
			currentVerticalSpeed.value = verticalSpeed;
		}
	}
}