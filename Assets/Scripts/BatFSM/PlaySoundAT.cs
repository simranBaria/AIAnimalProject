using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Actions {

	public class PlaySoundAT : ActionTask {
		public SoundEffect soundEffect;
		public bool loop;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			// Play the sound
			if (loop) AudioPlayer.instance.PlayLoopingSound(soundEffect);
			else AudioPlayer.instance.PlaySound(soundEffect);
		}
	}
}