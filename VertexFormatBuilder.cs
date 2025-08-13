using igLibrary.Core;
using igLibrary.Gfx;

namespace CauldronModels;

public class AutomatedVertexFormat {
    
    public readonly Dictionary<IG_VERTEX_USAGE, IG_VERTEX_TYPE> elements;

    public void AddElement(IG_VERTEX_USAGE usage, IG_VERTEX_TYPE type) {
        throw new NotImplementedException();
    }

    public igVertexFormat BuildAlchemyObject() {
        throw new NotImplementedException();
    }

    public igMemory<byte> BuildVertexBuffer(CompiledMesh mesh) {
        throw new NotImplementedException();
    }
}