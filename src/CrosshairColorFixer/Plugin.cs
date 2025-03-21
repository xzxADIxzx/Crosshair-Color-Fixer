namespace CrosshairColorFixer;

using BepInEx;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary> Bootloader class needed to avoid destroying the mod by the game. </summary>
[BepInPlugin("xzxADIxzx.CorsshairColorFixer", "CrosshairColorFixer", "1.0.1")]
public class PluginLoader : BaseUnityPlugin
{
    private void Awake() => SceneManager.sceneLoaded += (_, _) => Plugin.Instance.Invoke("ApplyFix", .1f);
}

/// <summary> Plugin class containing the whole logic of the mod. There isn't a lot, but what did you expect? </summary>
[ConfigureSingleton(SingletonFlags.PersistAutoInstance)]
public class Plugin : MonoSingleton<Plugin>
{
    ColorBlindSettings cb => ColorBlindSettings.Instance;

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
