using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Ghost worker;
    public Ghost village;
    public Ghost tree;
    public Ghost crystal;
    public Ghost trap;

    public void OnShopClick(string whatItem)
    {
        if (whatItem == "worker")
        {
            Instantiate(worker);
        }

        if (whatItem == "village")
        {
            Instantiate(village);
        }

        if (whatItem == "tree")
        {
            Instantiate(tree);
        }

        if (whatItem == "crystal")
        {
            Instantiate(crystal);
        }

        if (whatItem == "trap")
        {
            Instantiate(trap);
        }
    }
}