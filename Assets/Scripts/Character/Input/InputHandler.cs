using UnityEngine;

namespace Character.Input
{
	public class InputHandler
	{
		public delegate void AxisChanged(float axisChangeValue);
		public delegate void ButtonPressed();

		public event AxisChanged OnHorizontalAxisChange;
		public event AxisChanged OnVerticalAxisChange;
		public event AxisChanged OnMouseXAxisChange;
		public event AxisChanged OnMouseYAxisChange;
		public event ButtonPressed OnFireButtonClick;

		public void HandleInput()
		{
			checkAxisAndExecuteEvent(Axis.Horizontal, OnHorizontalAxisChange);
			checkAxisAndExecuteEvent(Axis.Vertical, OnVerticalAxisChange);
			checkAxisAndExecuteEvent(Axis.MouseX, OnMouseXAxisChange);
			checkAxisAndExecuteEvent(Axis.MouseY, OnMouseYAxisChange);

			checkButtonAndExecuteEvent(Axis.Fire1, OnFireButtonClick);
		}

		private void checkAxisAndExecuteEvent(string axisName, AxisChanged axisChangedEvent)
		{
			float axisValue = UnityEngine.Input.GetAxis(axisName);
			if (axisValue != 0)
				axisChangedEvent?.Invoke(axisValue);
		}

		private void checkButtonAndExecuteEvent(string axisName, ButtonPressed buttonPressedEvent)
		{
			bool isKeyPressed = UnityEngine.Input.GetButtonDown(axisName);
			if (isKeyPressed)
				buttonPressedEvent?.Invoke();
		}
	}
}