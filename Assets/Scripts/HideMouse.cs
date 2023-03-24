using UnityEngine;
using UnityEngine.InputSystem;

public class HideMouse : MonoBehaviour
{
	private void OnEnable()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
}
