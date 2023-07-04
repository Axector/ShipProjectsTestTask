using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public TMP_Text nameText;
	public TMP_Text descriptionText;

	private int _currentPartId = 1;

	private void Start()
	{
		CallGetNext();
	}

	public void GoToRegister()
	{
		SceneManager.LoadScene(1);
	}

	public void CallGetNext()
	{
		StartCoroutine(GetNext());
	}

	private IEnumerator GetNext()
	{
		WWWForm form = new WWWForm();
		form.AddField("id", _currentPartId);
		UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/sqlconnect/getnext.php", form);
		yield return webRequest.SendWebRequest();
		
		if (webRequest.result != UnityWebRequest.Result.Success) {
			Debug.Log(webRequest.error);
		}
		else if (webRequest.downloadHandler.text[0] == '0') {
			var partInfo = webRequest.downloadHandler.text.Split('\t');
			nameText.text = "Name: " + partInfo[1];
			descriptionText.text = "Description: " + partInfo[2];
			_currentPartId++;
		}
		else if (webRequest.downloadHandler.text[0] == '6' && _currentPartId != 1) {
			_currentPartId = 1;
			CallGetNext();
		}
		else {
			Debug.Log("Failed to get next part. Error #" + webRequest.downloadHandler.text);
		}
	}
}
