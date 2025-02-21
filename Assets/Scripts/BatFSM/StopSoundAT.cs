using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Actions {

	public class StopSoundAT : ActionTask {

		protected override string OnInit() {
			return null;
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			AudioPlayer.instance.StopSound();
		}
	}
}