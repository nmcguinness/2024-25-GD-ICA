using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UIPrompt
{
    private static readonly Color DefaultColor = Color.black;
    private static readonly int DefaultSize = 12;
    private static readonly int MinScaledSize = 6;

    [SerializeField]
    [TextArea(2, 5)]
    private string text = "";

    [SerializeField]
    [ColorUsage(true)]
    private Color color = DefaultColor;

    [SerializeField]
    [Range(8, 36)]
    private int size = 12;

    [SerializeField]
    private bool isBold;

    [SerializeField]
    private bool isItalic;

    [ShowInInspector, ReadOnly]
    private Vector2 dimensions;

    #region Constructors

    public UIPrompt()
        : this("", DefaultSize, DefaultColor, false, false)
    {
    }

    public UIPrompt(string text, int size)
        : this(text, size, DefaultColor, false, false)
    {
    }

    public UIPrompt(string text, int size, Color color)
        : this(text, size, color, false, false)
    {
    }

    public UIPrompt(string text, int size, Color color, bool isBold, bool isItalic)
    {
        Text = text;
        Size = size;
        Color = color;
        IsBold = isBold;
        IsItalic = isItalic;
    }

    #endregion Constructors

    public string Text { get => text; set => text = value.Trim(); }
    public int Size { get => size; set => size = value; }
    public Color Color { get => color; set => color = value; }
    public bool IsBold { get => isBold; set => isBold = value; }
    public bool IsItalic { get => isItalic; set => isItalic = value; }
    public Vector2 Dimensions { get => dimensions; }

    public void Initialize(GUIStyle guiStyle)
    {
        dimensions = guiStyle.CalcSize(new GUIContent(text));
    }

    public override string ToString()
    {
        return $"{(isBold ? "<b>" : "")}{(isItalic ? "<i>" : "")}<color=#{ColorUtility.ToHtmlStringRGBA(color)}><size={size}>{Text}</size></color>{(isItalic ? "</i>" : "")}{(isBold ? "</b>" : "")}";
    }

    public string ToStringWithScaledSize(float globalScalePercentage)
    {
        //convert to factor for multiplication
        globalScalePercentage /= 100;

        //scale down all sizes by scale factor
        var scaledSize = (int)Math.Ceiling(globalScalePercentage * size);

        //limit min size to 4
        scaledSize = scaledSize < MinScaledSize ? MinScaledSize : scaledSize;

        return $"{(isBold ? "<b>" : "")}{(isItalic ? "<i>" : "")}<color=#{ColorUtility.ToHtmlStringRGBA(color)}><size={scaledSize}>{Text}</size></color>{(isItalic ? "</i>" : "")}{(isBold ? "</b>" : "")}";
    }
}

[ExecuteAlways]
public class UIRichTextMultiPrompt : MonoBehaviour
{
    [Header("Prompt Start Position & Offset")]
    [SerializeField]
    [Tooltip("Top left corner position (in pixels) of the first prompt")]
    private Vector2 startPosition = new Vector2(20, 20);

    [SerializeField]
    [Tooltip("X/Y separation (in pixels) between each prompt")]
    private Vector2 textOffset = new Vector2(0, 20);

    [Space]
    [SerializeField]
    private List<UIPrompt> prompts;

    [Space]
    [SerializeField]
    [Tooltip("Enable to scale all prompts with a single scale factor")]
    private bool enableGlobalFontScaling;

    [SerializeField]
    [Tooltip("Set to scale all prompts by float factor")]
    [Range(25, 400)]
    private int globalScalePercentage = 100;

    private GUIStyle guiStyle;

    private void Start()
    {
        guiStyle = new GUIStyle();
        guiStyle.richText = true;

        InitializePrompts();
    }

    /// <summary>
    /// Sets dimensions based on text and GUIStyle
    /// </summary>
    private void InitializePrompts()
    {
        foreach (UIPrompt prompt in prompts)
            prompt.Initialize(guiStyle);
    }

    private int count;
    private Vector2 corner;
    private string text;

    private void OnGUI()
    {
        count = 0;
        foreach (UIPrompt prompt in prompts)
        {
            corner = startPosition + textOffset * count++;
            text = "";

            if (enableGlobalFontScaling)
                text = prompt.ToStringWithScaledSize(globalScalePercentage);
            else
                text = prompt.ToString();

            GUI.Label(new Rect(corner, prompt.Dimensions), text, guiStyle);
        }
    }
}