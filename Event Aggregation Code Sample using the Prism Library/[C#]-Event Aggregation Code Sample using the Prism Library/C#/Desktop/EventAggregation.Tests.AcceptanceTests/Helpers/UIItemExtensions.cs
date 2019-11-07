// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.UIItems;
using System.Windows.Automation;
using Core.UIItems.TabItems;

namespace EventAggregation.AcceptanceTests.Helpers
{
    public static class UIItemExtensions
    {
        public static void Hover(this UIItem uiItem)
        {
            Core.InputDevices.Mouse.Instance.Location = Core.C.Center(uiItem.Bounds);
            System.Threading.Thread.Sleep(1000);
        }
        private static List<AutomationElement> automationElementList = new List<AutomationElement>();

        public static AutomationElement SearchInRawTreeByName(this AutomationElement rootElement, string name)
        {
            AutomationElement elementNode = TreeWalker.RawViewWalker.GetFirstChild(rootElement);

            while (elementNode != null)
            {
                if (name.Equals(elementNode.Current.Name, StringComparison.OrdinalIgnoreCase)
                      || (name.Equals(elementNode.Current.AutomationId, StringComparison.OrdinalIgnoreCase)))
                {
                    return elementNode;
                }
                AutomationElement returnedAutomationElement = elementNode.SearchInRawTreeByName(name);
                if (returnedAutomationElement != null)
                {
                    return returnedAutomationElement;
                }
                elementNode = TreeWalker.RawViewWalker.GetNextSibling(elementNode);
            }
            return null;
        }


        public static List<AutomationElement> FindSiblingsInTreeByName(this AutomationElement rootElement, string name)
        {
            // Clear the automation element list.
            automationElementList.Clear();
            AutomationElement parentElement = rootElement;

            WalkThroughRawTreeAndPopulateAEList(parentElement, name);

            return automationElementList;            
        }

        private static void WalkThroughRawTreeAndPopulateAEList(AutomationElement parentElement, string name)
        {
            AutomationElement element = SearchInRawTreeByName(parentElement, name);
            AutomationElement elementNode = null;
            if (element != null)
            {
                // Add the element to the list;
                automationElementList.Add(element);

                elementNode = TreeWalker.RawViewWalker.GetNextSibling(element);
                while (elementNode != null)
                {
                    // Add the elementNode to the list
                    if (elementNode.Current.AutomationId.Equals(name))
                        automationElementList.Add(elementNode);
                    else
                    {
                        WalkThroughRawTreeAndPopulateAEList(elementNode, name);
                    }
                    elementNode = TreeWalker.RawViewWalker.GetNextSibling(elementNode);
                }
            }
        }


        public static void SelectEmployee(this ListView list, int rowNumber)
        {
            list.Rows[rowNumber].Select();
        }

        public static void SelectEmployee(this ListView list, string firstName)
        {
            list.Rows.Find(r => r.Cells[0].Text.Equals(firstName)).Select();
        }

        public static void SelectEmployee(this ListView list, string firstName, string lastName)
        {
            list.Rows.Find(r => r.Cells[0].Text.Equals(firstName) && r.Cells[1].Text.Equals(lastName)).Select();
        }
    }
}
