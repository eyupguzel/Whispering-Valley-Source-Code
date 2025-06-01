using UnityEngine;
using System.Collections;

public class SceneManager : Singleton<SceneManager>
{
    public IEnumerator LoadScene(int sceneIndex)
    {
        EventBus<OnChangeScene>.Publish(new OnChangeScene());

        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
