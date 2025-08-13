using System.Runtime.InteropServices;
using igLibrary.Core;
using igLibrary.Gen.MetaObject;
using igLibrary.Math;
using igLibrary.Render;

namespace igLibrary.Gen.MetaObjectw;

[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
public class CGraphicsSkinInfo : igInfo
{
	public igSkeleton2 _skeleton;

	public igModelData _skin;

	public igStringIntHashTable _boltPointIndexArray;

	public CHavokSkeleton _havokSkeleton;

	public igVec3f _boundsMin;

	public igVec3f _boundsMax;
}
