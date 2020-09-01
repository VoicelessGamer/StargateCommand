using Definitions.People;
using People;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menus {
    public class TeamMemberSelectionMenu : MonoBehaviour {

        public Transform teamMemberView;

        public GameObject teamMemberPanel;

        public List<Sprite> rankSprites;

        private Action<string> returnAction;

        public void setupMenu(EmployedMembers employedMembers, Action<string> returnAction) {
            this.returnAction = returnAction;

            foreach (string memberKey in employedMembers.members.Keys) {
                createTeamBreakdownPanel(memberKey, employedMembers.members[memberKey]);
            }
        }
        private GameObject createTeamBreakdownPanel(string memberKey, TeamMember teamMember) {
            //instantiating the new team member panel and adding to the view
            Transform memberPanel = Instantiate(teamMemberPanel, Vector3.zero, Quaternion.identity).transform;
            memberPanel.SetParent(teamMemberView, false);

            //Set the panel title to something meaningful
            string name = PeopleUtil.getRankDetails(teamMember.rank).abbreviation + ". " + teamMember.forename + " " + teamMember.surname;
            memberPanel.Find("Name").GetComponent<Text>().text = name;

            //tting the rank image on the panel
            memberPanel.Find("RankImage").GetComponent<Image>().sprite = rankSprites[teamMember.rank];

            //set the primary weapon text on the panel
            memberPanel.Find("PrimaryWeapon").GetComponent<Text>().text = teamMember.primaryWeapon.name + "\n" + teamMember.primaryWeapon.minimumDamage + " - " + teamMember.primaryWeapon.maximumDamage;

            //set the secondary weapon text on the panel
            memberPanel.Find("SecondaryWeapon").GetComponent<Text>().text = teamMember.secondaryWeapon.name + "\n" + teamMember.secondaryWeapon.minimumDamage + " - " + teamMember.secondaryWeapon.maximumDamage;

            //set the primary weapon text on the panel
            memberPanel.Find("ThrowableWeapon").GetComponent<Text>().text = teamMember.throwableWeapon.name + "\n" + teamMember.throwableWeapon.minimumDamage + " - " + teamMember.throwableWeapon.maximumDamage;

            //set the secondary weapon text on the panel
            memberPanel.Find("Armour").GetComponent<Text>().text = teamMember.armour.name + "\n" + teamMember.armour.minimumDamage + " - " + teamMember.armour.maximumDamage;

            //set the onclick listener for the primary weapon allowing it to be swapped
            memberPanel.Find("SelectButton").GetComponent<Button>().onClick.AddListener(() => { onMemberSelected(memberKey); });

            //return the newly created panel object
            return memberPanel.gameObject;
        }

        public void onMemberSelected(string memberKey) {
            returnAction(memberKey);
        }
    }
}