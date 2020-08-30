using Definitions.ResourceDefinitions;
using Newtonsoft.Json;
using System.Collections;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ResourcesManagement {
    public class ResourceManager : MonoBehaviour {
        private static string resourcesPath = "/Resources.json";

        private static string titaniumKey = "titanium";
        private static string triniumKey = "trinium";
        private static string naquadahKey = "naquadah";
        private static string naquadriaKey = "naquadria";
        private static string zpmKey = "zpm";

        private static float updatePeriod = 30;

        public Text titaniumText;
        public Text triniumText;
        public Text naquadahText;
        public Text naquadriaText;
        public Text zpmText;

        private Definitions.ResourceDefinitions.Resources resources;

        private float currentUpdateTime;

        private void Start() {
            getResources();

            double timeSinceLastUpdate = (DateTime.UtcNow - this.resources.lastUpdateTime).TotalSeconds + this.resources.currentUpdateTime;
            currentUpdateTime = (float)(timeSinceLastUpdate % updatePeriod);
            int progresses = (int)(timeSinceLastUpdate / updatePeriod);

            //update the titanium resource amount
            Resource res = resources.resources[titaniumKey];
            updateResource(ref res, progresses * res.progressRate);

            //update the trinium resource amount
            res = resources.resources[triniumKey];
            updateResource(ref res, progresses * res.progressRate);

            //update the naquadah resource amount
            res = resources.resources[naquadahKey];
            updateResource(ref res, progresses * res.progressRate);

            //update the naquadria resource amount
            res = resources.resources[naquadriaKey];
            updateResource(ref res, progresses * res.progressRate);

            //update the zpm resource amount
            res = resources.resources[zpmKey];
            updateResource(ref res, progresses * res.progressRate);

            updateResourceView();
            StartCoroutine(resourceCollection());
        }

        IEnumerator resourceCollection() {
            while (true) {
                //Update the current time since last update
                currentUpdateTime += Time.deltaTime;

                //check if the update time has been surpassed
                if (currentUpdateTime >= updatePeriod) {
                    //reset the update time, carrying over excess milliseconds
                    currentUpdateTime -= updatePeriod;

                    //update the titanium resource amount
                    Resource res = resources.resources[titaniumKey];
                    updateResource(ref res, res.progressRate);

                    //update the trinium resource amount
                    res = resources.resources[triniumKey];
                    updateResource(ref res, res.progressRate);

                    //update the naquadah resource amount
                    res = resources.resources[naquadahKey];
                    updateResource(ref res, res.progressRate);

                    //update the naquadria resource amount
                    res = resources.resources[naquadriaKey];
                    updateResource(ref res, res.progressRate);

                    //update the zpm resource amount
                    res = resources.resources[zpmKey];
                    updateResource(ref res, res.progressRate);

                    //update the resource view in the scene
                    updateResourceView();

                    //temporarily save the resources with each update
                    saveResources();
                }

                yield return null;
            }
        }

        private void updateResource(ref Resource res, float progressRate) {
            if (res.amount < res.max) {
                res.progress += progressRate;
                int increaseAmount = (int)(res.progress / 1);
                res.progress %= 1;
                res.amount = res.amount + increaseAmount <= res.max ? res.amount + increaseAmount : res.max;
            }
        }

        private void updateResourceView() {
            //update each resource text object
            titaniumText.text = "" + resources.resources[titaniumKey].amount;
            triniumText.text = "" + resources.resources[triniumKey].amount;
            naquadahText.text = "" + resources.resources[naquadahKey].amount;
            naquadriaText.text = "" + resources.resources[naquadriaKey].amount;
            zpmText.text = "" + resources.resources[zpmKey].amount;
        }

        public void getResources() {
            //check the persistent data folder for the resources json
            if (!File.Exists(Application.persistentDataPath + resourcesPath)) {
                //file does not exist

                //create a new resources object
                this.resources = new Definitions.ResourceDefinitions.Resources();

                saveResources();
            } else {
                //file exists, load text into a string
                string storedString = File.ReadAllText(Application.persistentDataPath + resourcesPath);

                //deserialize and return the string into an resources object
                this.resources = JsonConvert.DeserializeObject<Definitions.ResourceDefinitions.Resources>(storedString);
            }
        }

        public void saveResources() {
            this.resources.lastUpdateTime = DateTime.UtcNow;
            this.resources.currentUpdateTime = this.currentUpdateTime;

            //serialize the Teams object to a string
            string teamsJson = JsonConvert.SerializeObject(this.resources, Formatting.None);

            //write string to a new json file in the persistent data folder
            File.WriteAllText(Application.persistentDataPath + resourcesPath, teamsJson);
        }
    }
}