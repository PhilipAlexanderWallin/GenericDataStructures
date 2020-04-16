namespace GenericDataStructures.Tests
{
    public class ActionValueReader
    {
        public object? ExtractedValue { get; private set; }

        public void ExtractValue<T>(T value)
        {
            ExtractedValue = value;
        }
    }
}
