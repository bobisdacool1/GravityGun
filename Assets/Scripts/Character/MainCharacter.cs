using Character.Input;
using UnityEngine;

namespace Character
{
	public class MainCharacter : MonoBehaviour
	{
		[SerializeField] private Transform cameraTransform;

		private Utils _utils;

		public void Awake()
		{
			RemoveCursor();

			_utils = new Utils();
			InitializeMovement();
		}

		public void Update()
		{
			_utils.InputHandler.HandleInput();
		}

		public InputHandler GetInputHandler()
		{
			return _utils.InputHandler;
		}

		public Transform GetCameraTransform()
		{
			return cameraTransform;
		}

		private void InitializeMovement()
		{
			_utils.Movement.InitializeInputEvents(_utils.InputHandler);
			_utils.Movement.SetPlayerTransform(transform);
			_utils.Movement.SetCameraTransform(cameraTransform);
		}

		private void RemoveCursor()
		{
			//todo: fix this awful thing, i goto move this to some UI script or something
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
}