using System.Runtime.InteropServices;
using igLibrary.Core;

namespace igLibrary.Gen.MetaObject;

[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
public class igCommandStream : igObject
{
	public ulong _writeHead;

	public ulong _writeChunkBegin;

	public ulong _writeChunkEnd;

	public ulong _readHead;

	public ulong _readChunkBegin;

	public ulong _readChunkEnd;
}
