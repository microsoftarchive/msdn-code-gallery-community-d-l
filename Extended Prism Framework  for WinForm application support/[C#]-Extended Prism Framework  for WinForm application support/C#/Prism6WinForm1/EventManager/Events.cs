using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;

using System.Windows.Forms;

namespace EventManager
{
    public class MenuItemClickEvent : PubSubEvent<string>
    {

    }

    public class NodeClickEvent : PubSubEvent<TreeNode>
    {

    }
    public class AddObjectEvent : PubSubEvent<object>
    {

    }
}