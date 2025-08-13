using System.Runtime.InteropServices;
using igLibrary.Core;
using igLibrary.Gen.MetaEnum;
using igLibrary.Sg;

namespace igLibrary.Gen.MetaObject;

[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
public class igGraphicsMaterialAnimation : igObject
{
	public igAnimatedTransformSource _transform;

	public igGraphicsMaterialAnimationConstantType _constantType;

	public string _constantName;

	public ulong _resource;
}
