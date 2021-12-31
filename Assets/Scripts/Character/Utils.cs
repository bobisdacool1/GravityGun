using Character.Input;

namespace Character
{
	public class Utils
	{
		public readonly Movement Movement;
		public readonly InputHandler InputHandler;
		public Utils()
		{
			InputHandler = new InputHandler();
			Movement = new Movement();
		}
	}
}