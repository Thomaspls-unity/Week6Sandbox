using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SandboxLoading : MonoBehaviour
{
    [SerializeField] private Slider loadingBar;
    [SerializeField] private TMP_Text loadingTxt;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadNewScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(2f);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(Utility.sceneToLoad);

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);

            loadingBar.value = progress;
            float progressPercent = progress * 100;
            loadingTxt.SetText(progressPercent.ToString("00") + "%");

            yield return new WaitForSeconds(.01f);
        }
    }
}
