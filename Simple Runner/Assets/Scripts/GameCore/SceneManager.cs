using UnityEngine.SceneManagement;
namespace GameCore
{
    public class SceneController
    {
        public SceneController()
        {
            EventsHolder.OnEndGame += RestartLevel;
        }
        private void RestartLevel()
        {
            string activeSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(activeSceneName);
        }
    }
}