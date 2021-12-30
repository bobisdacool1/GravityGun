using Character.Input;
using UnityEngine;

namespace Character
{
	public class Movement
	{
		public float MovementMultiplier = 10.0f;
		public float RotationMultiplier = 100.0f;
		
		private Transform _player;
		private Transform _camera;

		public void InitializeInputEvents(InputHandler inputHandler)
		{
			inputHandler.OnVerticalAxisChange += MoveAcrossZ;
			inputHandler.OnHorizontalAxisChange += MoveAcrossX;
			inputHandler.OnMouseXAxisChange += RotateYaw;
			inputHandler.OnMouseYAxisChange += RotatePitch;
		}

		public void SetPlayerTransform(Transform target)
		{
			_player = target;
		}
		
		public void SetCameraTransform(Transform target)
		{
			_camera = target;
		}


		private void MoveAcrossZ(float movementValue)
		{
			float movement = movementValue * MovementMultiplier * Time.deltaTime;
			_player.Translate(0, 0, movement);
		}
		
		private void MoveAcrossX(float movementValue)
		{
			float movement = movementValue * MovementMultiplier * Time.deltaTime;
			_player.Translate(movement, 0, 0);
		}

		private void RotateYaw(float rotationValue)
		{
			float rotation = rotationValue * RotationMultiplier * Time.deltaTime;
			_player.Rotate(0, rotation, 0);
		}
		
		private void RotatePitch(float rotationValue)
		{
			float rotation = rotationValue * RotationMultiplier * Time.deltaTime * -1.0f;
			_camera.Rotate(rotation, 0, 0);
		}
	}
}