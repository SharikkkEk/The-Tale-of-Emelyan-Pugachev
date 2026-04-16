using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TacticsToolkit
{
    public class CheckAlliesDefeated : MonoBehaviour
    {
        public string targetSceneName = "8 - Final Scene";
        public float delayBeforeSwitch = 1f;

        private bool sceneSwitched = false;

        void Update()
        {
            if (sceneSwitched) return;

            var enemies = GameObject.FindGameObjectsWithTag("Player");
            bool allDead = enemies.All(e => !e.GetComponent<Entity>().isAlive);

            if (enemies.Length > 0 && allDead)
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