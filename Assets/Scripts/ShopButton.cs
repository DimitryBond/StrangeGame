using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public int bloodCost;
    public int woodCost;
    public int crystalCost;

    private Button button;

    private void Start()
    {
        
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if (ResourceManager.Instance.blood < bloodCost ||
            ResourceManager.Instance.wood < woodCost ||
            ResourceManager.Instance.crystal < crystalCost)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    public void RemoveResources()
    {
        ResourceManager.Instance.AddResource("Blood", -bloodCost);
        ResourceManager.Instance.AddResource("Wood", -woodCost);
        ResourceManager.Instance.AddResource("Crystal", -crystalCost);
    }
}