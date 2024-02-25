using Artemis.Core.Nodes;
using Artemis.Plugins.Nodes.Text.Nodes;

namespace Artemis.Plugins.Nodes.Text;

public class FileReaderNodesProvider : NodeProvider
{
    public override void Enable()
    {
        RegisterNodeType<TextFileReaderNode>();
    }

    public override void Disable()
    {
    }
}