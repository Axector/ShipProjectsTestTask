using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegistrationMenu : MonoBehaviour
{
	public TMP_InputField nameField;
	public TMP_InputField descriptionField;

	public Button submitButton;

	public void CallRegister()
	{
		StartCoroutine(Register());
	}

	private IEnumerator Register()
	{
		WWWForm form = new WWWForm();
		form.AddField("name", nameField.text);
		form.AddField("description", descriptionField.text);

		UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
		yield return webRequest.SendWebRequest();

		if (webRequest.result != UnityWebRequest.Result.Success) {
			Debug.Log(webRequest.error);
		}
		else if (webRequest.downloadHandler.text == "0") {
			Debug.Log("Part registered successfully.");
			GoToMenu();
		}
		else {
			Debug.Log("Part registration failed. Error #" + webRequest.downloadHandler.text);
		}
	}

	public void VerifyInputs()
	{
		submitButton.interactable = nameField.text.Length >= 1 && descriptionField.text.Length >= 1;
	}

	public void GoToMenu()
	{
		SceneManager.LoadScene(0);
	}
}