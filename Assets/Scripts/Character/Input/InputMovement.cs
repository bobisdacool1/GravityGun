using UnityEngine;
using UnityInput = UnityEngine.Input; 

namespace Character.Input
{
	public class InputMovement
	{
		public delegate void MovementAxisChange(Vector3 axesValue);
		
		public event MovementAxisChange OnMovingAxisChange;
		public event MovementAxisChange OnRotationAxisChange;

		public void HandleMovementInput()
		{
			CheckInputAndExecuteEvent(Axis.Horizontal, Axis.Empty, Axis.Vertical, OnMovingAxisChange);
			CheckInputAndExecuteEvent(Axis.MouseY, Axis.MouseX, Axis.Empty, OnRotationAxisChange);
		}

		private void CheckInputAndExecuteEvent(string xAxis, string yAxis, string zAxis, MovementAxisChange executableEvent)
		{
			float axisChangeValueX = UnityInput.GetAxis(xAxis);
			float axisChangeValueY = UnityInput.GetAxis(yAxis);
			float axisChangeValueZ = UnityInput.GetAxis(zAxis);
			
			Vector3 axisChangeVector = new Vector3(axisChangeValueX, axisChangeValueY, axisChangeValueZ);
			
			if (axisChangeVector != Vector3.zero)
				executableEvent?.Invoke(axisChangeVector);
		}
	}
}