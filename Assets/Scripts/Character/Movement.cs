using Character.Input;
using UnityEngine;

namespace Character
{
	public class Movement
	{
		public float MovementMultiplier = 10.0f;
		public float RotationMultiplier = 100.0f;
		public Transform Player;
		public Transform Camera;

		public void InitializeInputEvents(InputHandler inputHandler)
		{
			inputHandler.OnVerticalAxisChange += MoveAcrossZ;
			inputHandler.OnHorizontalAxisChange += MoveAcrossX;
			inputHandler.OnMouseXAxisChange += RotateYaw;
			inputHandler.OnMouseYAxisChange += RotatePitch;
		}

		public void SetMovementTarget(Transform target)
		{
			Player = target;
		}
		
		public void SetRotateTarget(Transform target)
		{
			Camera = target;
		}


		private void MoveAcrossZ(float movementValue)
		{
			float movement = movementValue * MovementMultiplier * Time.deltaTime;
			Player.Translate(0, 0, movement);
		}
		
		private void MoveAcrossX(float movementValue)
		{
			float movement = movementValue * MovementMultiplier * Time.deltaTime;
			Player.Translate(movement, 0, 0);
		}

		private void RotateYaw(float rotationValue)
		{
			float rotation = rotationValue * RotationMultiplier * Time.deltaTime;
			Player.Rotate(0, rotation, 0);
		}
		
		private void RotatePitch(float rotationValue)
		{
			float rotation = rotationValue * RotationMultiplier * Time.deltaTime * -1.0f;
			Camera.Rotate(rotation, 0, 0);
		}
	}
}