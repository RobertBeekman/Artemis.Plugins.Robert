using System;
using Artemis.Core;
using Newtonsoft.Json.Linq;

namespace Artemis.Plugins.Nodes.Text.Nodes
{
    [Node("Query JSON", "Queries JSON with a path.", "Text", InputType = typeof(string), OutputType = typeof(string), HelpUrl = "https://wiki.artemis-rgb.com/en/guides/user/profiles/nodes/json")]
    public class JsonQueryNode : Node
    {
        private string? _lastInput;
        private string? _lastPath;
        private object? _lastOutput;

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

            _lastInput = input;
            _lastPath = path;
            if (input == null || path == null)
                _lastOutput = null;
            else
            {
                JToken? match = JObject.Parse(input).SelectToken(path);
                if (match != null)
                {
                    SetOutputPinType(match.Type);

                    if (Output.Type == typeof(string))
                        _lastOutput = match.Value<string>();
                    else if (Output.Type == typeof(Numeric))
                        _lastOutput = new Numeric(match.Value<float>());
                    else if (Output.Type == typeof(bool))
                        _lastOutput = match.Value<bool>();
                    else if (Output.Type == typeof(DateTime))
                        _lastOutput = match.Value<DateTime>();
                    else if (Output.Type == typeof(TimeSpan))
                        _lastOutput = match.Value<TimeSpan>();
                }
                else
                {
                    _lastOutput = null;
                }
            }

            Output.Value = _lastOutput;
        }

        private void SetOutputPinType(JTokenType type)
        {
            switch (type)
            {
                case JTokenType.None:
                case JTokenType.Object:
                case JTokenType.Array:
                case JTokenType.Constructor:
                case JTokenType.Property:
                case JTokenType.Comment:
                case JTokenType.String:
                case JTokenType.Null:
                case JTokenType.Undefined:
                case JTokenType.Uri:
                case JTokenType.Raw:
                case JTokenType.Guid:
                    Output.ChangeType(typeof(string));
                    break;
                case JTokenType.Integer:
                case JTokenType.Float:
                case JTokenType.Bytes:
                    Output.ChangeType(typeof(Numeric));
                    break;
                case JTokenType.Boolean:
                    Output.ChangeType(typeof(bool));
                    break;
                case JTokenType.Date:
                    Output.ChangeType(typeof(DateTime));
                    break;
                case JTokenType.TimeSpan:
                    Output.ChangeType(typeof(TimeSpan));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}