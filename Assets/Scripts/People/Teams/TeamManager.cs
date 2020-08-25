using UnityEngine;
using Definitions.People;
using Generation;
using Definitions.Items;

namespace Missions {
    public class TeamManager : MonoBehaviour {

        private void Start() {

        }

        public void generateNewTeamMember() {

            RandomLootGenerator randomLootGenerator = new RandomLootGenerator();

            randomLootGenerator.getWeaponItem("ballistic_main_weapons", "assault_rifles", RarityObject.Rarity.COMMON);
            TeamMember teamMember = new TeamMember();
        }
    }
}