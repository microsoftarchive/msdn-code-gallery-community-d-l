// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractivityQuickstart.Notifications
{
    public class ItemSelectionNotification : Confirmation
    {
        public ItemSelectionNotification()
        {
            this.Items = new List<string>();
            this.SelectedItem = null;
        }

        public ItemSelectionNotification(IEnumerable<string> items)
            : this()
        {
            foreach(string item in items)
            {
                this.Items.Add(item);
            }
        }

        public IList<string> Items { get; private set; }

        public string SelectedItem { get; set; }
    }
}
