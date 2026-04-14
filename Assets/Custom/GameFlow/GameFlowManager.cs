using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SkyBoundQuest
{
    public class GameFlowManager : MonoBehaviour
    {
        public static GameFlowManager Instance { get; private set; }

        [Header("Chapters")]
        public List<ChapterData> chapters;

        [Header("Scenes")]
        public string mainMenuScene = "Main Menu";
        public string endingScene = "Ending";

        private int currentChapter = 0;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void StartGame()
        {
            currentChapter = 0;
            LoadCurrentChapter();
        }

        private void LoadCurrentChapter()
        {
            if (currentChapter >= chapters.Count)
            {
                SceneManager.LoadScene(endingScene);
                return;
            }

            var chapter = chapters[currentChapter];
            Debug.Log($"Loading chapter {currentChapter + 1}: {chapter.chapterName}");
            SceneManager.LoadScene(chapter.storyScene);
        }

        public void OnStoryComplete()
        {
            var chapter = chapters[currentChapter];
            Debug.Log($"Story complete, loading battle: {chapter.battleScene}");
            SceneManager.LoadScene(chapter.battleScene);
        }

        public void OnBattleVictory()
        {
            currentChapter++;
            LoadCurrentChapter();
        }

        public void OnBattleDefeat()
        {
            var chapter = chapters[currentChapter];
            Debug.Log($"Defeat. Reloading battle: {chapter.battleScene}");
            SceneManager.LoadScene(chapter.battleScene);
        }

        public void ReturnToMainMenu()
        {
            SceneManager.LoadScene(mainMenuScene);
        }

        public int GetCurrentChapterNumber() => currentChapter + 1;
        public int GetTotalChapters() => chapters.Count;
    }
}
