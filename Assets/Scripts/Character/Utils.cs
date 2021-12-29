using Character.Input;

namespace Character
{
	public class Utils
	{
		public Movement Movement;
		public InputHandler InputHandler;
		public Utils()
		{
			InputHandler = new InputHandler();
			Movement = new Movement();
		}
	}
}