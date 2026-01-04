using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class EntryPointBootstrap : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    void Start()
    {
        StartCoroutine(AnimAndLoadScene());
    }
    private IEnumerator AnimAndLoadScene()
    {
        text.DOColor(new Color(1, 1, 1, 1), 2f);
        yield return new WaitForSeconds(1f);

        yield return Load.Instance.LoadScene(1);
    }
}
