using Character.Input;
using UnityEngine;

namespace Character
{
	public class Movement
	{
		public float MovementMultiplier = 10.0f;
		public float RotationMultiplier = 1000.0f;
		
		private Transform _player;
		private Transform _camera;

		public void InitializeInputEvents(InputHandler inputHandler)
		{
			inputHandler.InputMovement.OnMovingAxisChange += MoveCharacter;
			inputHandler.InputMovement.OnRotationAxisChange += RotateCharacter;
		}

		public void SetPlayerTransform(Transform target)
		{
			_player = target;
		}
		
		public void SetCameraTransform(Transform target)
		{
			_camera = target;
		}

		private void MoveCharacter(Vector3 movementDirection)
		{
			movementDirection *= MovementMultiplier * Time.deltaTime;
			_player.Translate(movementDirection);
		}

		private void RotateCharacter(Vector3 rotation)
		{
			rotation *= RotationMultiplier * Time.deltaTime;
			_camera.Rotate(rotation.x, 0, 0);
			_player.Rotate(0, rotation.y, 0);
		}
	}
}