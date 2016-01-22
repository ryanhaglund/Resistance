using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BandController : MonoBehaviour 
{
	public Image Band1Color;
	public Image Band2Color;
	public Image Band3Color;
	public Image Band4Color;

	void Start()
	{
		setBandColor(8900, 10f);
	}

	public void setBandColor(int resistance, float tolerance)
	{
		int band1;
		int band2;
		int band3;
		int band4;
		int loops = 0;

		band1 = Mathf.Abs(resistance);
		while (band1 >= 10)
		{
			band1 /= 10;
			loops++;
		}
		band3 = loops-1;
		Debug.Log("Band1: " + band1);
		band2 = Mathf.Abs(resistance) - band1 * (int)(Mathf.Pow(10, loops));
		while (band2 >= 10)
		{
			band2 /= 10;
		}
		Debug.Log("Band2: " + band2);
		Debug.Log("Band3: " + band3);
		if (tolerance == 1f)
		{
			band4 = 1;
		}
		else if (tolerance == 2f)
		{
			band4 = 2;
		}
		else if (tolerance == 0.5f)
		{
			band4 = 5;
		}
		else if (tolerance == 0.25f)
		{
			band4 = 6;
		}
		else if (tolerance == 0.10f)
		{
			band4 = 7;
		}
		else if (tolerance == 0.05f)
		{
			band4 = 8;
		}
		else if (tolerance == 5f)
		{
			band4 = 10;
		}
		else if (tolerance == 10f)
		{
			band4 = 11;
		}
		else
		{
			band4 = -1;
		}
		Debug.Log("Band4: " + band4);

		Debug.Log(Band1Color.color);
		//find and color each band
		Band1Color.color = getBandColor(band1);
		Band2Color.color = getBandColor(band2);
		Band3Color.color = getBandColor(band3);
		Band4Color.color = getBandColor(band4);
	}

	public Color getBandColor(int bandValue)
	{
		Color colorVector;
		switch (bandValue)
		{
			case 0:
				colorVector = convertColorCode(0, 0, 0, 225);
				break;
			case 1:
				colorVector = convertColorCode(112, 83, 61, 225);
				break;
			case 2:
				colorVector = convertColorCode(236,33,38,255);
				break;
			case 3:
				colorVector = convertColorCode(246,128,38,255);
				break;
			case 4:
				colorVector = convertColorCode(255,255,6,255);
				break;
			case 5:
				colorVector = convertColorCode(8,164,80,255);
				break;
			case 6:
				colorVector = convertColorCode(5,171,238,255);
				break;
			case 7:
				colorVector = convertColorCode(108,47,144,255);
				break;
			case 8:
				colorVector = convertColorCode(148,148,148,255);
				break;
			case 9:
				colorVector = convertColorCode(255,255,255,255);
				break;
			case 10:
				colorVector = convertColorCode(208,158,72,255);
				break;
			case 11:
				colorVector = convertColorCode(200,200,200,255);
				break;
			default:
				colorVector = convertColorCode(0, 0, 0, 0);
				break;
		}
		return colorVector;
	}

	public Color convertColorCode(float x, float y, float z, float w)
	{
		Debug.Log("hit");	
		return new Color(x/255f, y/255f, z/255f, w/255f);
	}

	//Black(0,0,0,255)
	//Brown(112,83,61,255)
	//Red(236,33,38,255)
	//Orange(246,128,38,255)
	//Yellow(255,255,6,255)
	//Green(8,164,80,255)
	//Blue(5,171,238,255)
	//Purple(108,47,144,255)
	//Grey(148,148,148,255)
	//White(255,255,255,255)
	//Gold(208,158,72,255)
	//Silver(200,200,200,255)
}
