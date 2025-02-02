using TMPro;
using UnityEngine;

public class ItemCount_UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;

    public void UpdateText(int count)
    {
        if(count <= 1)
        {
            countText.text = "";
        }
        else
        {
            countText.text = count.ToString();
        }        
    }
}
