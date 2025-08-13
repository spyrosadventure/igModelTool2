using System.Runtime.InteropServices;
using igLibrary.Core;
using igLibrary.Graphics;

namespace igLibrary.Gen.MetaObject;

[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
public class igGraphicsObjectSet : igObject
{
	public igVector<igGraphicsObject> _objects;
}
