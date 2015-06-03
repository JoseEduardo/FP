using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DragTitleBar : MonoBehaviour, IPointerDownHandler, IDragHandler {
	
	private Vector2 originalLocalPointerPosition;
	private Vector3 originalPanelLocalPosition;
	private RectTransform panelRectTransform;
	private RectTransform parentRectTransform;
	
	//object that is going to be moved
	public GameObject g;
	
	void Awake () {
		panelRectTransform = g.transform as RectTransform;
		parentRectTransform = panelRectTransform.parent as RectTransform;
	}
	
	public void OnPointerDown (PointerEventData data) {
		originalPanelLocalPosition = panelRectTransform.localPosition;
		RectTransformUtility.ScreenPointToLocalPointInRectangle (parentRectTransform, data.position, data.pressEventCamera, out originalLocalPointerPosition);
	}
	
	public void OnDrag (PointerEventData data) {
		if (panelRectTransform == null || parentRectTransform == null)
			return;
		
		Vector2 localPointerPosition;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (parentRectTransform, data.position, data.pressEventCamera, out localPointerPosition)) {
			Vector3 offsetToOriginal = localPointerPosition - originalLocalPointerPosition;
			panelRectTransform.localPosition = originalPanelLocalPosition + offsetToOriginal;
		}
		
	}
	
	
}