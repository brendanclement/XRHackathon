using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    /*    [SerializeField] RectTransform fader;*/
    // Start is called before the first frame update
    void Start()
    {
/*        SceneManager.LoadScene("CrimeScene");*/
/*        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        LeanTween.scale(fader, new Vector3(0, 0, 0), 0.5f).setOnComplete(() =>
        {
            fader.gameObject.SetActive(false);
        });*/

    }

    // Update is called once per frame
    public void OpenCrimeScene(string sceneName)
    {
/*        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setOnComplete(() => {*/
            SceneManager.LoadScene(sceneName);
/*        });*/
    }

}
