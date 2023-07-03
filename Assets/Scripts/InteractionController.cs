using UnityEngine;

public class InteractionController : MonoBehaviour
{
	[SerializeField] private float mouseRayCastDistance = 1000f;
	[SerializeField] private GameObject infoOverlayGameObject;

	private IInfoOverlay _infoOverlay;
	private Camera _mainCamera;
	private Ray _ray;

	private void Start()
	{
		_mainCamera = Camera.main;
		_infoOverlay = infoOverlayGameObject.GetComponent<IInfoOverlay>();
	}

	private void Update()
	{
		// Do raycast from mouse position to world on left mouse button click
		if (Input.GetMouseButtonDown(0)) {
			// Hide info overlay before showing it,
			// so if there will be nothing to show, overlay will not appear
			_infoOverlay.HideInfo();

			_ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(_ray, out var raycastHit, mouseRayCastDistance)) {
				if (raycastHit.transform.TryGetComponent<IPartInfo>(out var partInfo)) {
					_infoOverlay.ShowInfo(partInfo.GetPartInfo());
				}
			}
		}
	}
}