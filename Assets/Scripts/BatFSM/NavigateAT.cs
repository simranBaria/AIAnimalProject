using NodeCanvas.Framework;
using UnityEngine.AI;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class NavigateAT : ActionTask {
		public BBParameter<Vector3> target, position;
		public BBParameter<GameObject> model;
		public BBParameter<bool> aboveWater;
		public BBParameter<float> horizontalSpeed, verticalSpeed;

		public LayerMask water;

		private NavMeshAgent nmAgent;
		private Transform modelPosition;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			nmAgent = agent.GetComponent<NavMeshAgent>();
			modelPosition = model.value.GetComponent<Transform>();
			return null;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			// Send the navmesh agent to it's desired x and z positions
			nmAgent.speed = horizontalSpeed.value;
            nmAgent.SetDestination(new(target.value.x, 0, target.value.z));
			
			// Send the model to it's desired y position
			modelPosition.localPosition = Vector3.Lerp(modelPosition.localPosition, new(0, target.value.y, 0), Time.deltaTime * verticalSpeed.value);

			// Update the position of the model
			position.value = new(agent.transform.position.x, modelPosition.localPosition.y, agent.transform.position.z);

			// Check if the agent is above water
			if (Physics.Raycast(agent.transform.position, Vector3.down, 1, water)) aboveWater.value = true;
			else aboveWater.value = false;
        }
	}
}