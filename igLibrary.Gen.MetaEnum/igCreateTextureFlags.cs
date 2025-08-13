namespace igLibrary.Gen.MetaEnum;

public enum igCreateTextureFlags
{
	kCreateRenderTarget = 1,
	kCreateNoShaderAccess = 2,
	kCreateNoResolve = 4,
	kCreateCubeMap = 8,
	kCreateUseTileRegion = 0x10,
	kCreateUseSecondaryMemory = 0x20,
	kCreateUseBufferPtrAsEsramOffset = 0x40
}
