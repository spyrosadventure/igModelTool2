using System.Runtime.InteropServices;
using igLibrary.Core;
using igLibrary.Gen.MetaEnum;

namespace igLibrary.Gen.MetaObject;

[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
public class igGraphicsMaterial : igMaterial
{
    public System.UInt64 _globalTechniqueMask;
    public System.UInt32 _materialBitField;
    public System.Byte _sortKey;
    public igDrawType _drawType;
    public igGraphicsMaterialAnimationTimeSource _timeSource;
    public System.Single _sortDepthOffset;
    public igLibrary.Core.igHandle _effectHandle;
    public igMemoryCommandStream _commonState;
    public igLibrary.Core.igVector<igMemoryCommandStream> _techniques;
    public igGraphicsMaterialAnimationList _animations;
    public igGraphicsObjectSet _graphicsObjects;
    public System.UInt32 _paletteIndex;
    public System.UInt32 _paletteIndex2;
}
