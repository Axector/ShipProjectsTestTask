using TMPro;
using UnityEngine;

public class DescriptionOverlay : MonoBehaviour, IInfoOverlay
{
	[SerializeField] private GameObject textWrapper;
	[SerializeField] private TMP_Text nameTmpText;
	[SerializeField] private TMP_Text descriptionTmpText;
	[SerializeField] private float verticalPadding;

	private RectTransform _rectTransform;

	private void Start()
	{
		HideInfo();
	}

	public void HideInfo()
	{
		textWrapper.SetActive(false);
	}

	public void ShowInfo(PartInfo partInfo)
	{
		textWrapper.SetActive(true);

		SetText(partInfo);
		ResizeOverlay();
	}

	private void SetText(PartInfo partInfo)
	{
		nameTmpText.text = partInfo.name;
		descriptionTmpText.text = partInfo.description;
	}

	private void ResizeOverlay()
	{
		if (!_rectTransform) {
			_rectTransform = GetComponent<RectTransform>();
		}

		float textHeight = nameTmpText.preferredHeight + descriptionTmpText.preferredHeight + verticalPadding * 2;
		_rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x, textHeight);
	}
}