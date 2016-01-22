using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public bool exclusive = false;

	public void OnPointerEnter(PointerEventData eventData)
	{
		
	}

	public void OnDrop(PointerEventData eventData)
	{
		if ((exclusive && this.transform.childCount == 0) || !exclusive)
		{
			Debug.Log("drop on " + gameObject.name);
			eventData.pointerDrag.GetComponent<Dragable>().currentParent = this.transform;
		}

	}

	public void OnPointerExit(PointerEventData eventData)
	{
		
	}
}
