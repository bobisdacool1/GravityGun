using System;
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
			//todo: fix this awful thing
			RemoveCursor();
		}

		public void OnEnable()
		{
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

		public Transform getCameraTransform()
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
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
}