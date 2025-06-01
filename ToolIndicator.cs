using UnityEngine;
using UnityEngine.EventSystems;

public class ToolIndicator : MonoBehaviour
{
    private GridManager gridManager;
    public ITool currentTool;
    public ITreeTool currentTreeTool;
    public ISeedTool currentSeedTool;

    private Vector3 newPosition;
    private Transform player;

    private int toolRange = 2;

    private void Start()
    {
        player = transform.parent;
        gridManager = GridManager.Instance;
    }
    private void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0))
            TryInteraction();

        newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);

        if (Vector3.Distance(transform.position , player.position) > toolRange)
        {
            Vector2 direction = transform.position - player.position;
            direction = direction.normalized * toolRange;
            transform.position = player.position + new Vector3(direction.x, direction.y, 0);
        }

        transform.position = new Vector3(Mathf.FloorToInt(transform.position.x) + 0.5f, Mathf.FloorToInt(transform.position.y) + 0.5f, 0);
    }
    private void TryInteraction()
    {
        
        Vector3 worldPos = transform.position;
        Vector3Int cellPos = gridManager.WorldToCell(worldPos);

        if (currentTool != null)
        {
            switch (currentTool)
            {
                case Hoe hoe when gridManager.TryHoeTile(worldPos):
                    hoe.Use(GridManager.Instance.GetSoilData(cellPos), cellPos);
                    break;
                case Watering watering when gridManager.TryWaterTile(worldPos):
                    watering.Use(GridManager.Instance.GetSoilData(cellPos), cellPos);
                    break;
                case SeedsToolItem seedsTool when gridManager.TryPlantSeed(worldPos, seedsTool.cropData):
                    seedsTool.Use(GridManager.Instance.GetSoilData(cellPos),cellPos);
                    break;
            }
        }
    }
    private BaseTree GetBaseTree()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        
        BaseTree tree = hit.collider?.GetComponent<BaseTree>();

        if (tree != null)
            return tree;
        else
            return null;
    }

    public void SetTool(Item item,CropData cropData = null)
    {

        if (item is ITool tool)
            currentTool = tool;
        else
            currentTool = null;

        if (item is ITreeTool treeTool)
        {
            currentTreeTool = treeTool;
        }
        else
            currentTreeTool = null;

        if (item is ISeedTool seedTool)
        {
            currentTool = seedTool;
        }
        else
            currentSeedTool = null;

    }
}
