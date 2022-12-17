#if !UNITY_5_3_OR_NEWER

using System;

using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Bindings
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Delegate | AttributeTargets.Enum | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Struct, Inherited = false)]
    [VisibleToOtherModules]
    internal class VisibleToOtherModulesAttribute : Attribute
    {
        public VisibleToOtherModulesAttribute()
        {
        }

        public VisibleToOtherModulesAttribute(params string[] modules)
        {
        }
    }
}

namespace UnityEngine.Scripting
{
    [VisibleToOtherModules]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Enum | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Struct, Inherited = false)]
    internal class UsedByNativeCodeAttribute : Attribute
    {
        public string Name { get; set; }

        public UsedByNativeCodeAttribute()
        {
        }

        public UsedByNativeCodeAttribute(string name)
        {
            this.Name = name;
        }
    }
}

namespace UnityEngine
{
    public enum ColorSpace
    {
        Uninitialized = -1,
        Gamma,
        Linear
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    [UsedByNativeCode]
    public abstract class PropertyAttribute : Attribute
    {
        public int order { get; set; }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class RangeAttribute : PropertyAttribute
    {
        public readonly float min;
        public readonly float max;

        public RangeAttribute(float min, float max)
        {
            this.min = min;
            this.max = max;
        }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class MinAttribute : PropertyAttribute
    {
        public readonly float min;

        public MinAttribute(float min)
        {
            this.min = min;
        }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class MultilineAttribute : PropertyAttribute
    {
        public readonly int lines;

        public MultilineAttribute()
        {
            this.lines = 3;
        }
        public MultilineAttribute(int lines)
        {
            this.lines = lines;
        }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class TextAreaAttribute : PropertyAttribute
    {
        public readonly int minLines;
        public readonly int maxLines;

        public TextAreaAttribute()
        {
            minLines = 3;
            maxLines = 3;
        }
        public TextAreaAttribute(int minLines, int maxLines)
        {
            this.minLines = minLines;
            this.maxLines = maxLines;
        }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class ColorUsageAttribute : PropertyAttribute
    {
        public readonly bool showAlpha = true;
        public readonly bool hdr = false;

        [Obsolete("This field is no longer used for anything.")]
        public readonly float minBrightness = 0f;
        [Obsolete("This field is no longer used for anything.")]
        public readonly float maxBrightness = 8f;
        [Obsolete("This field is no longer used for anything.")]
        public readonly float minExposureValue = 0.125f;
        [Obsolete("This field is no longer used for anything.")]
        public readonly float maxExposureValue = 3f;

        public ColorUsageAttribute(bool showAlpha, bool hdr)
        {
            this.showAlpha = showAlpha;
            this.hdr = hdr;
        }
        public ColorUsageAttribute(bool showAlpha)
        {
            this.showAlpha = showAlpha;
        }
        [Obsolete("Brightness and exposure parameters are no longer used for anything. Use ColorUsageAttribute(bool showAlpha, bool hdr)")]
        public ColorUsageAttribute(bool showAlpha, bool hdr, float minBrightness, float maxBrightness, float minExposureValue, float maxExposureValue)
        {
            this.showAlpha = showAlpha;
            this.hdr = hdr;
            this.minBrightness = minBrightness;
            this.maxBrightness = maxBrightness;
            this.minExposureValue = minExposureValue;
            this.maxExposureValue = maxExposureValue;
        }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class GradientUsageAttribute : PropertyAttribute
    {
        public readonly bool hdr;
        public readonly ColorSpace colorSpace = ColorSpace.Gamma;

        public GradientUsageAttribute(bool hdr)
        {
            this.hdr = hdr;
            colorSpace = ColorSpace.Gamma;
        }
        public GradientUsageAttribute(bool hdr, ColorSpace colorSpace)
        {
            this.hdr = hdr;
            this.colorSpace = colorSpace;
        }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public class SpaceAttribute : PropertyAttribute
    {
        public readonly float height;

        public SpaceAttribute()
        {
            this.height = 8f;
        }
        public SpaceAttribute(int height)
        {
            this.height = height;

        }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public class HeaderAttribute : PropertyAttribute
    {
        public readonly string header;
        public HeaderAttribute(string header)
        {
            this.header = header;
        }
    }

    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class TooltipAttribute : PropertyAttribute
    {
        public string tooltip;
        public TooltipAttribute(string tooltip)
        {
            this.tooltip = tooltip;
        }
    }

    [UsedByNativeCode]
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class InspectorNameAttribute : PropertyAttribute
    {
        public string displayName;
        public InspectorNameAttribute(string displayName)
        {
            displayName = displayName;
        }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class DelayedAttribute : PropertyAttribute
    {
    }
}

#endif
