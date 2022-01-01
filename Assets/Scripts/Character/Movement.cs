using System.Collections;
using Character.Input;
using UnityEngine;

namespace Character
{
	[RequireComponent(typeof(Rigidbody))]
	public class Movement : MonoBehaviour
	{
		[SerializeField] private float movementMultiplier = 10.0f;
		[SerializeField] private float rotationMultiplier = 1000.0f;
		[SerializeField] private float jumpForce = 250.0f;

		[SerializeField] private MainCharacter character;


		public void InitializeInputEvents(InputHandler inputHandler)
		{
			inputHandler.InputMovement.OnMovingAxisChange += MoveCharacter;
			inputHandler.InputMovement.OnRotationAxisChange += RotateCharacter;
			inputHandler.InputMovement.OnJumpButtonClick += Jump;
		}

		private void MoveCharacter(Vector3 movementDirection)
		{
			movementDirection *= movementMultiplier * Time.deltaTime;
			character.transform.Translate(movementDirection);
		}

		private void RotateCharacter(Vector3 rotation)
		{
			rotation *= rotationMultiplier * Time.deltaTime;
			character.GetCameraTransform().Rotate(rotation.x, 0, 0);
			character.transform.Rotate(0, rotation.y, 0);
		}

		private void Jump()
		{
			Rigidbody characterRigidbody = GetComponent<Rigidbody>();
			
			if (characterRigidbody.velocity.y == 0)
				characterRigidbody.AddForce(Vector3.up * jumpForce * characterRigidbody.mass);
		}
	}
}