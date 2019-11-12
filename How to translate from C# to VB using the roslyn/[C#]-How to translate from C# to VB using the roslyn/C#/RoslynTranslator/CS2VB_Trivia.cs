// Copyright 2016 gekka.
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
    partial class CS2VB
    {
        enum CSTrivia
        {
            EndOfLineTrivia = CS.SyntaxKind.EndOfLineTrivia,
            WhitespaceTrivia = CS.SyntaxKind.WhitespaceTrivia,
            SingleLineCommentTrivia = CS.SyntaxKind.SingleLineCommentTrivia,
            MultiLineCommentTrivia = CS.SyntaxKind.MultiLineCommentTrivia,
            DocumentationCommentExteriorTrivia = CS.SyntaxKind.DocumentationCommentExteriorTrivia,
            SingleLineDocumentationCommentTrivia = CS.SyntaxKind.SingleLineDocumentationCommentTrivia,
            MultiLineDocumentationCommentTrivia = CS.SyntaxKind.MultiLineDocumentationCommentTrivia,
            DisabledTextTrivia = CS.SyntaxKind.DisabledTextTrivia,
            PreprocessingMessageTrivia = CS.SyntaxKind.PreprocessingMessageTrivia,
            IfDirectiveTrivia = CS.SyntaxKind.IfDirectiveTrivia,
            ElifDirectiveTrivia = CS.SyntaxKind.ElifDirectiveTrivia,
            ElseDirectiveTrivia = CS.SyntaxKind.ElseDirectiveTrivia,
            EndIfDirectiveTrivia = CS.SyntaxKind.EndIfDirectiveTrivia,
            RegionDirectiveTrivia = CS.SyntaxKind.RegionDirectiveTrivia,
            EndRegionDirectiveTrivia = CS.SyntaxKind.EndRegionDirectiveTrivia,
            DefineDirectiveTrivia = CS.SyntaxKind.DefineDirectiveTrivia,
            UndefDirectiveTrivia = CS.SyntaxKind.UndefDirectiveTrivia,
            ErrorDirectiveTrivia = CS.SyntaxKind.ErrorDirectiveTrivia,
            WarningDirectiveTrivia = CS.SyntaxKind.WarningDirectiveTrivia,
            LineDirectiveTrivia = CS.SyntaxKind.LineDirectiveTrivia,
            PragmaWarningDirectiveTrivia = CS.SyntaxKind.PragmaWarningDirectiveTrivia,
            PragmaChecksumDirectiveTrivia = CS.SyntaxKind.PragmaChecksumDirectiveTrivia,
            ReferenceDirectiveTrivia = CS.SyntaxKind.ReferenceDirectiveTrivia,
            BadDirectiveTrivia = CS.SyntaxKind.BadDirectiveTrivia,
            SkippedTokensTrivia = CS.SyntaxKind.SkippedTokensTrivia,

            ShebangDirectiveTrivia = CS.SyntaxKind.ShebangDirectiveTrivia,
            LoadDirectiveTrivia = CS.SyntaxKind.LoadDirectiveTrivia,
        }

        private static SyntaxTrivia ConvertSingleLineComment(SyntaxTrivia csSingleLineCommnent)
        {
            string csMark;
            string vbMark;
            if ((CSTrivia)csSingleLineCommnent.RawKind == CSTrivia.SingleLineCommentTrivia)
            {
                csMark = "//";
                vbMark = "'";
            }
            else
            {
                csMark = "///";
                vbMark = "'''";
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            using (var sr = new System.IO.StringReader(csSingleLineCommnent.ToString()))
            {
                while (sr.Peek() != -1)
                {
                    if (sb.Length > 0)
                    {
                        sb.AppendLine();
                    }
                    sb.Append(vbMark);
                    var line = sr.ReadLine().TrimStart();
                    if (line.StartsWith(csMark))
                    {
                        line = line.Substring(csMark.Length);
                    }

                    sb.Append(line);
                }
            }
            return VB.SyntaxFactory.CommentTrivia(sb.ToString());
        }

        private static SyntaxTrivia ConvertTrivia(this SyntaxTrivia csTrivia)
        {
            switch ((CSTrivia)csTrivia.RawKind)
            {
            case CSTrivia.EndOfLineTrivia:
                break;
            case CSTrivia.WhitespaceTrivia:
                break;
            case CSTrivia.SingleLineCommentTrivia:
                return ConvertSingleLineComment(csTrivia);
            case CSTrivia.MultiLineCommentTrivia:
                break;
            case CSTrivia.DocumentationCommentExteriorTrivia:
                break;
            case CSTrivia.SingleLineDocumentationCommentTrivia:
                return ConvertSingleLineComment(csTrivia);
            case CSTrivia.MultiLineDocumentationCommentTrivia:
                break;
            case CSTrivia.DisabledTextTrivia:
                {
                    string csDisableText = csTrivia.ToFullString();
                    var vbDiableText = Translate(csDisableText).NormalizeWhitespace().ToFullString();
                    return VB.SyntaxFactory.DisabledTextTrivia(vbDiableText);
                }
            case CSTrivia.PreprocessingMessageTrivia:
                break;
            case CSTrivia.IfDirectiveTrivia:
                {
                    var csIf = (CSS.IfDirectiveTriviaSyntax)csTrivia.GetStructure();
                    var vbExpression = csIf.Condition.ConvertExpression();
                    var vbIfToken = VB.SyntaxFactory.Token(VB.SyntaxKind.IfKeyword);
                    var vbIf = VB.SyntaxFactory.IfDirectiveTrivia(vbIfToken, vbExpression);
                    return VB.SyntaxFactory.Trivia(vbIf);
                }
            case CSTrivia.ElifDirectiveTrivia:
                {
                    var csElIf = (CSS.ElifDirectiveTriviaSyntax)csTrivia.GetStructure();
                    var vbExpression = csElIf.Condition.ConvertExpression();
                    var vbElseIfToken = VB.SyntaxFactory.Token(VB.SyntaxKind.ElseIfKeyword);
                    var vbElseIf = VB.SyntaxFactory.IfDirectiveTrivia(vbElseIfToken, vbExpression);
                    return VB.SyntaxFactory.Trivia(vbElseIf);
                }
            case CSTrivia.ElseDirectiveTrivia:
                {
                    var csElse = (CSS.ElseDirectiveTriviaSyntax)csTrivia.GetStructure();
                    var vbElse = VB.SyntaxFactory.ElseDirectiveTrivia();
                    return VB.SyntaxFactory.Trivia(vbElse);
                }
            case CSTrivia.EndIfDirectiveTrivia:
                {
                    var vbEndif = VB.SyntaxFactory.EndIfDirectiveTrivia();
                    return VB.SyntaxFactory.Trivia(vbEndif);
                }
                ;
            case CSTrivia.RegionDirectiveTrivia:
                {
                    var csRegion = (CSS.RegionDirectiveTriviaSyntax)csTrivia.GetStructure();
                    foreach (SyntaxToken token in csRegion.ChildTokens())
                    {
                        if (token != csRegion.HashToken && token != csRegion.RegionKeyword)
                        {
                            string text = "\"" + token.ToFullString().Trim('\r', '\n') + "\"";
                            var vbName = VB.SyntaxFactory.StringLiteralToken(text, text);
                            var vbNameExp = VB.SyntaxFactory.StringLiteralExpression(vbName);

                            var vbRegion = VB.SyntaxFactory.RegionDirectiveTrivia
                                (VB.SyntaxFactory.Token(VB.SyntaxKind.HashToken, null)
                                , VB.SyntaxFactory.Token(VB.SyntaxKind.RegionKeyword, null)
                                , vbName);//BUG?

                            vbRegion = vbRegion.WithName(vbName).NormalizeWhitespace();
                            return VB.SyntaxFactory.Trivia(vbRegion);
                        }
                    }
                }
                break;
            case CSTrivia.EndRegionDirectiveTrivia:
                {
                    var vbEndRegion = VB.SyntaxFactory.EndRegionDirectiveTrivia().NormalizeWhitespace();
                    return VB.SyntaxFactory.Trivia(vbEndRegion);
                }
            case CSTrivia.DefineDirectiveTrivia:
                {
                    var csDefine = (CSS.DefineDirectiveTriviaSyntax)csTrivia.GetStructure();
                    var vbTrue = VB.SyntaxFactory.TrueLiteralExpression(VB.SyntaxFactory.Token(VB.SyntaxKind.TrueKeyword));
                    var vbConst = VB.SyntaxFactory.ConstDirectiveTrivia(csDefine.Name.ConvertID().Text, vbTrue);
                    return VB.SyntaxFactory.Trivia(vbConst);
                }
            case CSTrivia.UndefDirectiveTrivia:
                {
                    var csUnDefine = (CSS.UndefDirectiveTriviaSyntax)csTrivia.GetStructure();
                    var vbFalse = VB.SyntaxFactory.TrueLiteralExpression(VB.SyntaxFactory.Token(VB.SyntaxKind.FalseKeyword));
                    var vbConst = VB.SyntaxFactory.ConstDirectiveTrivia(csUnDefine.Name.ConvertID().Text, vbFalse);
                    vbConst = vbConst.NormalizeWhitespace();
                    return VB.SyntaxFactory.Trivia(vbConst);
                }
            case CSTrivia.ErrorDirectiveTrivia:
            case CSTrivia.WarningDirectiveTrivia:
            case CSTrivia.LineDirectiveTrivia:
                break;
            case CSTrivia.PragmaWarningDirectiveTrivia:
                {
                    var csWarning = (CSS.PragmaWarningDirectiveTriviaSyntax)csTrivia.GetStructure();
                    var vbWarnings = csWarning.ErrorCodes
                            .Select(_ => _.Convert())
                            .OfType<VBS.LiteralExpressionSyntax>()
                            .Select(_ => VB.SyntaxFactory.IdentifierName("CS" + _.Token.ToFullString())) //Not map c# to vb warning
                            .ToArray();
                    var csKeyword = csWarning.DisableOrRestoreKeyword;
                    VBS.DirectiveTriviaSyntax vbDirective;
                    if (csKeyword.IsKind(CS.SyntaxKind.DisableKeyword))
                    {
                        vbDirective = VB.SyntaxFactory.DisableWarningDirectiveTrivia(vbWarnings);
                    }
                    else
                    {
                        vbDirective = VB.SyntaxFactory.EnableWarningDirectiveTrivia(vbWarnings);
                    }
                    return VB.SyntaxFactory.Trivia(vbDirective);

                }
            case CSTrivia.PragmaChecksumDirectiveTrivia:
            case CSTrivia.ReferenceDirectiveTrivia:
            case CSTrivia.BadDirectiveTrivia:
            case CSTrivia.SkippedTokensTrivia:
            case CSTrivia.ShebangDirectiveTrivia:
            case CSTrivia.LoadDirectiveTrivia:
            default:
                break;
            }
            return default(SyntaxTrivia);
        }

        private static SyntaxTriviaList ConvertTriviaList(this SyntaxTriviaList csTriviaList)
        {
            return new SyntaxTriviaList()
                .AddRange(csTriviaList
                            .Select(_ => _.ConvertTrivia())
                            .Where(_ => !_.IsKind(CS.SyntaxKind.None)));
        }

        private static T WithConvertTrivia<T>(this T vbNode, CS.CSharpSyntaxNode csNode) where T : SyntaxNode
        {
            var last = csNode.ChildNodesAndTokens().LastOrDefault();
            if (last.IsKind(CS.SyntaxKind.CloseBraceToken))
            {
                var lastToken = last.AsToken();
                var vbLastTriviaList = ConvertTriviaList(lastToken.LeadingTrivia);
                var vbOldLast = vbNode.ChildNodes().LastOrDefault();
                var vbNewLast = vbOldLast.WithLeadingTrivia(vbLastTriviaList);
                vbNode = vbNode.ReplaceNode(vbOldLast, vbNewLast);
            }
            else if (last.IsKind(CS.SyntaxKind.Block))
            {
                var lastBlock = last.AsNode();
                var vbLastTriviaList = ConvertTriviaList(lastBlock.GetLastToken().LeadingTrivia);
                var vbOldLast = vbNode.ChildNodes().LastOrDefault();
                var vbNewLast = vbOldLast.WithLeadingTrivia(vbLastTriviaList);
                vbNode = vbNode.ReplaceNode(vbOldLast, vbNewLast);
            }

            return (T)vbNode.WithLeadingTrivia(csNode.GetLeadingTrivia().ConvertTriviaList())
                         .WithTrailingTrivia(csNode.GetTrailingTrivia().ConvertTriviaList());
        }

        private static SyntaxList<VBS.StatementSyntax> WithConvertedTrivia(this SyntaxList<VBS.StatementSyntax> vbStatements, CSS.BlockSyntax csBlock)
        {
            var last = csBlock.ChildNodesAndTokens().LastOrDefault();
            if (last != null)
            {
                if (last.IsKind(CS.SyntaxKind.CloseBraceToken))
                {
                    var lastToken = last.AsToken();
                    var vbLastTriviaList = ConvertTriviaList(lastToken.LeadingTrivia);
                    var vbOldLast = vbStatements.Last();
                    var vbNewLast = vbOldLast.WithTrailingTrivia(vbOldLast.GetTrailingTrivia().AddRange(vbLastTriviaList));
                    vbStatements = vbStatements.Replace(vbOldLast, vbNewLast);
                }
                else if (last.IsKind(CS.SyntaxKind.Block))
                {
                    var lastBlock = last.AsNode();
                    var vbLastTriviaList = ConvertTriviaList(lastBlock.GetLastToken().LeadingTrivia);
                    var vbOldLast = vbStatements.Last();
                    var vbNewLast = vbOldLast.WithTrailingTrivia(vbLastTriviaList);
                    vbStatements = vbStatements.Replace(vbOldLast, vbNewLast);
                }
            }
            return vbStatements;
        }

        private static SyntaxTriviaList GetOpenBraceTokenTrailingTriviaList(this SyntaxNode csBlock)
        {
            if (csBlock.IsKind(CS.SyntaxKind.Block))
            {
                return ((CSS.BlockSyntax)csBlock).OpenBraceToken.TrailingTrivia.ConvertTriviaList();
            }
            else
            {
                return new SyntaxTriviaList();
            }
        }
        private static SyntaxTriviaList GetCloseBraceTokenLeadingTriviaList(this SyntaxNode csBlock)
        {
            if (csBlock.IsKind(CS.SyntaxKind.Block))
            {
                return ((CSS.BlockSyntax)csBlock).CloseBraceToken.LeadingTrivia.ConvertTriviaList();
            }
            else
            {
                return new SyntaxTriviaList();
            }
        }


    }
}
