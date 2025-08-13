using System.Numerics;
using Silk.NET.Assimp;

namespace CauldronModels;

public class Vertex {
    public const int MaxBoneInfluence = 4;

    public Vector3 pos;
    public Vector3 normal;
    public Vector3 tangent;
    public Vector3 bitangent;
    public Vector3 color;
    public Vector2 uv;
    public int[] boneIds;
    public float[] boneWeights;
    
}

public class TextureReference {
    public readonly string path; // release me

    public TextureReference(string path) {
        this.path = path;
    }
}

public class CompiledMesh {
    public readonly List<Vertex> vertices;
    public readonly List<uint> indices;
    public readonly List<TextureReference> textures;

    public CompiledMesh(List<Vertex> buildVertices, List<uint> buildIndices, List<TextureReference> textures) {
        this.vertices = buildVertices;
        this.indices = buildIndices;
        this.textures = textures;
    }
}

public class Model {
    public Model(string path) {
        var assimp = Assimp.GetApi();
        _assimp = assimp;
        LoadModel(path);
    }

    private Assimp _assimp;
    private List<Texture> _texturesLoaded = new();
    public string Directory { get; protected set; } = string.Empty;
    public List<CompiledMesh> Meshes { get; } = new();

    private unsafe void LoadModel(string path) {
        var scene = _assimp.ImportFile(path, (uint)PostProcessSteps.Triangulate);

        if (scene == null || scene->MFlags == Silk.NET.Assimp.Assimp.SceneFlagsIncomplete || scene->MRootNode == null) {
            var error = _assimp.GetErrorStringS();
            throw new Exception(error);
        }

        Directory = path;

        ProcessNode(scene->MRootNode, scene);
    }

    private unsafe void ProcessNode(Node* node, Scene* scene) {
        for (var i = 0; i < node->MNumMeshes; i++) {
            var mesh = scene->MMeshes[node->MMeshes[i]];
            Meshes.Add(ProcessMesh(mesh, scene));
        }

        for (var i = 0; i < node->MNumChildren; i++) {
            ProcessNode(node->MChildren[i], scene);
        }
    }

    private unsafe CompiledMesh ProcessMesh(Mesh* mesh, Scene* scene) {
        // data to fill
        List<Vertex> vertices = new List<Vertex>();
        var indices = new List<uint>();
        List<TextureReference> textures = new List<TextureReference>();

        // walk through each of the mesh's vertices
        for (uint i = 0; i < mesh->MNumVertices; i++) {
            var vertex = new Vertex();
            vertex.boneIds = new int[Vertex.MaxBoneInfluence];
            vertex.boneWeights = new float[Vertex.MaxBoneInfluence];

            vertex.pos = mesh->MVertices[i];

            // normals
            if (mesh->MNormals != null)
                vertex.normal = mesh->MNormals[i];
            // tangent
            if (mesh->MTangents != null)
                vertex.tangent = mesh->MTangents[i];
            // bitangent
            if (mesh->MBitangents != null)
                vertex.bitangent = mesh->MBitangents[i];

            // texture coordinates
            if (mesh->MTextureCoords[0] != null) // does the mesh contain texture coordinates?
            {
                // a vertex can contain up to 8 different texture coordinates. We thus make the assumption that we won't 
                // use models where a vertex can have multiple texture coordinates so we always take the first set (0).
                var texcoord3 = mesh->MTextureCoords[0][i];
                vertex.uv = new Vector2(texcoord3.X, texcoord3.Y);
            }

            vertices.Add(vertex);
        }

        // now wak through each of the mesh's faces (a face is a mesh its triangle) and retrieve the corresponding vertex indices.
        for (uint i = 0; i < mesh->MNumFaces; i++) {
            var face = mesh->MFaces[i];
            // retrieve all indices of the face and store them in the indices vector
            for (uint j = 0; j < face.MNumIndices; j++)
                indices.Add(face.MIndices[j]);
        }

        // process materials
        var material = scene->MMaterials[mesh->MMaterialIndex];
        // we assume a convention for sampler names in the shaders. Each diffuse texture should be named
        // as 'texture_diffuseN' where N is a sequential number ranging from 1 to MAX_SAMPLER_NUMBER. 
        // Same applies to other texture as the following list summarizes:
        // diffuse: texture_diffuseN
        // specular: texture_specularN
        // normal: texture_normalN

        // 1. diffuse maps
        var diffuseMaps = LoadMaterialTextures(material, TextureType.Diffuse, "texture_diffuse");
        if (diffuseMaps.Any())
            textures.AddRange(diffuseMaps);
        // 2. specular maps
        var specularMaps = LoadMaterialTextures(material, TextureType.Specular, "texture_specular");
        if (specularMaps.Any())
            textures.AddRange(specularMaps);
        // 3. normal maps
        var normalMaps = LoadMaterialTextures(material, TextureType.Height, "texture_normal");
        if (normalMaps.Any())
            textures.AddRange(normalMaps);
        // 4. height maps
        var heightMaps = LoadMaterialTextures(material, TextureType.Ambient, "texture_height");
        if (heightMaps.Any())
            textures.AddRange(heightMaps);

        // return a mesh object created from the extracted mesh data
        var result = new CompiledMesh(vertices, indices, textures);
        return result;
    }

    private unsafe List<TextureReference> LoadMaterialTextures(Material* mat, TextureType type, string typeName) {
        var textureCount = _assimp.GetMaterialTextureCount(mat, type);
        var textures = new List<TextureReference>();
        for (uint i = 0; i < textureCount; i++) {
            AssimpString path;
            _assimp.GetMaterialTexture(mat, type, i, &path, null, null, null, null, null, null);
            textures.Add(new TextureReference(path.AsString));
        }

        return textures;
    }
}