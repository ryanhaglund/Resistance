using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
	public Transform inventoryCanvas;
	public Transform currentParent = null;

	void Start()
	{
		inventoryCanvas = GameObject.Find("Inventory Canvas").transform;
	}

	public void OnBeginDrag (PointerEventData eventData)
	{
		Debug.Log("begin dragging");
		currentParent = this.transform.parent;
		if (currentParent == inventoryCanvas.GetChild(1))
		{
			GameObject clone = Instantiate(this.gameObject, transform.position, Quaternion.identity) as GameObject;
			int index = this.transform.GetSiblingIndex();
			clone.transform.SetParent(inventoryCanvas.GetChild(1));
			clone.transform.localScale = new Vector3(1, 1, 1);
			clone.GetComponent<Dragable>().changeIndex(index);
			clone.GetComponent<ComponentObject>().comp = this.gameObject.GetComponent<ComponentObject>().comp;
			clone.name = this.gameObject.GetComponent<ComponentObject>().comp.name;
			GetComponent<ComponentObject>().displayedAmount.text = "";
			clone.GetComponent<ComponentObject>().comp.amount -= 1;
			clone.GetComponent<ComponentObject>().displayedAmount.text = clone.GetComponent<ComponentObject>().comp.amount.ToString();
			if (clone.GetComponent<ComponentObject>().comp.amount == 0)
			{
				Destroy(clone);
			}
			//Debug.Log(clone.transform.GetSiblingIndex());	
		}
		this.transform.SetParent(inventoryCanvas);
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		//Debug.Log("Dragging");
		this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(eventData.position).x, Camera.main.ScreenToWorldPoint(eventData.position).y, 10);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		Debug.Log("End dragging");
		if (currentParent == inventoryCanvas.GetChild(1))
		{
			bool found = false;
			for (int i = 0; i < inventoryCanvas.GetChild(1).childCount; i++)
			{
				if (this.name == inventoryCanvas.GetChild(1).GetChild(i).name)
				{
					inventoryCanvas.GetChild(1).GetChild(i).GetComponent<ComponentObject>().comp.amount += 1;
					inventoryCanvas.GetChild(1).GetChild(i).GetComponent<ComponentObject>().displayedAmount.text = inventoryCanvas.GetChild(1).GetChild(i).GetComponent<ComponentObject>().comp.amount.ToString();
					Destroy(gameObject);
					found = true;
				}
			}
			if (!found)
			{
				gameObject.GetComponent<ComponentObject>().comp.amount += 1;
				gameObject.GetComponent<ComponentObject>().displayedAmount.text = "1";
			}
		}
		this.transform.SetParent(currentParent);
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void changeIndex(int index)
	{
		this.transform.SetSiblingIndex(index);
		//Debug.Log(this.transform.name + " is in index position: " + this.transform.GetSiblingIndex());
		//Debug.Log("Parent:"+this.transform.GetComponentInParent<Transform>().name);
	}
}
