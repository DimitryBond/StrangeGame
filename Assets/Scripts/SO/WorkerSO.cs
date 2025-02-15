using UnityEngine;

[CreateAssetMenu]
public class WorkerSo : ScriptableObject
{
    public float CollectDistance;
    public float TimeBetweenCollect;
    public int CollectAmount;
    public float DistanceToAltar;
    public GameObject ResourcePopUp;
    public GameObject DeathSound;
}