using System.Collections;
using UnityEngine;

public class UIPanelAnimation : MonoBehaviour
{
    public Animation animationComponent;
    public string openAnim = "Open";
    public string closeAnim = "Close";

    public void Open()
    {
        gameObject.SetActive(true);
        animationComponent.Play(openAnim);
    }
    public void Close()
    {
        animationComponent.Play(closeAnim);
        StartCoroutine(DisableAfterClose());
    }

    private IEnumerator DisableAfterClose()
    {
        yield return new WaitForSeconds(animationComponent[closeAnim].length);
        gameObject.SetActive(false);
    }
}

