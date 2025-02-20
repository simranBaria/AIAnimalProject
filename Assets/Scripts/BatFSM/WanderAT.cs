using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class WanderAT : ActionTask {
		public BBParameter<Vector3> target;
		public BBParameter<float> minHeight, maxHeight, currentHorizontalSpeed, currentVerticalSpeed;
		public BBParameter<GameObject> model;

		public float wanderDistance, wanderRadius, wanderSampleFrequency, wanderDirectionChangeFrequency;

		private Vector3 randomPoint = Vector3.zero;
		private float timerSinceLastDirectionChange = 0, timeSinceLastSample = 0;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			Vector3 circleCentre = agent.transform.position + agent.transform.forward * wanderDistance;

			timeSinceLastSample += Time.deltaTime;
			timerSinceLastDirectionChange += Time.deltaTime;

			if (timeSinceLastSample > wanderSampleFrequency)
			{
				Vector3 destination = circleCentre + new Vector3(randomPoint.x, Mathf.Clamp(model.value.GetComponent<Transform>().position.y + Random.Range(-5, 5), 0.5f, 20), randomPoint.z);
				target.value = destination;
				timeSinceLastSample = 0f;
			}
			if(timerSinceLastDirectionChange > wanderDirectionChangeFrequency)
            {
				randomPoint = Random.insideUnitCircle.normalized * wanderRadius;
				timerSinceLastDirectionChange = 0;
            }
		}
	}
}