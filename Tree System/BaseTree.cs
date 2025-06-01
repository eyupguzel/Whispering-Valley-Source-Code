using System;
using System.Threading;
using UnityEngine;

public class BaseTree : MonoBehaviour
{
    [SerializeField] private TreeData treeData;
    private TreeStage currentStage;
    private SeasonType seasonType;

    private string treeName;
    private bool isFruitable;
    private WoodType woodType;

    private SpriteRenderer spriteRenderer;

    private GameObject currentTreeStage;

    int chopTimes;
    private PlayerController player;

    //private PlayerController playerController;

    private void Start()
    {
        //playerController = PlayerController.Instance;
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateVisual();
        treeName = treeData.treeName;
        isFruitable = treeData.isFruitable;
        woodType = treeData.woodType;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Grow();

    }
    public void Grow()
    {
        if (currentStage != TreeStage.Stump)
        {
            currentStage = (TreeStage)((int)currentStage + 1);
            UpdateVisual();
        }
    }
    public bool CanBeChopped()
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position, new Vector2(3, 2), 1);
        if (collider != null)
            player = collider.GetComponent<PlayerController>();

        if (player != null)
            return true;

        Debug.Log("Player is not in range to chop the tree");
        return false;
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(3, 2));
    }
    public WoodData Chop()
    {
        PlayerController.Instance.animationController.SetAnimationStrategy(new AxeingAnimation());
        if (CanBeChopped())
            if (GetCurrentTreeStageData().canBeChopped)
            {
                chopTimes++;
                currentTreeStage.GetComponent<Animator>().SetTrigger("Chopping");
                if (chopTimes >= 5)
                {
                    currentStage = TreeStage.Stump;
                    UpdateVisual();
                }
            }
        return null;
    }
    public void UpdateVisual()
    {
        if (currentTreeStage != null)
            Destroy(currentTreeStage);
        currentTreeStage = Instantiate(GetCurrentTreeStageData().prefab, transform.position, Quaternion.identity, transform);
    }
    private TreeStageData GetCurrentTreeStageData()
    {
        return treeData.treeStagesDataList.Find(treeData => treeData.treeStage == currentStage);
    }
}
