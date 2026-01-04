using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : Singleton<Load>
{
    public float _load = 0f;

    public IEnumerator LoadScene(int index)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9f)
        {
            _load = asyncLoad.progress;
            yield return null;
        }

        asyncLoad.allowSceneActivation = true;

        while (!asyncLoad.isDone)
        {
            _load = asyncLoad.progress;
            yield return null;
        }

        _load = 0;
    }
}
