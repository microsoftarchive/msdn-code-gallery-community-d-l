// Copyright 2015 gekka.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using CS = Microsoft.CodeAnalysis.CSharp;
using CSS = Microsoft.CodeAnalysis.CSharp.Syntax;
using VB = Microsoft.CodeAnalysis.VisualBasic;
using VBS = Microsoft.CodeAnalysis.VisualBasic.Syntax;


namespace Gekka.Roslyn.Translator
{
    static partial class CS2VB
    {
        class ContinueForRewriter : VB.VisualBasicSyntaxRewriter
        {
            public static uint CreateNumber()
            {
                return (uint)Math.Abs(System.Threading.Interlocked.Increment(ref _ContinueForNumber));
            }
            private static int _ContinueForNumber;
            public static void ResetCounter()
            {
                _ContinueForNumber = 0;
            }

            public ContinueForRewriter(VBS.ForBlockSyntax vbFor, string gotoLabel)
            {
                if (vbFor == null) throw new ArgumentNullException("vbFor");

                this._vbFor = vbFor;
                this.Label = gotoLabel;
            }
            private VBS.ForBlockSyntax _vbFor;
            public string Label { get; private set; }
            public bool HasContinueFor { get; private set; }

            public override SyntaxNode VisitContinueStatement(VBS.ContinueStatementSyntax node)
            {
                if (node.BlockKeyword.IsKind(VB.SyntaxKind.ForKeyword))
                {
                    SyntaxNode parent = node.Parent;
                    while (node != null)
                    {
                        if (parent.IsKind(VB.SyntaxKind.ForEachBlock))
                        {
                            break;
                        }
                        if (parent.IsKind(VB.SyntaxKind.ForBlock))
                        {
                            if (parent == this._vbFor)
                            {
                                HasContinueFor = true;
                                var vbLabel = VB.SyntaxFactory.IdentifierLabel(Label);
                                return VB.SyntaxFactory.GoToStatement(vbLabel);
                            }
                            else
                            {
                            }
                            break;
                        }
                        parent = parent.Parent;
                    }
                }

                return base.VisitContinueStatement(node);

            }
        }
    }
}
