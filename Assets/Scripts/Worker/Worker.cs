using UnityEngine;

public class Worker : MonoBehaviour
{
    private readonly WorkerData workerData = new();
    [SerializeField] private WorkerSo workerSo;

    private float collectDistance; // расстояние сбора
    private float timeBetweenCollect; // время между сбором
    private int collectAmount; // по сколько собирает
    private float nextCollectTime; // следующее время сбора
    private float distanceToAltar; // растояние для приношения алтарю
    private GameObject resourcePopUp; // звук при выборе
    private GameObject deathSound; // звук смерти
    private AudioSource audioSource;
    private GameObject bloodAltar;
    public LayerMask resourceLayer; // слой ресурсов для сбора 
    private Resource currentResource; // текущий ресурс
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        bloodAltar = GameObject.FindGameObjectWithTag("Altar");
    }

    private void Start()
    {
        collectDistance = workerSo.CollectDistance;
        timeBetweenCollect = workerSo.TimeBetweenCollect;
        collectAmount = workerSo.CollectAmount;
        distanceToAltar = workerSo.DistanceToAltar;
        resourcePopUp = workerSo.ResourcePopUp;
        deathSound = workerSo.DeathSound;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (!workerData.IsSelected)
        {
            // сбор ресурсов
            CollectResource();

            // пожертвование алтарю
            Sacrifice();
        }
    }

    private void CollectResource()
    {
        GetCurrentResource();

        if (currentResource != null)
        {
            if (Time.time > nextCollectTime)
            {
                // доделать чтобы отображалось правильное количество собранного ресурса
                Instantiate(resourcePopUp, transform.position, Quaternion.identity); // спавн канваса с анимацией +1
                nextCollectTime = Time.time + timeBetweenCollect;
                currentResource.resourceAmount -= collectAmount;
                ResourceManager.Instance.AddResource(currentResource.resourceType, collectAmount);
            }
        }
    }

    private void GetCurrentResource()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, collectDistance, resourceLayer);
        if (col != null && currentResource == null)
        {
            currentResource = col.GetComponent<Resource>();
        }
        else
        {
            currentResource = null;
        }
    }

    private void Sacrifice()
    {
        if (Vector2.Distance(transform.position, bloodAltar.transform.position) <= distanceToAltar)
        {
            Instantiate(deathSound);
            ResourceManager.Instance.AddSacrificedWorker();
            Destroy(gameObject);
        }
    }


    private void Move()
    {
        if (!workerData.IsSelected) return;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }

    private void OnMouseDown()
    {
        audioSource.Play();
        workerData.IsSelected = true;
    }

    private void OnMouseUp()
    {
        workerData.IsSelected = false;
    }
}