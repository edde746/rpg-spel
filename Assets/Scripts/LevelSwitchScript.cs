using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitchScript : MonoBehaviour
{
    public void ChangeLevel(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
