using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public static LevelManager MainLevelManager;
    public Transform LevelRacePath;
    public Button FireButton;
    public Sprite LazerGunSprite, ShockWaveSprite, ArmorSprite;

    private string _currentEquipment;

    void Awake()
    {
        if (MainLevelManager == null)
        {
            //DontDestroyOnLoad(gameObject);
            MainLevelManager = this;
        }
        else if (MainLevelManager != this)
        {
            Destroy(gameObject);
        }
    }

    public void FireTrigger()
    {

    }

    private void ChangeButtonState()
    {
        FireButton.interactable = !FireButton.interactable;
        if (FireButton.interactable)
        {
            switch (_currentEquipment)
            {
                case "LazerGun": FireButton.image.sprite = LazerGunSprite; break;
                case "Shockwave": FireButton.image.sprite = ShockWaveSprite; break;
                case "ArmorShield": FireButton.image.sprite = ArmorSprite; break;
            }
        }
    }
}
