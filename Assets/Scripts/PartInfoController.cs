using UnityEngine;

public struct PartInfo
{
	public string name;
	public string description;

	public PartInfo(string name, string description)
	{
		this.name = name;
		this.description = description;
	}
};

public class PartInfoController : MonoBehaviour, IPartInfo
{
	[SerializeField] private string partName;
	[SerializeField] private string partDescription;

	private PartInfo _partInfo;

	private void Start()
	{
		_partInfo = new PartInfo(partName, partDescription);
	}

	public PartInfo GetPartInfo()
	{
		return _partInfo;
	}
}