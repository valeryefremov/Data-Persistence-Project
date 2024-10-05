using UnityEngine;
using UnityEngine.UI;

public class LocalDataSaver : MonoBehaviour
{
    public static string playerName;

    [SerializeField] InputField inputField;

    private void Start()
    {
        if (inputField)
        {
            inputField.onEndEdit.AddListener(OnEndEdit);

            if (!string.IsNullOrEmpty(playerName))
            {
                inputField.text = playerName;
            }
        }
    }

    public void OnEndEdit(string text)
    {
        playerName = text;
    }
}
