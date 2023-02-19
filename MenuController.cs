using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
   public string gameScene;

   public void Play()
   {
      SceneManager.LoadScene(gameScene, LoadSceneMode.Single);
   }

   public void Setting()
   {
      SceneManager.LoadScene(gameScene, LoadSceneMode.Single);
   }

   public void Quit()
   {
    Application.Quit();
   }
}
