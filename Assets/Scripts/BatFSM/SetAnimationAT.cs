using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SetAnimationAT : ActionTask
	{
		public BBParameter<GameObject> model;

		public AnimationState state;

		private Animator animator;

		protected override string OnInit()
		{
			return null;
		}

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