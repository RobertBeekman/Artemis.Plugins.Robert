using Artemis.Core.Nodes;
using Artemis.Plugins.Nodes.Text.Nodes;

namespace Artemis.Plugins.Nodes.Text;

public class TextNodesProvider : NodeProvider
{
    public override void Enable()
    {
        RegisterNodeType<TextFileReaderNode>();
        RegisterNodeType<JsonQueryNode>();
    }

    public override void Disable()
    {
    }
}