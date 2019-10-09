#define UNITY_INTERFACE_API __stdcall
#define UNITY_INTERFACE_EXPORT __declspec(dllexport)

extern "C"
{

	UNITY_INTERFACE_EXPORT int UNITY_INTERFACE_API GetNumber()
	{
		return 123;
	}
}