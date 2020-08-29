using Definitions.People;
using People;
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

        public List<Sprite> rankSprites;

        private Teams teams;

        private void Start() {
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
                TeamMember member = team.teamMembers[0];
                teamPanel.Find("Member1RankImage").GetComponent<Image>().sprite = rankSprites[member.rank];
                teamPanel.Find("Member1Details").GetComponent<Text>().text = PeopleUtil.getRankDetails(member.rank).abbreviation + "\n" + member.forename + "\n" + member.surname;

                //setting details for member 2
                if(team.teamMembers.Count > 1) {
                    member = team.teamMembers[1];
                    teamPanel.Find("Member2RankImage").GetComponent<Image>().sprite = rankSprites[member.rank];
                    teamPanel.Find("Member2Details").GetComponent<Text>().text = PeopleUtil.getRankDetails(member.rank).abbreviation + "\n" + member.forename + "\n" + member.surname;
                }

                //setting details for member 3
                if (team.teamMembers.Count > 2) {
                    member = team.teamMembers[2];
                    teamPanel.Find("Member3RankImage").GetComponent<Image>().sprite = rankSprites[member.rank];
                    teamPanel.Find("Member3Details").GetComponent<Text>().text = PeopleUtil.getRankDetails(member.rank).abbreviation + "\n" + member.forename + "\n" + member.surname;
                }

                //setting details for member 4
                if (team.teamMembers.Count > 3) {
                    member = team.teamMembers[3];
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
            Debug.Log("HIT");
            foreach(Transform transform in teamBreakdownView) {
                Destroy(transform.gameObject);
            }

            foreach(TeamMember teamMember in team.teamMembers) {
                createTeamBreakdownPanel(teamMember);
            }
        }

        private void createTeamBreakdownPanel(TeamMember teamMember) {
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

            //add a new listener to the selection button for the panel which calls the onMissionActivated function
            //passing in the mission details for this mission
            //memberPanel.Find("SelectButton").GetComponent<Button>().onClick.AddListener(() => { onMissionActivated(missionDetails, availablePanel.gameObject); });
        }
    }
}