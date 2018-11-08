using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameManagment
{
    public class GameManager : MonoBehaviour
    {

        [Header("Player")]
        public GameObject livePlayer;
        public GameObject playerPrefab;

        [Header("Next Spawn")]
        public SwitchLevel.EntryType entryType;

        [Header("Stuff")]
        public GameObject[] doNotDestroy;

        private List<GameObject> spawns = new List<GameObject>();

        void Start()
        {
            DontDestroyOnLoad(this);

            foreach (Transform child in GameObject.Find("Spawns").transform)
            {
                spawns.Add(child.gameObject);
            }

            SceneManager.activeSceneChanged += LevelChanged;

            livePlayer = Instantiate(playerPrefab);
            livePlayer.transform.position = spawns[0].transform.position;
            livePlayer.GetComponent<PlayerHealth>().healthUI = GameObject.Find("HealthBar").GetComponent<Slider>();

            GameObject.Find("CM vcam1").GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = livePlayer.transform;

            foreach (GameObject gm in doNotDestroy)
            {
                DontDestroyOnLoad(gm);
            }
        }

        void LevelChanged(Scene previousScene, Scene newScene)
        {
            spawns.Clear();

            GetComponentInChildren<ShopManager>().shopUI = GameObject.Find("ShopUI");
            GetComponentInChildren<ShopManager>().hoverUI = GameObject.Find("HoverUI");
            GetComponentInChildren<DialogueManager>().dialogueUI = GameObject.Find("DialogueUI");

            GameObject.Find("CM vcam1").GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = livePlayer.transform;

            foreach (Transform child in GameObject.Find("Spawns").transform)
            {
                spawns.Add(child.gameObject);
            }

            livePlayer = Instantiate(playerPrefab);
            livePlayer.GetComponent<PlayerHealth>().healthUI = GameObject.Find("HealthBar").GetComponent<Slider>();

            if (entryType == SwitchLevel.EntryType.Enter)
            {
                livePlayer.transform.position = spawns[0].transform.position;
            }
            else if(entryType == SwitchLevel.EntryType.Exit)
            {
                livePlayer.transform.position = spawns[1].transform.position;
            }
            else if(entryType == SwitchLevel.EntryType.Other)
            {
                livePlayer.transform.position = spawns[2].transform.position;
            }
            else
            {
                Debug.LogError("No Entry Type");
                livePlayer.transform.position = spawns[0].transform.position;
            }
        }
    }
}
