namespace igLibrary.Gen.MetaEnum;

public enum igStateChangedBit
{
	kBlendStateChangedBit = 2,
	kAlphaTestStateChangedBit = 4,
	kDepthStateChangedBit = 8,
	kStencilStateChangedBit = 0x10,
	kSCullChangedBit = 0x20,
	kRasterizerStateChangedBit = 0x40,
	kViewportChangedBit = 0x80,
	kScissorChangedBit = 0x100,
	kRenderTargetsChangedBit = 0x200,
	kRenderTargetMaskChangedBit = 0x400,
	kPixelShaderChangedBit = 0x800,
	kVertexShaderChangedBit = 0x1000,
	kPixelShaderTexturesChangedBit = 0x2000,
	kPixelShaderSamplersChangedBit = 0x4000,
	kVertexShaderTexturesChangedBit = 0x8000,
	kVertexShaderSamplersChangedBit = 0x10000,
	kVertexBufferChangedBit = 0x20000,
	kIndexBufferChangedBit = 0x40000,
	kVertexCacheChangedBit = 0x80000,
	kTextureCacheChangedBit = 0x100000
}
