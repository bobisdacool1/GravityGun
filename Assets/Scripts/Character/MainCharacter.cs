using System;
using Character.Input;
using UnityEngine;

namespace Character
{
	public class MainCharacter : MonoBehaviour
	{
		[SerializeField] private Transform cameraTransform;
		private Utils _utils;

		public void OnEnable()
		{
			_utils = new Utils();
			_utils.Movement.InitializeInputEvents(_utils.InputHandler);
			_utils.Movement.SetMovementTarget(transform);
			_utils.Movement.SetRotateTarget(cameraTransform);
		}

		public void Update()
		{
			_utils.InputHandler.HandleInput();
		}
	}
}