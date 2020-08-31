using Definitions.People;
using Definitions.Weapons;
using People;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menus {
    public class AllTeamsMenu : MonoBehaviour {

        public Transform teamScrollView;

        public Transform teamBreakdownView;

        public GameObject teamOverviewPanel;
        public GameObject lockedTeamOverviewPanel;

        public GameObject teamMemberPanel;

        public GameObject itemSwapMenu;

        public Transform canvas;

        public List<Sprite> rankSprites;

        private Teams teams;

        private EmployedMembers employedMembers;

        //member key mapped to a created panel
        private Dictionary<string, GameObject> mappedPanels;

        private void Start() {
            employedMembers = PeopleUtil.getEmployedMembers();
            mappedPanels = new Dictionary<string, GameObject>();
            teams = PeopleUtil.getTeams();

            foreach(int teamIndex in teams.teams.Keys) {
                Team team = teams.teams[teamIndex];

                createTeamPanel(teamIndex, team);
            }
        }

        private void createTeamPanel(int teamIndex, Team team) {
            //instantiating the new team overview panel and adding to the view
            Transform teamPanel;

            if(!team.locked) {
                teamPanel = Instantiate(teamOverviewPanel, Vector3.zero, Quaternion.identity).transform;

                //setting details for member 1
                TeamMember member = employedMembers.members[team.teamMemberKeys[0]];
                teamPanel.Find("Member1RankImage").GetComponent<Image>().sprite = rankSprites[member.rank];
                teamPanel.Find("Member1Details").GetComponent<Text>().text = PeopleUtil.getRankDetails(member.rank).abbreviation + "\n" + member.forename + "\n" + member.surname;

                //setting details for member 2
                if(team.teamMemberKeys.Count > 1) {
                    member = employedMembers.members[team.teamMemberKeys[1]];
                    teamPanel.Find("Member2RankImage").GetComponent<Image>().sprite = rankSprites[member.rank];
                    teamPanel.Find("Member2Details").GetComponent<Text>().text = PeopleUtil.getRankDetails(member.rank).abbreviation + "\n" + member.forename + "\n" + member.surname;
                }

                //setting details for member 3
                if (team.teamMemberKeys.Count > 2) {
                    member = employedMembers.members[team.teamMemberKeys[2]];
                    teamPanel.Find("Member3RankImage").GetComponent<Image>().sprite = rankSprites[member.rank];
                    teamPanel.Find("Member3Details").GetComponent<Text>().text = PeopleUtil.getRankDetails(member.rank).abbreviation + "\n" + member.forename + "\n" + member.surname;
                }

                //setting details for member 4
                if (team.teamMemberKeys.Count > 3) {
                    member = employedMembers.members[team.teamMemberKeys[3]];
                    teamPanel.Find("Member4RankImage").GetComponent<Image>().sprite = rankSprites[member.rank];
                    teamPanel.Find("Member4Details").GetComponent<Text>().text = PeopleUtil.getRankDetails(member.rank).abbreviation + "\n" + member.forename + "\n" + member.surname;
                }

                //add a new listener to the selection button for the panel which calls the onMissionActivated function
                //passing in the mission details for this mission
                Button selectButton = teamPanel.Find("SelectButton").GetComponent<Button>();
                selectButton.onClick.AddListener(() => { onDisplayTeamBreakdown(teamIndex, team); });
                selectButton.interactable = true;

            } else {
                teamPanel = Instantiate(lockedTeamOverviewPanel, Vector3.zero, Quaternion.identity).transform;
            }
            //set the panel parent
            teamPanel.SetParent(teamScrollView, false);

            //Set the team name
            teamPanel.Find("TeamName").GetComponent<Text>().text = "SG-" + teamIndex;
        }

        public void onDisplayTeamBreakdown(int teamIndex, Team team) {
            foreach(Transform transform in teamBreakdownView) {
                Destroy(transform.gameObject);
            }

            mappedPanels = new Dictionary<string, GameObject>();

            foreach (string memberKey in team.teamMemberKeys) {
                mappedPanels.Add(memberKey, createTeamBreakdownPanel(memberKey, employedMembers.members[memberKey]));
            }
        }

        private GameObject createTeamBreakdownPanel(string memberKey, TeamMember teamMember) {
            //instantiating the new team member panel and adding to the view
            Transform memberPanel = Instantiate(teamMemberPanel, Vector3.zero, Quaternion.identity).transform;
            memberPanel.SetParent(teamBreakdownView, false);

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