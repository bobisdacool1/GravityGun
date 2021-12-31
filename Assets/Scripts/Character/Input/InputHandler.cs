namespace Character.Input
{
	public class InputHandler
	{
		public readonly InputMovement InputMovement;
		public readonly InputActions InputActions;

		public InputHandler()
		{
			InputMovement = new InputMovement();
			InputActions = new InputActions();
		}

		public void HandleInput()
		{
			InputMovement.HandleMovementInput();
			InputActions.HandleActionsInput();
		}
	}
}