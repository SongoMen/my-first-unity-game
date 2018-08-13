using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillTree : MonoBehaviour 
{
	private Player ps;
	private bool showTree;
	private List<MySkill> listOfSkills;
	private gameMaster gm;


	void Start () 
	{
		ps = gameObject.GetComponent<Player> ();
		showTree = false;
		listOfSkills = new List<MySkill>();

		MySkill HP1 = new MySkill ( "HP I", 1, "maxHealth", 6);
		MySkill HP2 = new MySkill ( "HP II", 2, "maxHealth", 7);
		MySkill HP3 = new MySkill ( "HP III", 3, "maxHealth", 8);
		HP2.addRequirement (HP1);
        HP3.addRequirement(HP2);
		listOfSkills.Add (HP1);
		listOfSkills.Add (HP2);
		listOfSkills.Add (HP3);
	}
	
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.C)) {
			showTree = !showTree;
		}
	}

	void OnGUI()
	{
		if (showTree) {
			for(int i = 0 ; i < listOfSkills.Count ; i++) {
				MySkill skill = listOfSkills[i];
				if(skill.isActive) {
					GUI.color = skill.btnOn;
				} else {
					GUI.color = skill.btnOff;
				}

				if (GUI.Button (skill.position, skill.label)) {
					if(skill.isAvailable() && (ps.skillPoint >= skill.skillCost) && !skill.isActive) {
						ps.skillPoint -= skill.skillCost;
						ps.changePlayerStat(skill.statToChange, skill.statValue);
						skill.isActive = true;
					}
				}
			}
		}
	}
}
