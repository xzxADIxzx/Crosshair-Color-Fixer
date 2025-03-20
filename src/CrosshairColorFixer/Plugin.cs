namespace CrosshairColorFixer;

using BepInEx;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary> Plugin class containing the whole logic of the mod. There isn't a lot, but what did you expect? </summary>
[BepInPlugin("xzxADIxzx.CorsshairColorFixer", "CrosshairColorFixer", "1.0.0")]
public class Plugin : BaseUnityPlugin
{
    ColorBlindSettings cb => ColorBlindSettings.Instance;

    private void Awake() => SceneManager.sceneLoaded += (_, _) => Invoke("ApplyFix", .1f);

    private void ApplyFix()
    {
        var bars = CanvasController.Instance?.transform.Find("Crosshair Filler/Crosshair/HealthBars")?.GetComponentsInChildren<Image>(true);
        if (bars != null && cb)
        {
            bars[0].color = cb.healthBarAfterImageColor;
            bars[1].color = cb.healthBarColor;
            bars[2].color = cb.antiHpColor;
            bars[3].color = cb.healthBarAfterImageColor;
            bars[4].color = cb.overHealColor;
        }
    }
}
