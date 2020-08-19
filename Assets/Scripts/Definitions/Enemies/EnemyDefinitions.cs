using System.Collections.Generic;

namespace Definitions.Enemies {
    [System.Serializable]
    public class EnemyDefinitions {

        //key = unique enemy key, usually the name such as 'jaffa'
        //value = enemy details
        public Dictionary<string, EnemyDefinition> definitions;
    }
}