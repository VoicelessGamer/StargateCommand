using UnityEngine;
using System.Collections.Generic;
using Definitions.People;
using Generation;
using Definitions.Items;
using People;
using UnityEngine.UI;

namespace Missions {
    public class TeamManager : MonoBehaviour {

        public GameObject teamMemberPanel;

        public Transform teamMemberView;

        public List<Sprite> rankSprites;

        private void Start() {

        }

        public void generateNewTeamMember() {

            RandomLootGenerator randomLootGenerator = new RandomLootGenerator();

            WeaponDefinition primaryDefinition = randomLootGenerator.getWeaponItem("ballistic_main_weapons", "assault_rifles", RarityObject.Rarity.COMMON);
            Weapon primary = new Weapon(primaryDefinition.name, Random.Range(primaryDefinition.minimumDamage, primaryDefinition.maximumDamage), primaryDefinition);

            WeaponDefinition secondaryDefinition = randomLootGenerator.getWeaponItem("ballistic_sidearms", "pistols", RarityObject.Rarity.COMMON);
            Weapon secondary = new Weapon(secondaryDefinition.name, Random.Range(secondaryDefinition.minimumDamage, secondaryDefinition.maximumDamage), secondaryDefinition);


            TeamMember teamMember = new TeamMember(Random.Range(0, 20), "Jack", "O'Neil", primary, secondary);

            Debug.Log(teamMember.ToString());

            createTeamMemberPanel(teamMember);
        }

        public void createTeamMemberPanel(TeamMember teamMember) {
            //instantiating the new team member panel and adding to the view
            Transform memberPanel = Instantiate(teamMemberPanel, Vector3.zero, Quaternion.identity).transform;
            memberPanel.SetParent(teamMemberView, false);

            //Set the panel title to something meaningful
            string name = PeopleUtil.getRankDetails(teamMember.rank).abbreviation + ". " + teamMember.forename + " " + teamMember.surname;
            memberPanel.Find("Name").GetComponent<Text>().text = name;

            //tting the rank image on the panel
            memberPanel.Find("RankImage").GetComponent<Image>().sprite = rankSprites[teamMember.rank];

            //set the primary weapon text on the panel
            memberPanel.Find("PrimaryWeapon").GetComponent<Text>().text = teamMember.primaryWeapon.name + "\n" + teamMember.primaryWeapon.damage;

            //set the secondary weapon text on the panel
            memberPanel.Find("SecondaryWeapon").GetComponent<Text>().text = teamMember.secondaryWeapon.name + "\n" + teamMember.secondaryWeapon.damage;

            //add a new listener to the selection button for the panel which calls the onMissionActivated function
            //passing in the mission details for this mission
            //memberPanel.Find("SelectButton").GetComponent<Button>().onClick.AddListener(() => { onMissionActivated(missionDetails, availablePanel.gameObject); });
        }
    }
}