namespace igLibrary.Gen.MetaEnum;

public enum igSortKeyCommandId
{
	kSortKeyCommandNoop = 0,
	kSortKeyCommandEndNamedEvent = 1,
	kSortKeyCommandBeginNamedEvent = 2,
	kSortKeyCommandIssueBufferedGpuTimestamp = 3,
	kSortKeyCommandSetEncoderPassState = 4,
	kSortKeyCommandCallback = 5,
	kSortKeyCommandDelegate = 6,
	kSortKeyCommandBindBackBuffer = 7,
	kSortKeyCommandDefaultClearRenderTarget = 8,
	kSortKeyCommandUserStart = 9,
	kSortKeyCommandLast = 1023
}
