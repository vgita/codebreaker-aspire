namespace Codebreaker.Data.SqlServer;

public static class MappingExtensions
{
    public static string ToFieldsString(this IDictionary<string, IEnumerable<string>> fields)
    {
        return string.Join(
            '#', fields.SelectMany(
                key => key.Value
                    .Select(value => $"{key.Key}:{value}")));
    }

    public static IDictionary<string, IEnumerable<string>> FromFieldsString(this string fieldsString)
    {
        Dictionary<string, List<string>> fields = [];

        foreach (string pair in fieldsString.Split('#'))
        {
            int index = pair.IndexOf(':');

            if (index < 0)
            {
                throw new ArgumentException($"Field {pair} does not contain ':' delimiter.");
            }

            string key = pair[..index];
            string value = pair[(index + 1)..];

            if (!fields.TryGetValue(key, out List<string>? list))
            {
                list = [];
                fields[key] = list;
            }

            list.Add(value);
        }

        return fields.ToDictionary(
            pair => pair.Key,
            pair => (IEnumerable<string>)pair.Value);
    }
}
