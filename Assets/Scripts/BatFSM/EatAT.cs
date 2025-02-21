using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class EatAT : ActionTask {
		public BBParameter<GameObject> bug;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			// Eat the bug
			Object.Destroy(bug.value);
			BugStats.AteBug();
		}
	}
}