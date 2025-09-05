using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    
    Animator canvasAnimator;
    
    [SerializeField] private Image splashBloodImage;
    [SerializeField] private List<Sprite> spritesBloods;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        canvasAnimator = GetComponent<Animator>();
    }

    public void ShowSplashBloods()
    {
        splashBloodImage.sprite = spritesBloods[Random.Range(0, spritesBloods.Count)];
        canvasAnimator.Play("SplashBlood");
        
    }
}
