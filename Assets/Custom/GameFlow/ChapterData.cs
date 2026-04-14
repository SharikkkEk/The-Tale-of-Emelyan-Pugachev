using UnityEngine;

namespace SkyBoundQuest
{
    [CreateAssetMenu(fileName = "Chapter", menuName = "SkyBoundQuest/Chapter")]
    public class ChapterData : ScriptableObject
    {
        public string chapterName = "Chapter";
        public string storyScene;
        public string battleScene;
    }
}
