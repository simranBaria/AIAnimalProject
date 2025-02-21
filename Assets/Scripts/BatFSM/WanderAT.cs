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

		protected override string OnInit() {
			return null;
		}

		protected override void OnUpdate() {
			// Get the centre
			Vector3 circleCentre = agent.transform.position + agent.transform.forward * wanderDistance;

			// Update timers
			timeSinceLastSample += Time.deltaTime;
			timerSinceLastDirectionChange += Time.deltaTime;

			// Set new destination
			if (timeSinceLastSample > wanderSampleFrequency)
			{
				// Clamp the y between the min and max
				Vector3 destination = circleCentre + new Vector3(randomPoint.x, Mathf.Clamp(model.value.GetComponent<Transform>().position.y + Random.Range(-5, 5), 0.5f, 20), randomPoint.z);
				target.value = destination;
				timeSinceLastSample = 0f;
			}
			// Get a random point
			if(timerSinceLastDirectionChange > wanderDirectionChangeFrequency)
            {
				randomPoint = Random.insideUnitCircle.normalized * wanderRadius;
				timerSinceLastDirectionChange = 0;
            }
		}
	}
}