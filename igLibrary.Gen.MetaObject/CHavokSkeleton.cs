using System.Runtime.InteropServices;
using igLibrary.Core;

namespace igLibrary.Gen.MetaObject;

[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
public class CHavokSkeleton : igObject
{
	public igSkeleton2 _alchemySkeleton;

	public ulong _havokSkeleton;

	public igIntIntHashTable _boneIndexMap;
}
