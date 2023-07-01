using UnityEngine;

public class ViewController : MonoBehaviour
{
	[SerializeField] private Transform cameraSpringArmTransform;
	[SerializeField] private float mouseSensitivity;

	private void FixedUpdate()
	{
		if (Input.GetMouseButton(1)) {
			float mouseVelocityX = Input.GetAxis("Mouse X");
			float mouseVelocityY = Input.GetAxis("Mouse Y");
			
			Vector3 cameraSpringArmEulerAngles = cameraSpringArmTransform.eulerAngles;
			float mouseX = cameraSpringArmEulerAngles.y + mouseVelocityX * mouseSensitivity;
			float mouseY = cameraSpringArmEulerAngles.z - mouseVelocityY * mouseSensitivity;
			cameraSpringArmTransform.rotation = Quaternion.Euler(0, mouseX, mouseY);
		}
	}
}