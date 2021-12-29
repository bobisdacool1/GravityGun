using UnityEngine;

namespace Character.Input
{
	public class InputHandler
	{
		public delegate void AxisChange(float axisChangeValue);

		public event AxisChange OnHorizontalAxisChange;
		public event AxisChange OnVerticalAxisChange;
		public event AxisChange OnMouseXAxisChange;
		public event AxisChange OnMouseYAxisChange;

		public InputHandler()
		{
			
		}
		
		public void HandleInput()
		{
			checkAxisAndExecuteEvent(Axis.Horizontal, OnHorizontalAxisChange);
			checkAxisAndExecuteEvent(Axis.Vertical, OnVerticalAxisChange);
			checkAxisAndExecuteEvent(Axis.MouseX, OnMouseXAxisChange);
			checkAxisAndExecuteEvent(Axis.MouseY, OnMouseYAxisChange);
		}

		private void checkAxisAndExecuteEvent(string axisName, AxisChange axisChangeEvent)
		{
			float axisValue = UnityEngine.Input.GetAxis(axisName);
			if (axisValue != 0)
				axisChangeEvent?.Invoke(axisValue);
		}
	}
}