using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ComponentController : MonoBehaviour 
{

	List<Component> componentList = new List<Component>();

	public class Component
	{
		public string type;
		public string name;
		public int amount;
		public bool canConnectUp;
		public bool canConnectDown;
		public bool canConnectRight;
		public bool canConnectLeft;
		public Sprite image;

		public Component(string t, string n, bool up, bool down, bool right, bool left, Sprite img)
		{
			type = t;
			name = n;
			canConnectUp = up;
			canConnectDown = down;
			canConnectRight = right;
			canConnectLeft = left;
			image = img;
		}

		public Component()
		{}
	}

	public class Battery : Component
	{
		public string positiveTerminal;
		public string negativeTerminal;

		public Battery(string pos, string neg)
		{
			type = "Battery";
			positiveTerminal = pos;
			negativeTerminal = neg;
		}

		public Battery(string pos, string neg, string t, string n, bool up, bool down, bool right, bool left, Sprite img) : base(t,  n,  up,  down,  right,  left, img)
		{
			type = "Battery";
			positiveTerminal = pos;
			negativeTerminal = neg;
		}
	}

	public class Resistor : Component
	{
		public float maxResistance;
		public float minResistance;
		public float powerRating;
		public float maximumAllowedVoltage;
		public float tolerance;

		public Resistor(float maxRes, float minRes, float mav, float tol)
		{
			maxResistance = maxRes;
			minResistance = minRes;
			maximumAllowedVoltage = mav;
			tolerance = tol;
		}

		public Resistor(float maxRes, float minRes, float mav, float tol, string t, string n, bool up, bool down, bool right, bool left, Sprite img) : base(t,  n,  up,  down,  right,  left, img)
		{
			maxResistance = maxRes;
			minResistance = minRes;
			maximumAllowedVoltage = mav;
			tolerance = tol;
		}

		public Resistor(string t, string n, bool up, bool down, bool right, bool left, Sprite img) : base(t,  n,  up,  down,  right,  left, img)
		{

		}
	}

	public void Start()
	{
		componentList.Add(new Resistor("Resistor", "LR_Resistor", false, false, true, true, Resources.Load <Sprite> ("Sprites/LR_Resistor")));
		componentList.Add(new Battery("Right", "Down", "Battery", "RD_Battery", false, true, true, false, Resources.Load <Sprite> ("Sprites/RD_Battery")));
		componentList.Add(new Component("Wire", "LD_Wire", false, true, false, true, Resources.Load<Sprite>("Sprites/LD_Wire")));
		componentList.Add(new Component("Wire", "LU_Wire", true, false, false, true, Resources.Load<Sprite>("Sprites/LU_Wire")));
		componentList.Add(new Component("Wire", "RD_Wire", false, true, true, false, Resources.Load<Sprite>("Sprites/RD_Wire")));
		componentList.Add(new Component("Wire", "RU_Wire", true, false, true, false, Resources.Load<Sprite>("Sprites/RU_Wire")));
		componentList.Add(new Component("Wire", "RUD_Wire", true, true, true, false, Resources.Load<Sprite>("Sprites/RUD_Wire")));
		componentList.Add(new Component("Wire", "LUD_Wire", true, true, false, true, Resources.Load<Sprite>("Sprites/LUD_Wire")));
		componentList.Add(new Component("Wire", "RLD_Wire", false, true, true, true, Resources.Load<Sprite>("Sprites/RLD_Wire")));
		componentList.Add(new Component("Wire", "RLU_Wire", true, false, true, true, Resources.Load<Sprite>("Sprites/RLU_Wire")));
		componentList.Add(new Component("Wire", "RLUD_Wire", true, true, true, true, Resources.Load<Sprite>("Sprites/RLUD_Wire")));
		componentList.Add(new Component("Wire", "RL_Wire", false, false, true, true, Resources.Load<Sprite>("Sprites/RL_Wire")));
		componentList.Add(new Component("Wire", "UD_Wire", true, true, false, false, Resources.Load<Sprite>("Sprites/UD_Wire")));


		loadLevel(1);
	}

	public void loadLevel(int levelNumber)
	{
		Debug.Log("loadLevel #" + levelNumber);
		switch (levelNumber)
		{
			case 1:
				{
					for (int i = 0; i < componentList.Count; i++)
					{
						Debug.Log("For loop in case 1");
						GameObject.Find("Inventory Canvas").GetComponent<PlayerInventory>().addToInventory(componentList[i], i + 2);
					}
				}
				break;
			default:
				break;
		}
	}
}
