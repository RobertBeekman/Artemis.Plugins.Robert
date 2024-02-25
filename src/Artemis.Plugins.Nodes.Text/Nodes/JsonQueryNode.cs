using Artemis.Core;
using Newtonsoft.Json.Linq;

namespace Artemis.Plugins.Nodes.FileReaders.Nodes
{
    [Node("Query JSON", "Queries JSON with a path.", "Text", InputType = typeof(string), OutputType = typeof(string))]
    public class JsonQueryNode : Node
    {
        private string? _lastInput;
        private string? _lastPath;
        private string? _lastOutput;

        public JsonQueryNode()
        {
            Input = CreateInputPin<string>("Input");
            Path = CreateInputPin<string>("Path");
            Output = CreateOutputPin<string>();
        }

        public InputPin<string> Input { get; }
        public InputPin<string> Path { get; }
        public OutputPin<string> Output { get; }

        public override void Evaluate()
        {
            string? input = Input.Value;
            string? path = Path.Value;

            // If nothing changed since last evaluate, reuse last output
            if (_lastInput == input && _lastPath == path)
                Output.Value = _lastOutput;

            _lastInput = input;
            _lastPath = path;
            if (input == null || path == null)
                _lastOutput = null;
            else
                _lastOutput = JObject.Parse(input).SelectToken(path)?.Value<string>();

            Output.Value = _lastOutput;
        }
    }
}