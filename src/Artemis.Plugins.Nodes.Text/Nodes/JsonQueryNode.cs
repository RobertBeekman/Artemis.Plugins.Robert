using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using Artemis.Core;
using Json.Path;
using Node = Artemis.Core.Node;

namespace Artemis.Plugins.Nodes.Text.Nodes
{
    [Node("Query JSON", "Queries JSON with a path.", "Text", InputType = typeof(string), OutputType = typeof(string), HelpUrl = "https://wiki.artemis-rgb.com/en/guides/user/profiles/nodes/json")]
    public class JsonQueryNode : Node
    {
        private string? _lastInput;
        private string? _lastPath;
        private object? _lastOutput;
        private JsonPath? _path;

        public JsonQueryNode()
        {
            Input = CreateInputPin<string>("Input");
            Path = CreateInputPin<string>("Path");
            Output = CreateOutputPin(typeof(object));
        }

        public InputPin<string> Input { get; }
        public InputPin<string> Path { get; }
        public OutputPin Output { get; }

        public override void Evaluate()
        {
            string? input = Input.Value;
            string? path = Path.Value;

            // If nothing changed since last evaluate, reuse last output
            if (_lastInput == input && _lastPath == path)
                Output.Value = _lastOutput;

            // If the path changed, reparse it
            if (_lastPath != path && path != null)
            {
                _lastPath = path;
                _path = JsonPath.Parse(path, new PathParsingOptions {TolerateExtraWhitespace = true, AllowJsonConstructs = true});
            }

            _lastInput = input;
            if (input == null || _path == null)
                _lastOutput = null;
            else
            {
                JsonNode? match = _path.Evaluate(JsonNode.Parse(input)).Matches?.FirstOrDefault()?.Value;
                if (match != null)
                {
                    SetOutputPinType(match.GetValueKind());

                    if (Output.Type == typeof(string))
                        _lastOutput = match.GetValue<string>();
                    else if (Output.Type == typeof(Numeric))
                        _lastOutput = new Numeric(match.GetValue<float>());
                    else if (Output.Type == typeof(bool))
                        _lastOutput = match.GetValue<bool>();
                }
                else
                {
                    _lastOutput = null;
                }
            }

            Output.Value = _lastOutput;
        }

        private void SetOutputPinType(JsonValueKind type)
        {
            switch (type)
            {
                case JsonValueKind.Undefined:
                case JsonValueKind.Object:
                case JsonValueKind.Array:
                case JsonValueKind.String:
                case JsonValueKind.Null:
                    Output.ChangeType(typeof(string));
                    break;
                case JsonValueKind.Number:
                    Output.ChangeType(typeof(Numeric));
                    break;
                case JsonValueKind.True:
                    Output.ChangeType(typeof(bool));
                    break;
                case JsonValueKind.False:
                    Output.ChangeType(typeof(bool));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}