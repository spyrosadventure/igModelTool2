using System.Runtime.InteropServices;
using igLibrary.Core;
using igLibrary.Math;

namespace igLibrary.Gen.MetaObject;

[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
public class igSkeleton2 : igNamedObject
{
	public igSkeletonBoneList _boneList;

	public igMemory<igMatrix44f> _inverseJointArray;
}
