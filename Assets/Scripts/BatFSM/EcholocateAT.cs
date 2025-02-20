using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections;

namespace NodeCanvas.Tasks.Actions {

	public class EcholocateAT : ActionTask {
		public BBParameter<Vector3> position, target;
		public BBParameter<bool> bugFound;
		public BBParameter<GameObject> bugToEat;

		public float frequency, distance;
		public LayerMask bugMask;

		Collider[] bugs;
		bool echolocate;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			echolocate = true;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (echolocate) StartCoroutine(SendSignal());
			if (bugs.Length > 0)
			{
				bugToEat.value = bugs[0].gameObject;
				target.value = bugToEat.value.transform.position;
				bugFound.value = true;
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

		IEnumerator SendSignal()
        {
			echolocate = false;
			bugs = Physics.OverlapSphere(position.value, distance, bugMask);
			DrawCircle(position.value, distance, Color.blue, 12);
			yield return new WaitForSeconds(frequency);
			echolocate = true;
        }

		private void DrawCircle(Vector3 circleCentre, float radius, Color circleColor, int numberOfPoints)
		{
			int increment = 360 / numberOfPoints;
			for (int i = 0; i < 360; i += increment)
			{
				Vector3 p1 = new Vector3(Mathf.Cos(i * Mathf.Deg2Rad), 0, Mathf.Sin(i * Mathf.Deg2Rad)) * radius;
				Vector3 p2 = new Vector3(Mathf.Cos((i + increment) * Mathf.Deg2Rad), 0, Mathf.Sin((i + increment) * Mathf.Deg2Rad)) * radius;
				Debug.DrawLine(circleCentre + p1, circleCentre + p2, circleColor, 5);
			}
		}
	}
}