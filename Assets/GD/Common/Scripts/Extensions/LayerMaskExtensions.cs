using UnityEngine;

/// <summary>
/// Provides extension methods for LayerMask
/// </summary>
/// <see cref="GD.Items.Item"/>
public static class LayerMaskExtensions
{
    public static bool OnLayer(this ref LayerMask target, GameObject gameObject) => ((1 << gameObject.layer) & target.value) != 0;
}