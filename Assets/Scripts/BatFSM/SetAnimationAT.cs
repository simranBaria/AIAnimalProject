using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SetAnimationAT : ActionTask
	{
		public AnimationState state;
		public BBParameter<GameObject> model;
		private Animator animator;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit()
		{
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
		{
			// Set the animation
			animator = model.value.GetComponent<Animator>();
			switch (state)
			{
				case AnimationState.Idle:
					animator.Play("BatIdle");
					break;

				case AnimationState.Fly:
					animator.Play("BatFly");
					break;

				case AnimationState.Dive:
					animator.Play("BatDive");
					break;

				case AnimationState.Drink:
					animator.Play("BatDrink");
					break;

				case AnimationState.Sleep:
					animator.Play("BatSleep");
					break;
			}
		}
	}

	// Enum to store animation states
	public enum AnimationState
	{
		Idle,
		Fly,
		Dive,
		Drink,
		Sleep
	}
}