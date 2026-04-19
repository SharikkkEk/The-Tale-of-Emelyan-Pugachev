using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TacticsToolkit
{
    public class CheckEnemiesDefeated : SceneSwitcher
    {
        public float delayBeforeSwitch = 1f;

        private bool sceneSwitched = false;

        void Update()
        {
            if (sceneSwitched) return;

            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            bool allDead = enemies.All(e => !e.GetComponent<Entity>().isAlive);

            if (enemies.Length > 0 && allDead)
            {
                LoadNextScene();
            }
        }
    }
}