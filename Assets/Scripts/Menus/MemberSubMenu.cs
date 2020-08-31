using UnityEngine;
using System.Collections.Generic;
using Definitions.People;
using Weapons;
using Definitions.Weapons;
using People;
using UnityEngine.UI;
using Core;
using System;

namespace Menus {
    public class MemberSubMenu : MonoBehaviour {

        public GameObject teamMemberPanel;

        public Transform teamMemberView;

        public List<Sprite> rankSprites;

        public GameObject itemSwapMenu;

        public Transform canvas;

        private EmployedMembers employedMembers;

        //member key mapped to a created panel
        private Dictionary<string, GameObject> mappedPanels;

        private void Start() {
            initialiseEmployedMembers();
        }

        private void initialiseEmployedMembers() {
            employedMembers = PeopleUtil.getEmployedMembers();
            mappedPanels = new Dictionary<string, GameObject>();

            foreach (string memberKey in employedMembers.members.Keys) {
                mappedPanels.Add(memberKey, createTeamMemberPanel(memberKey, employedMembers.members[memberKey]));
            }
        }

        public void generateNewTeamMember() {

            WeaponDefinition primary = WeaponUtil.getWeapon("M16A3", RarityObject.Rarity.COMMON);
            
            WeaponDefinition secondary = WeaponUtil.getWeapon("M9A1", RarityObject.Rarity.UNCOMMON);

            TeamMember teamMember = new TeamMember(UnityEngine.Random.Range(0, 20), "Jack", "O'Neil", primary, secondary, primary, secondary);

            string memberId = "ID-" + DateTime.UtcNow.ToString() + UnityEngine.Random.Range(0, 1000000000);

            employedMembers.members.Add(memberId, teamMember);

            PeopleUtil.saveNewTeamMember(memberId, teamMember);

            //Debug.Log(teamMember.ToString());

            mappedPanels.Add(memberId, createTeamMemberPanel(memberId, teamMember));
        }

        public GameObject createTeamMemberPanel(string memberKey, TeamMember teamMember) {
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

            //set the onclick listener for the primary weapon allowing it to be swapped
            memberPanel.Find("PrimarySelectButton").GetComponent<Button>().onClick.AddListener(() => { onPrimaryWeaponSelect(memberKey); });

            //set the onclick listener for the secondary weapon allowing it to be swapped
            memberPanel.Find("SecondarySelectButton").GetComponent<Button>().onClick.AddListener(() => { onSecondaryWeaponSelect(memberKey); });

            //return the newly created panel object
            return memberPanel.gameObject;
        }

        public void updateTeamMemberPanel(string memberKey) {
            Transform memberPanel = mappedPanels[memberKey].transform;
            TeamMember teamMember = employedMembers.members[memberKey];

            //set the primary weapon text on the panel
            memberPanel.Find("PrimaryWeapon").GetComponent<Text>().text = teamMember.primaryWeapon.name + "\n" + teamMember.primaryWeapon.minimumDamage + " - " + teamMember.primaryWeapon.maximumDamage;

            //set the secondary weapon text on the panel
            memberPanel.Find("SecondaryWeapon").GetComponent<Text>().text = teamMember.secondaryWeapon.name + "\n" + teamMember.secondaryWeapon.minimumDamage + " - " + teamMember.secondaryWeapon.maximumDamage;

            //set the primary weapon text on the panel
            memberPanel.Find("ThrowableWeapon").GetComponent<Text>().text = teamMember.throwableWeapon.name + "\n" + teamMember.throwableWeapon.minimumDamage + " - " + teamMember.throwableWeapon.maximumDamage;

            //set the secondary weapon text on the panel
            memberPanel.Find("Armour").GetComponent<Text>().text = teamMember.armour.name + "\n" + teamMember.armour.minimumDamage + " - " + teamMember.armour.maximumDamage;

        }

        public void onPrimaryWeaponSelect(string memberKey) {
            //create the item swap panel
            GameObject itemSwapView = Instantiate(itemSwapMenu);
            itemSwapView.transform.SetParent(canvas, false);

            //get the team member definition
            TeamMember teamMember = employedMembers.members[memberKey];

            //create an action that is performed once the swap weapon has been chosen
            Action<WeaponDefinition> swapPrimary = (weaponDefinition) => {
                //update the weapon definition on the team member
                teamMember.primaryWeapon = weaponDefinition;
                //update the view
                updateTeamMemberPanel(memberKey);
                //destroy the item swap panel
                Destroy(itemSwapView);
            };

            //setup the panels in the item swap view
            itemSwapView.GetComponent<ItemSwapMenu>().setupPrimaryMenu(teamMember.primaryWeapon, swapPrimary);
        }

        public void onSecondaryWeaponSelect(string memberKey) {
            //create the item swap panel
            GameObject itemSwapView = Instantiate(itemSwapMenu);
            itemSwapView.transform.SetParent(canvas, false);

            //get the team member definition
            TeamMember teamMember = employedMembers.members[memberKey];

            //create an action that is performed once the swap weapon has been chosen
            Action<WeaponDefinition> swapSecondary = (weaponDefinition) => {
                //update the weapon definition on the team members
                teamMember.secondaryWeapon = weaponDefinition;
                //update the view
                updateTeamMemberPanel(memberKey);
                //destroy the item swap panel
                Destroy(itemSwapView);
            };

            //setup the panels in the item swap view
            itemSwapView.GetComponent<ItemSwapMenu>().setupSecondaryMenu(teamMember.secondaryWeapon, swapSecondary);
        }
    }
}