using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private TextMesh text = null;
    private Text ui = null;

    public void SetPlayerCaptian(string caption)
    {
        if (text == null)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                if (this.transform.GetChild(i).name == "Caption")
                {
                    text = this.transform.GetChild(i).GetComponent<TextMesh>();
                }
            }
        }
        if (text != null)
        {
            text.text = caption;
        }
    }
    public void SetTitle(string caption)
    {
        if (ui == null)
        {
            ui = GameObject.Find("txtTitle").GetComponent<Text>();
        }
        if (ui != null)
        {
            ui.text = caption;
        }
    }
}
