using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManagment {
    public class SwitchLevel : MonoBehaviour {

        public int sceneIndex;

        public enum EntryType { Enter, Exit, Other }
        public EntryType entryType;

        private GameManager gameManager;

        void OnTriggerEnter2D(Collider2D other)
        {
            gameManager = FindObjectOfType<GameManager>();

            if (other.tag == "Player")
            {
                gameManager.entryType = entryType;
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }
}
