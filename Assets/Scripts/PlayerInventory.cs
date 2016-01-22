using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour 
{
	public List<GameObject> inventory = new List<GameObject>();
	public Transform inventoryPanel;
	public GameObject prefab;
	public bool hide = true;

	public void addToInventory(ComponentController.Component comp, int count)
	{
		inventory.Add(Instantiate(prefab, transform.position, Quaternion.identity) as GameObject);
		inventory[inventory.Count - 1].GetComponent<ComponentObject>().comp = comp;
		inventory[inventory.Count - 1].GetComponent<ComponentObject>().comp.amount = count;
		inventory[inventory.Count - 1].transform.SetParent(inventoryPanel);
		inventory[inventory.Count - 1].transform.localScale = new Vector3(1,1,1);
		inventory[inventory.Count - 1].GetComponent<ComponentObject>().displayedImage.sprite = comp.image;
		inventory[inventory.Count - 1].GetComponent<ComponentObject>().displayedAmount.text = count.ToString();
		inventory[inventory.Count - 1].name = inventory[inventory.Count - 1].GetComponent<ComponentObject>().comp.name;
	}

	public void displayInventory()
	{
		CanvasGroup IC = this.transform.GetChild(1).GetComponent<CanvasGroup>();
		if (hide == false)
		{
			this.transform.GetChild(1).GetComponent<Animator>().SetTrigger("SlideIn");
			IC.blocksRaycasts = true;
			hide = true;
		}
		else if (hide == true)
		{
			this.transform.GetChild(1).GetComponent<Animator>().SetTrigger("SlideOut");
			IC.blocksRaycasts = false;
			hide = false;
		}
	}
}
