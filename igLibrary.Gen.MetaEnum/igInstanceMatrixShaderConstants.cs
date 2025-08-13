namespace igLibrary.Gen.MetaEnum;

public enum igInstanceMatrixShaderConstants
{
	kMatrixModel = 1,
	kMatrixModelIT = 2,
	kMatrixModelView = 4,
	kMatrixModelViewIT = 8,
	kMatrixModelViewPrevious = 0x10,
	kMatrixModelViewProjection = 0x20,
	kMatrixBlending = 0x40,
	kMatrixBlendingPrevious = 0x80
}
