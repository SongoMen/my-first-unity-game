using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MySkill {

	public Rect position { get; set;}
	public string label { get; set;}
	public string statToChange { get; set; }
	public float statValue { get; set; }
	public int skillCost { get; set; }
	public bool isActive { get; set; }


	public Color btnOn { get; set; }
	public Color btnOff { get; set; }

	public List<MySkill> requirements { get; set; }

	public MySkill(string l, int sc, string sn, float sv)
	{
		label = l;
		skillCost = sc;
		isActive = false;
		requirements = new List<MySkill> ();
		btnOn = Color.red;
		btnOff = Color.yellow;
		statToChange = sn;
		statValue = sv;
	}

	public void addRequirement(MySkill skill)
	{
		requirements.Add (skill);
	}


	public bool isAvailable() 
	{
		for(int i = 0 ; i < requirements.Count ; i++) {
			if(!requirements[i].isActive) {
				return false;
			}
		}
		return true;
	}

}
