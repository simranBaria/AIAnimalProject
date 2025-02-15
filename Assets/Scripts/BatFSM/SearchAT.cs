using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SearchAT : ActionTask {
		public float wanderDistance, wanderRadius, wanderSampleFrequency, wanderDirectionChangeFrequency;

		public BBParameter<Vector3> target;

		private Vector3 randomPoint = Vector3.zero;
		private float timerSinceLastDirectionChange = 0, timeSinceLastSample = 0;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			Vector3 circleCentre = agent.transform.position + agent.transform.forward * wanderDistance;

			timeSinceLastSample += Time.deltaTime;
			timerSinceLastDirectionChange += Time.deltaTime;

			if (timeSinceLastSample > wanderSampleFrequency)
			{
				Vector3 destination = circleCentre + new Vector3(randomPoint.x, agent.transform.position.y, randomPoint.y);
				target.value = destination;
				timeSinceLastSample = 0f;
				Debug.DrawLine(agent.transform.position, circleCentre, Color.red, 0.25f);
				DrawCircle(circleCentre, wanderRadius, Color.cyan, 12);
			}
			if(timerSinceLastDirectionChange > wanderDirectionChangeFrequency)
            {
				randomPoint = Random.insideUnitCircle.normalized * wanderRadius;
				timerSinceLastDirectionChange = 0;
            }
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

		private void DrawCircle(Vector3 circleCentre, float radius, Color circleColor, int numberOfPoints)
        {
			int increment = 360 / numberOfPoints;
			for(int i = 0; i < 360; i+= increment)
            {
				Vector3 p1 = new Vector3(Mathf.Cos(i * Mathf.Deg2Rad), 0, Mathf.Sin(i * Mathf.Deg2Rad)) * radius;
				Vector3 p2 = new Vector3(Mathf.Cos((i + increment) * Mathf.Deg2Rad), 0, Mathf.Sin((i + increment) * Mathf.Deg2Rad)) * radius;
				Debug.DrawLine(circleCentre + p1, circleCentre + p2, circleColor, 0.25f);
			}
		}
	}
}