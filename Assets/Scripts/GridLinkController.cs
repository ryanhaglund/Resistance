using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GridLinkController : MonoBehaviour 
{
	public List<GameObject> gridSlots = new List<GameObject>();
    public GameObject gridObject;
	public int gridSize;
	private int gridWidth;

	void Start()
	{
		gridWidth = Mathf.RoundToInt(Mathf.Sqrt(gridSize));
		GetComponent<GridLayoutGroup>().constraintCount = gridWidth;
        for (int i = 0; i < gridSize; i++)
        {
			gridSlots.Add(Instantiate(gridObject, Vector3.zero, Quaternion.identity) as GameObject);
			gridSlots[i].name = "Slot" + i;
			gridSlots[i].transform.SetParent(this.transform, false);
			gridSlots[i].GetComponentInChildren<Text>().text = i.ToString();
        }

		Debug.Log ("gridsize:"+gridSlots.Count+"  GridWidth:"+gridWidth);
		for (int j = 0; j < gridSlots.Count; j++)
		{
			//set top
			if (j < gridWidth)
			{
				
			}
			else
			{
				//Debug.Log(j);
				gridSlots[j].GetComponent<GridObjectController>().up = gridSlots[(j - gridWidth)];
			}

			//set bottom
			if (j > ((gridSlots.Count - 1) - gridWidth))
			{
				
			}
			else
			{
				gridSlots[j].GetComponent<GridObjectController>().down = gridSlots[(j + gridWidth)];
			}

			//set right
			bool onRightEdge = false;
			for (int k = 0; k < gridWidth+1; k++)
			{
				if (j == ((gridWidth * k) - 1))
				{
					Debug.Log(j);
					onRightEdge = true;
				}
			}
			if (!onRightEdge)
			{
				gridSlots[j].GetComponent<GridObjectController>().right = gridSlots[(j + 1)];
			}

			//set left
			bool onLeftEdge = false;
			for (int k = 0; k < gridWidth+1; k++)
			{
				if (j == (gridWidth * k))
				{
					Debug.Log(j);
					onLeftEdge = true;
				}
			}
			if (!onLeftEdge)
			{
				gridSlots[j].GetComponent<GridObjectController>().left = gridSlots[(j - 1)];
			}
		}
	}

	void whoAmINextTo(int index)
	{
		if (index < gridWidth)
		{
		    
		}
	}
}
//i make changes now.
