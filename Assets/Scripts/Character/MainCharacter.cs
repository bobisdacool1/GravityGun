using Character.Input;
using UnityEngine;

namespace Character
{
	[RequireComponent(typeof(Movement))]
	public class MainCharacter : MonoBehaviour
	{
		[SerializeField] private Transform cameraTransform;
		[SerializeField] private Movement characterMovement;

		private Utils utils;

		public void Awake()
		{
			RemoveCursor();

			utils = new Utils();
			characterMovement.InitializeInputEvents(utils.InputHandler);
		}

		public void Update()
		{
			utils.InputHandler.HandleInput();
		}

		public InputHandler GetInputHandler()
		{
			return utils.InputHandler;
		}

		public Transform GetCameraTransform()
		{
			return cameraTransform;
		}

		private void RemoveCursor()
		{
			//todo: fix this awful thing, i goto move this to some UI script or something
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
}