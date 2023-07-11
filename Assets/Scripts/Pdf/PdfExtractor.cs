using System.Collections;
using UnityEngine;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using SFB;
using TMPro;
using UnityEngine.Networking;

public class PdfExtractor : MonoBehaviour
{
	[SerializeField] private TMP_Text pdfContentText;

	public void SelectFile()
	{
		string[] paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", "pdf", false);
		if (paths.Length > 0) {
			StartCoroutine(OutputRoutineOpen(paths[0]));
		}
	}

	private IEnumerator OutputRoutineOpen(string url)
	{
		UnityWebRequest request = UnityWebRequest.Get(url);
		yield return request.SendWebRequest();

		if (request.result != UnityWebRequest.Result.Success) {
			Debug.Log("UnityWebRequest error: " + request.error);
		}
		else {
			pdfContentText.text = ReadPdf(url);
		}
	}

	private string ReadPdf(string path)
	{
		PdfReader reader = new PdfReader(path);

		string text = "";
		for (int page = 1; page <= reader.NumberOfPages; page++) {
			text += PdfTextExtractor.GetTextFromPage(reader, page);
		}

		reader.Close();
		return text;
	}
}