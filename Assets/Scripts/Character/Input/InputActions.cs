namespace Character.Input
{
	public class InputActions
	{
		public delegate void AxisButtonPressed();
		public event AxisButtonPressed OnFireButtonPressed;

		public void HandleActionsInput()
		{
			checkButtonAndExecuteEvent(Axis.Fire1, OnFireButtonPressed);
		}

		private void checkButtonAndExecuteEvent(string axisName, AxisButtonPressed buttonPressedEvent)
		{
			bool isKeyPressed = UnityEngine.Input.GetButtonDown(axisName);
			if (isKeyPressed)
				buttonPressedEvent?.Invoke();
		}
	}
}