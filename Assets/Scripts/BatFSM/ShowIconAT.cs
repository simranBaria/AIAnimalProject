using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ShowIconAT : ActionTask {
		public BBParameter<GameObject> model;

		public GameObject iconPrefab;
		public SoundEffect soundEffect;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			// Show the icon
			AudioPlayer.instance.PlaySound(soundEffect);
			Object.Instantiate(iconPrefab, model.value.transform);
		}
	}
}