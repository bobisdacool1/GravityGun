using UnityEngine;

namespace Character.Guns
{
	public class BallGun : MonoBehaviour
	{
		[SerializeField] private MainCharacter mainCharacter;
		[SerializeField] private GameObject shellPrefab;
		[SerializeField] private Transform shellSpawnPoint;
		[SerializeField] private float velocityMultiplier = 1.0f;

		public void Start()
		{
			mainCharacter.GetInputHandler().InputActions.OnFireButtonPressed += Shot;
		}

		private void Shot()
		{
			GameObject shell = Instantiate(shellPrefab, shellSpawnPoint.position, 
				mainCharacter.GetCameraTransform().rotation, null);

			Vector3 velocity = transform.forward * velocityMultiplier;
			shell.GetComponent<Rigidbody>().AddForce(velocity);
		}
	}
}