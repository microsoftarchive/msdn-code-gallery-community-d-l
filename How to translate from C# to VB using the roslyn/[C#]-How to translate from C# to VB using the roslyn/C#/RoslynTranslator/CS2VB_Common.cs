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
        #region

        static SyntaxList<T> ConvertToSyntaxList<T>(this IEnumerable<T> source) where T : SyntaxNode
        {
            SyntaxList<T> list = new SyntaxList<T>();
            return list.AddRange(source);
        }

        static SyntaxList<TV> ConvertSyntaxNodes<TV>(this IEnumerable<CS.CSharpSyntaxNode> cs)
            where TV : VB.VisualBasicSyntaxNode
        {
            SyntaxList<TV> retval = new SyntaxList<TV>();
            foreach (var c in cs)
            {
                TV b = (TV)c.Convert();
                if (b != null)
                {
                    retval = retval.Add(b);
                }
            }
            return retval;
        }
        static SyntaxList<VB.VisualBasicSyntaxNode> ConvertSyntaxNodes(this IEnumerable<CS.CSharpSyntaxNode> cs)
        {
            SyntaxList<VB.VisualBasicSyntaxNode> retval = new SyntaxList<VB.VisualBasicSyntaxNode>();
            foreach (var c in cs)
            {
                VB.VisualBasicSyntaxNode b = (VB.VisualBasicSyntaxNode)c.Convert();
                if (b != null)
                {
                    retval = retval.Add(b);
                }
            }
            return retval;
        }

        static SyntaxList<TV> Convert<TC, TV>(this IEnumerable<TC> cs)
            where TC : CS.CSharpSyntaxNode
            where TV : VB.VisualBasicSyntaxNode
        {
            SyntaxList<TV> retval = new SyntaxList<TV>();
            foreach (var c in cs)
            {
                TV b = (TV)c.Convert();
                if (b != null)
                {
                    retval = retval.Add(b);
                }
            }
            return retval;
        }

        static SyntaxList<TV> Convert<TC, TV>(this SyntaxList<TC> cs)
            where TC : CS.CSharpSyntaxNode
            where TV : VB.VisualBasicSyntaxNode
        {
            return Convert<TC, TV>((IEnumerable<TC>)cs);
        }

        static SyntaxList<TV> ConvertStatements<TV>(this SyntaxList<CSS.StatementSyntax> csStatements) where TV : VBS.StatementSyntax
        {
            return Convert<CSS.StatementSyntax, TV>(SplitLabeledStatement(csStatements));
        }
        private static IEnumerable<CSS.StatementSyntax> SplitLabeledStatement(IEnumerable<CSS.StatementSyntax> source)
        {
            if (source != null)
            {
                foreach (CSS.StatementSyntax csStatement in source)
                {
                    if (csStatement.IsKind(CS.SyntaxKind.LabeledStatement))
                    {
                        //Label in CSharp has connected to the next statement.
                        //But, Label in VB is Separated.
                        var csLabel = (CSS.LabeledStatementSyntax)csStatement;
                        yield return csLabel;
                        yield return csLabel.Statement;
                    }
                    else
                    {
                        yield return csStatement;
                    }
                }
            }

        }


        static SyntaxTokenList ConvertModifiers(SyntaxTokenList csmodifiers)
        {
            SyntaxTokenList retvals = VB.SyntaxFactory.TokenList();

            foreach (SyntaxToken csmodifier in csmodifiers)
            {
                foreach (KeywordPair pair in Keyword.ModifirePairs)
                {
                    if (csmodifier.IsKind(pair.CS))
                    {
                        if (pair.Targets != AttributeTargets.All)
                        {
                            SyntaxNode parent = csmodifier.Parent;
                            if (((pair.Targets & AttributeTargets.Class) == AttributeTargets.Class)
                                ^ parent.IsKind(CS.SyntaxKind.ClassDeclaration))
                            {
                                continue;
                            }
                        }

                        retvals = retvals.Add(VB.SyntaxFactory.Token(pair.VB));
                        break;
                    }
                }
            }
            return retvals;
        }
        static SyntaxToken ConvertModifier(SyntaxToken csmodifier)
        {
            foreach (KeywordPair pair in Keyword.ModifirePairs)
            {
                if (csmodifier.IsKind(pair.CS))
                {
                    if (pair.Targets != AttributeTargets.All)
                    {
                        SyntaxNode parent = csmodifier.Parent;
                        if (((pair.Targets & AttributeTargets.Class) == AttributeTargets.Class)
                            ^ parent.IsKind(CS.SyntaxKind.ClassDeclaration))
                        {
                            continue;
                        }
                    }

                    return VB.SyntaxFactory.Token(pair.VB);
                }
            }
            return default(SyntaxToken);
        }

        static SyntaxTokenList ConvertModifiersWithDefault(SyntaxTokenList csmodifiers, SyntaxToken? defaultModifire = null)
        {
            SyntaxTokenList retvals = ConvertModifiers(csmodifiers);
            if (retvals.Count == 0 && defaultModifire != null)
            {
                retvals = retvals.Add(defaultModifire.Value);
            }
            return retvals;

        }

        static SplitInheritResult SplitInherit(this VBS.InheritsStatementSyntax vbInheritTypes, bool interfaceIsStartWithI)
        {
            SplitInheritResult retval = new SplitInheritResult();
            SyntaxList<VBS.InheritsStatementSyntax> vbInherits = new SyntaxList<VBS.InheritsStatementSyntax>();
            SyntaxList<VBS.ImplementsStatementSyntax> vbImplements = new SyntaxList<VBS.ImplementsStatementSyntax>();

            if (vbInheritTypes != null && vbInheritTypes.Types.Count > 0)
            {
                VBS.TypeSyntax vbType0 = vbInheritTypes.Types[0];
                string name = string.Empty;
                if (vbType0.IsKind(VB.SyntaxKind.QualifiedName))
                {
                    name = ((VBS.QualifiedNameSyntax)vbType0).Right.Identifier.Text;
                }
                else if (vbType0.IsKind(VB.SyntaxKind.PredefinedType))
                {
                    name = ((VBS.PredefinedTypeSyntax)vbType0).ToFullString();
                }
                else if (vbType0.IsKind(VB.SyntaxKind.IdentifierName))
                {
                    name = ((VBS.IdentifierNameSyntax)vbType0).Identifier.Text;
                }
                else if (vbType0.IsKind(VB.SyntaxKind.GenericName))
                {
                    name = ((VBS.GenericNameSyntax)vbType0).Identifier.Text;
                }

                bool firstIsInterface = interfaceIsStartWithI && name.StartsWith("I");

                if (!firstIsInterface)
                {
                    retval.Inherits = vbInherits.Add(VB.SyntaxFactory.InheritsStatement(vbInheritTypes.Types[0]));
                }

                int start = firstIsInterface ? 0 : 1;
                foreach (VBS.TypeSyntax vbType in vbInheritTypes.Types.Skip(start))
                {
                    var i = VB.SyntaxFactory.ImplementsStatement(vbType);
                    vbImplements = vbImplements.Add(i);
                }
                retval.Implements = vbImplements;
            }

            return retval;
        }



        static MergeElseIfResult MergeElseIf(VBS.ElseBlockSyntax vbElseBlock, MergeElseIfResult vbElseIfReslult = null)
        {
            if (vbElseIfReslult == null)
            {
                vbElseIfReslult = new MergeElseIfResult();
            }
            vbElseIfReslult.ElseBlock = vbElseBlock;
            if (vbElseBlock != null && vbElseBlock.Statements != null && vbElseBlock.Statements.Count > 0)
            {
                SyntaxList<VBS.StatementSyntax> vbStatements = vbElseBlock.Statements;
                var vbStatement = vbStatements[0];
                if (vbStatement.IsKind(VB.SyntaxKind.MultiLineIfBlock) && vbElseBlock.Statements.Count==1)
                {
                    var vbIf = (VBS.MultiLineIfBlockSyntax)vbStatement;
                    var vbElseIfStatement = VB.SyntaxFactory.ElseIfStatement(vbIf.IfStatement.Condition)
                                                .WithThenKeyword(VB.SyntaxFactory.Token(VB.SyntaxKind.ThenKeyword))
                                                .WithLeadingTrivia(vbIf.IfStatement.GetLeadingTrivia())
                                                .WithTrailingTrivia(vbIf.IfStatement.GetTrailingTrivia());
                                                
                    var vbElseIfBlock = VB.SyntaxFactory.ElseIfBlock(vbElseIfStatement).WithStatements(vbIf.Statements);
                    vbElseIfReslult.ElseIfBlocks.Add(vbElseIfBlock);

                    for (int i = 0; i < vbIf.ElseIfBlocks.Count; i++)
                    {
                        vbElseIfReslult.ElseIfBlocks.Add(vbIf.ElseIfBlocks[i]);
                    }

                    vbElseIfReslult = MergeElseIf(vbIf.ElseBlock, vbElseIfReslult);
                    vbElseIfReslult.End = vbIf.EndIfStatement;
                }
                else
                {
                    vbElseIfReslult.ElseBlock = vbElseBlock;
                }
            }
            
            return vbElseIfReslult;
        }




        static VBS.WithBlockSyntax CreateWithNothing()
        {
            return CreateWithNothing(new SyntaxTriviaList());
        }
        static VBS.WithBlockSyntax CreateWithNothing(SyntaxTriviaList vbStatementTriviaList)
        {
            var vbNothing = VB.SyntaxFactory.NothingLiteralExpression(VB.SyntaxFactory.Token(VB.SyntaxKind.NothingKeyword))
                .WithTrailingTrivia(vbStatementTriviaList);
            return VB.SyntaxFactory.WithBlock(VB.SyntaxFactory.WithStatement(vbNothing));
        }
        static SyntaxToken GetDefaultModifiers(this CS.CSharpSyntaxNode node)
        {
            //SyntaxToken vbDefaultModifire;
            if (node.Parent == null || node.Parent.IsKind(CS.SyntaxKind.CompilationUnit) || node.Parent.IsKind(CS.SyntaxKind.NamespaceDeclaration))
            {
                return VB.SyntaxFactory.Token(VB.SyntaxKind.FriendKeyword);
            }
            else
            {
                return VB.SyntaxFactory.Token(VB.SyntaxKind.PrivateKeyword);
            }
        }


        static bool HasKindChildNode(this SyntaxNode startNode, VB.SyntaxKind kind)
        {
            foreach (SyntaxNode node in startNode.ChildNodes())
            {
                if (node.IsKind(kind))
                {
                    return true;
                }
                if (HasKindChildNode(node, kind))
                {
                    return true;
                }
            }
            return false;
        }


		static VBS.NameSyntax CreateNameSyntax(System.Type t)
		{
			var names=t.FullName.Split('.');
			VBS.NameSyntax left = VB.SyntaxFactory.IdentifierName(names[0]);
			foreach (string part in names.Skip(1))
			{
				var right = VB.SyntaxFactory.IdentifierName(part);

				left=VB.SyntaxFactory.QualifiedName(left, right);
			}
			return left;
		}

        #endregion
    }
}
