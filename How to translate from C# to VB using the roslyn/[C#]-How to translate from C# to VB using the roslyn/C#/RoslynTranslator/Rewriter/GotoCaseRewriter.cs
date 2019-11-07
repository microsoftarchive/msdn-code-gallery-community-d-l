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
        class GotoCaseRewriter : CS.CSharpSyntaxRewriter
        {
            public static uint CreateLabelNumber()
            {
                return (uint)Math.Abs(System.Threading.Interlocked.Increment(ref _LabelNumber));
            }
            private static int _LabelNumber;
            public static void ResetCounter()
            {
                _LabelNumber = 0;
            }

            public GotoCaseRewriter(CSS.SwitchStatementSyntax csSwitch)
            {
                if (csSwitch == null) throw new ArgumentNullException("csSwitch");
                _csSwitch = csSwitch;
            }

            private CSS.SwitchStatementSyntax _csSwitch;

            public bool HasGotoTop { get; private set; }
            public bool HasGotoDefault { get; private set; }
            public string VariantName { get; private set; }
            public string LabelTop { get; private set; }
            public string LabelDefault { get; private set; }

            public override SyntaxNode VisitGotoStatement(CSS.GotoStatementSyntax node)
            {
                if (node.Ancestors().FirstOrDefault(_ => _.IsKind(CS.SyntaxKind.SwitchStatement)) == _csSwitch)
                {
                    bool isGotoCase = node.CaseOrDefaultKeyword.IsKind(CS.SyntaxKind.CaseKeyword);
                    bool isGotoDefault = node.CaseOrDefaultKeyword.IsKind(CS.SyntaxKind.DefaultKeyword);
                    // bool isGotoCaseOrDefault = isGotoCase | isGotoDefault;

                    if (isGotoCase || isGotoDefault)
                    {
                        if (!HasGotoTop && !HasGotoDefault)
                        {
                            string sNumber = CreateLabelNumber().ToString();
                            VariantName = "__SELECT_VALUE_" + sNumber;
                            LabelTop = "__RETRY_SELECT_" + sNumber;
                            LabelDefault = "__GOTO_DEFALUT_" + sNumber;
                        }

                        HasGotoTop |= isGotoCase;
                        HasGotoDefault |= isGotoDefault;

                        if (isGotoCase)
                        {
                            // "goto case EXPERESSION;"  --> " { VariantName = EXPERESSION;  Goto LabelTop; }"
                            var csVariant = CS.SyntaxFactory.IdentifierName(VariantName);
                            var csAssignExp = CS.SyntaxFactory.AssignmentExpression(CS.SyntaxKind.SimpleAssignmentExpression, csVariant, node.Expression);
                            var csAssignStatement = CS.SyntaxFactory.ExpressionStatement(csAssignExp);
                            var csGotoTop = CS.SyntaxFactory.GotoStatement(CS.SyntaxKind.GotoStatement, CS.SyntaxFactory.IdentifierName(LabelTop));

                            return CS.SyntaxFactory.Block().AddStatements(csAssignStatement, csGotoTop);
                        }
                        else
                        {
                            // "goto default;"  --> "goto LABEL_DEFAULT;" 
                            return CS.SyntaxFactory.GotoStatement(CS.SyntaxKind.GotoStatement, CS.SyntaxFactory.IdentifierName(LabelDefault));
                        }
                    }
                }
                return base.VisitGotoStatement(node);
            }
        }
    }
}
