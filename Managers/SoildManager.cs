using UnityEngine;
using UnityEngine.Tilemaps;

public class Soil : MonoBehaviour
{
    private ISoilState _currentState;
    public float Moisture { get; set; } //Nem
    public float Nutrients { get; set; } // Besin

    public SpriteRenderer spriteRenderer;
    public Sprite barrenSprite;
    public Sprite wetSprite;
    public Sprite growingSprite;

    private PlayerController player;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        player = PlayerController.Instance;
    }

    void Update()
    {
        _currentState?.Update();
    }

    public void ChangeState(ISoilState newState)
    {
        _currentState = newState;
        _currentState.Enter(this);
    }

    public void WaterSoil()
    {
        _currentState?.Water();
        player.animationController.SetAnimationStrategy(new WateringAnimation());
    }

    public void Fertilize()
    {
       _currentState?.Fertilize(.2f);
    }

    public void PlowSoil()
    {
        ChangeState(new BarrenSoil());
        player.animationController.SetAnimationStrategy(new HoeingAnimation());
    }

    public void UpdateVisual()
    {
        if (Moisture < .3f)
        {
            spriteRenderer.sprite = barrenSprite;
        }
        else
            spriteRenderer.sprite = wetSprite;
    }
}
