using System.Collections;
using UnityEngine;
using TMPro;

public class PopupMessageController : MonoBehaviour
{
    public TextMeshProUGUI popupText; // Reference til TMP text objektet
    public float displayDuration = 5f; // Hvor længe beskeden skal vises
    public string message = "Standard besked"; // Besked der skal vises

    private void Start()
    {
        ShowPopupMessage(message);
    }

    public void ShowPopupMessage(string message)
    {
        popupText.text = message;
        popupText.gameObject.SetActive(true);
        StartCoroutine(HidePopupAfterDelay());
    }

    private IEnumerator HidePopupAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        popupText.gameObject.SetActive(false);
    }
}
