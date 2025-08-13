using igLibrary;
using igLibrary.Core;

namespace CauldronModels;

public static class Utils {
    public static void WriteHalf(this StreamHelper streamHelper, Half data) => streamHelper.WriteHalf(data, streamHelper._endianness);

    public static (T?, igObjectDirectory?) GetObjectAlias2<T>(this igHandle handle) where T : igObject {
        if (handle._object != null)
            return ((T)handle._object, default); // TODO: would require storing on the handle as well?
        var directoriesByName = igSingleton<igObjectStreamManager>.Singleton._directoriesByName;
        if (directoriesByName.TryGetValue(handle._namespace._hash, out var objectDirectoryList)) {
            for (var index1 = 0; index1 < objectDirectoryList._count; ++index1) {
                var igObjectDirectory = objectDirectoryList[index1];
                if (!igObjectDirectory._useNameList)
                    return (default, default);
                for (var index2 = 0; index2 < igObjectDirectory._nameList!._count; ++index2) {
                    if ((int)igObjectDirectory._nameList[index2]._hash != (int)handle._alias._hash) continue;
                    handle._object = (igObjectDirectory._objectList[index2] as T)!;
                    return ((T)handle._object, igObjectDirectory);
                }
            }
        }

        Logging.Warn("failed to load {0}.{1}", handle._namespace._string, handle._alias._string);
        return (default, default);
    }

    public static void WriteHalf(this StreamHelper streamHelper, Half data, StreamHelper.Endianness endianness) {
        streamHelper.WriteForEndianness(BitConverter.GetBytes(data), endianness);
    }

    public static void WriteForEndianness(this StreamHelper streamHelper, byte[] bytes, StreamHelper.Endianness endianness) {
        switch (endianness) {
            case StreamHelper.Endianness.Little:
                if (!BitConverter.IsLittleEndian) {
                    Array.Reverse(bytes);
                }

                break;
            case StreamHelper.Endianness.Big:
                if (BitConverter.IsLittleEndian) {
                    Array.Reverse(bytes);
                }

                break;
        }

        streamHelper.BaseStream.Write((ReadOnlySpan<byte>)bytes);
    }

    public static igNamedObject? FindObjectByName(this igObjectList obj, string targetName) {
        foreach (var targetIgObj in obj) {
            var nameField = targetIgObj.GetMeta().GetFieldByName("_name");
            if (nameField == null) continue;
            var name = nameField._fieldHandle!.GetValue(targetIgObj);
            if (name == null || !name.Equals(targetName)) continue;
            return (igNamedObject?)targetIgObj;
        }

        return null;
    }

    public static igObject? FindObjectByType(this igObjectList obj, Type targetType) {
        return obj.FirstOrDefault(targetIgObj => targetIgObj.GetType() == targetType);
    }

    public static (short scaledX, short scaledY, short scaledZ, short scaleFactor) ScaleToShortBounds(float x, float y, float z) {
        // Find the maximum absolute value among the coordinates
        var maxCoord = Math.Max(Math.Max(Math.Abs(x), Math.Abs(y)), Math.Abs(z));

        // If the maxCoord is zero, avoid division by zero by setting the scale factor to 1
        var scaleFactor = maxCoord == 0 ? 1 : short.MaxValue / maxCoord;

        // Scale the coordinates to fit within the range of a signed short
        var scaledX = x * scaleFactor;
        var scaledY = y * scaleFactor;
        var scaledZ = z * scaleFactor;

        return ((short scaledX, short scaledY, short scaledZ, short scaleFactor))(scaledX, scaledY, scaledZ, scaleFactor);
    }

    public static byte[] PadToMultipleOf16(byte[] inputArray) {
        var length = inputArray.Length;
        var newLength = (length + 15) / 16 * 16;

        var paddedArray = new byte[newLength];
        Array.Copy(inputArray, paddedArray, length);
        return paddedArray;
    }
}