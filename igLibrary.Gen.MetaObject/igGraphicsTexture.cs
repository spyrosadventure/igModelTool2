using System.Runtime.InteropServices;
using igLibrary.Core;
using igLibrary.Gfx;
using igLibrary.Graphics;

namespace igLibrary.Gen.MetaObject;

[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
public class igGraphicsTexture : igGraphicsObject
{
	public igResourceUsage _usage;

	public igImage2 _image;

	public igHandle _imageHandle;

	public ulong _resource;
}
