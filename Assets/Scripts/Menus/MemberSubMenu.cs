using UnityEngine;
using System.Collections.Generic;
using Definitions.People;
using Weapons;
using Definitions.Weapons;
using People;
using UnityEngine.UI;
using Core;

namespace Menus {
    public class MemberSubMenu : MonoBehaviour {

        public GameObject teamMemberPanel;

        public Transform teamMemberView;

        public List<Sprite> rankSprites;

        private void Start() {
            initialiseEmployedMembers();
        }

        private void initialiseEmployedMembers() {
            EmployedMembers employedMembers = PeopleUtil.getEmployedMembers();

            foreach(TeamMember member in employedMembers.members) {
                createTeamMemberPanel(member);
            }
        }

        public void generateNewTeamMember() {

            WeaponDefinition primary = WeaponUtil.getWeapon("M16A3", RarityObject.Rarity.COMMON);
            
            WeaponDefinition secondary = WeaponUtil.getWeapon("M9A1", RarityObject.Rarity.UNCOMMON);

            TeamMember teamMember = new TeamMember(Random.Range(0, 20), "Jack", "O'Neil", primary, secondary, primary, secondary);

            PeopleUtil.saveNewTeamMember(teamMember);

            //Debug.Log(teamMember.ToString());

            createTeamMemberPanel(teamMember);
        }

        public void createTeamMemberPanel(TeamMember teamMember) {
            //instantiating the new team member panel and adding to the view
            Transform memberPanel = Instantiate(teamMemberPanel, Vector3.zero, Quaternion.identity).transform;
            memberPanel.SetParent(teamMemberView, false);

            //Set the panel title to something meaningful
            string name = PeopleUtil.getRankDetails(teamMember.rank).abbreviation + ". " + teamMember.forename + " " + teamMember.surname;
            memberPanel.Find("Name").GetComponent<Text>().text = name;

            //setting the rank image on the panel
            memberPanel.Find("RankImage").GetComponent<Image>().sprite = rankSprites[teamMember.rank];

            //set the primary weapon text on the panel
            memberPanel.Find("PrimaryWeapon").GetComponent<Text>().text = teamMember.primaryWeapon.name + "\n" + teamMember.primaryWeapon.minimumDamage + " - " + teamMember.primaryWeapon.maximumDamage;

            //set the secondary weapon text on the panel
            memberPanel.Find("SecondaryWeapon").GetComponent<Text>().text = teamMember.secondaryWeapon.name + "\n" + teamMember.secondaryWeapon.minimumDamage + " - " + teamMember.secondaryWeapon.maximumDamage;

            //set the primary weapon text on the panel
            memberPanel.Find("ThrowableWeapon").GetComponent<Text>().text = teamMember.throwableWeapon.name + "\n" + teamMember.throwableWeapon.minimumDamage + " - " + teamMember.throwableWeapon.maximumDamage;

            //set the secondary weapon text on the panel
            memberPanel.Find("Armour").GetComponent<Text>().text = teamMember.armour.name + "\n" + teamMember.armour.minimumDamage + " - " + teamMember.armour.maximumDamage;

            //add a new listener to the selection button for the panel which calls the onMissionActivated function
            //passing in the mission details for this mission
            //memberPanel.Find("SelectButton").GetComponent<Button>().onClick.AddListener(() => { onMissionActivated(missionDetails, availablePanel.gameObject); });
        }
    }
}