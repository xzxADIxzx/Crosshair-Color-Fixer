namespace CrosshairColorFixer;

using BepInEx;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary> Class with the logic of the mod. Yeah, there is not a lot of things, but what did you expect? </summary>
[BepInPlugin("xzxADIxzx.CorsshairColorFixer", "CrosshairColorFixer", "1.0.0")]
public class Plugin : BaseUnityPlugin
{
    ColorBlindSettings cb => ColorBlindSettings.Instance;

    private void Awake() => SceneManager.sceneLoaded += (_, _) => Invoke("ApplyFix", .1f);

    private void ApplyFix()
    {
        var comps = CanvasController.Instance?.transform.Find("Crosshair Filler/Crosshair/HealthBars")?.GetComponentsInChildren<Image>(true);
        if (comps != null && cb)
        {
            comps[0].color = cb.healthBarAfterImageColor;
            comps[1].color = cb.healthBarColor;
            comps[2].color = cb.antiHpColor;
            comps[3].color = cb.healthBarAfterImageColor;
            comps[4].color = cb.overHealColor;
        }
    }
}
