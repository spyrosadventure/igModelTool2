namespace CauldronModels;

public class MissingFieldException : Exception {
    
    public MissingFieldException(string? message) : base("the field '" + message + "' is missing") {}
}