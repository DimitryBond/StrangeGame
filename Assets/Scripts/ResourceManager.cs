using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class ResourceManager : MonoBehaviour
{
    public TMP_Text woodDisplay;
    public TMP_Text bloodDisplay;
    public TMP_Text crystalDisplay;
    public int wood;
    public int blood;
    public int crystal;
    
    public static ResourceManager Instance;

    public int numberOfWorkersSacrificed;
    public TMP_Text sacrificeText;
    public int sacrificeGoal;

    void Awake()
    {
        Instance = this;
    }

    public void AddResource(string resourceType, int amount)
    {
        if (resourceType == "Wood")
        {
            wood += amount;
            woodDisplay.text = wood.ToString();
        }
        if (resourceType == "Blood")
        {
            blood += amount;
            bloodDisplay.text = blood.ToString();
        }
        if (resourceType == "Crystal")
        {
            crystal += amount;
            crystalDisplay.text = crystal.ToString();
        }
    }

    public void AddSacrificedWorker()
    {
        numberOfWorkersSacrificed++;
        sacrificeText.text = numberOfWorkersSacrificed + " / " + sacrificeGoal;

        if (numberOfWorkersSacrificed >= sacrificeGoal)
        {
            print("WON");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
