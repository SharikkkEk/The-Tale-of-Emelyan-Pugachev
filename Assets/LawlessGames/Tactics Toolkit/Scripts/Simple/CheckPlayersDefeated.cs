using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TacticsToolkit
{
    public class CheckPlayersDefeated : MonoBehaviour
    {
        public string targetSceneName = "GameOver";
        public float delayBeforeSwitch = 1f;

        private bool sceneSwitched = false;

        void Update()
        {
            if (sceneSwitched) return;

            var players = GameObject.FindGameObjectsWithTag("Player");
            bool allDead = players.All(p => !p.GetComponent<Entity>().isAlive);

            if (players.Length > 0 && allDead)
            {
                StartCoroutine(SwitchScene());
            }
        }

        IEnumerator SwitchScene()
        {
            sceneSwitched = true;
            yield return new WaitForSeconds(delayBeforeSwitch);
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
