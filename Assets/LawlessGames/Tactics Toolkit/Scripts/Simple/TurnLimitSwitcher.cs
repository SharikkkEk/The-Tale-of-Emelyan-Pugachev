using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TacticsToolkit
{
    public class TurnLimitSwitcher : MonoBehaviour
    {
        [Header("Turn Settings")]
        public int maxTurns = 8;
        public string targetSceneName = "8 - Final Scene";
        public float delayBeforeSwitch = 1f;

        [Header("References")]
        public TurnBasedController turnController;

        private int turnCount = 0;
        private bool sceneSwitched = false;

        void Update()
        {
            if (sceneSwitched || turnController == null) return;

            var currentTurn = turnController.ActiveCharacter;
            if (currentTurn != null && currentTurn.CompareTag("Player"))
            {
                turnCount++;

                if (turnCount >= maxTurns)
                {
                    StartCoroutine(SwitchScene());
                }
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
