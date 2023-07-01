using UnityEngine;

public class PartInfoController : MonoBehaviour, IPartInfo
{
	[SerializeField] private PartInfo partInfo;

	public PartInfo GetPartInfo()
	{
		return partInfo;
	}
}