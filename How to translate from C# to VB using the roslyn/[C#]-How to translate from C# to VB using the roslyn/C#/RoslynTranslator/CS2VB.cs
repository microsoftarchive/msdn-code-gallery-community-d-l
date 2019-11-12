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
    public static partial class CS2VB
    {
        public static VB.VisualBasicSyntaxNode Translate(string sourceCode)
        {
            var csTree = CS.CSharpSyntaxTree.ParseText(sourceCode);
            var csRoot = (CS.CSharpSyntaxNode)csTree.GetRoot();

            return Gekka.Roslyn.Translator.CS2VB.Convert(csRoot);
        }


        public static VB.VisualBasicSyntaxNode Convert(this CS.CSharpSyntaxNode node)
        {
            if (node == null)
            {
                return null;
            }

            switch (node.Kind())
            {
            case CS.SyntaxKind.CompilationUnit:
                return ((CSS.CompilationUnitSyntax)node).ConvertCompilationUnit();

            case CS.SyntaxKind.UsingDirective:
                return ((CSS.UsingDirectiveSyntax)node).ConvertUsingDirective();

            #region Block
            case CS.SyntaxKind.NamespaceDeclaration:
                return ((CSS.NamespaceDeclarationSyntax)node).ConvertNamespaceDeclaration();

            case CS.SyntaxKind.ClassDeclaration:
            case CS.SyntaxKind.InterfaceDeclaration:
            case CS.SyntaxKind.StructDeclaration:
                return ((CSS.BaseTypeDeclarationSyntax)node).ConvertTypeDeclaration();

            case CS.SyntaxKind.EnumDeclaration:
                return ((CSS.EnumDeclarationSyntax)node).ConvertEnumDeclaration();

            case CS.SyntaxKind.MethodDeclaration:
                return ((CSS.MethodDeclarationSyntax)node).ConvertMethodDeclaration();

            case CS.SyntaxKind.ConstructorDeclaration:
                return ((CSS.ConstructorDeclarationSyntax)node).ConvertConstructor();

            case CS.SyntaxKind.BaseConstructorInitializer:
            case CS.SyntaxKind.ThisConstructorInitializer:
                return ((CSS.ConstructorInitializerSyntax)node).ConvertConstructorInitializer();

            case CS.SyntaxKind.DestructorDeclaration:
                return ((CSS.DestructorDeclarationSyntax)node).ConvertDestructor();

            case CS.SyntaxKind.Block:
                return ConvertBlock((CSS.BlockSyntax)node);

            #region Field, Property
            case CS.SyntaxKind.EventFieldDeclaration:
                return ((CSS.EventFieldDeclarationSyntax)node).ConvertEventFieldDeclaration();

            case CS.SyntaxKind.EventDeclaration:
                return ((CSS.EventDeclarationSyntax)node).ConvertEventBlock();

            case CS.SyntaxKind.AddAccessorDeclaration:
            case CS.SyntaxKind.RemoveAccessorDeclaration:
                return ConvertEventAccessor((CSS.AccessorDeclarationSyntax)node);

            case CS.SyntaxKind.IndexerDeclaration:
                return ((CSS.IndexerDeclarationSyntax)node).ConvertIndexer();
            case CS.SyntaxKind.PropertyDeclaration:
                return ((CSS.PropertyDeclarationSyntax)node).ConvertProperty();
            case CS.SyntaxKind.GetAccessorDeclaration:
            case CS.SyntaxKind.SetAccessorDeclaration:
                return ((CSS.AccessorDeclarationSyntax)node).ConvertGetSet();
            case CS.SyntaxKind.AccessorList:
                //Need call ConvertAccessorList
                return null;

            case CS.SyntaxKind.FieldDeclaration:
                return ConvertFieldDeclaration((CSS.FieldDeclarationSyntax)node);

            case CS.SyntaxKind.VariableDeclaration:
                return ConvertVariableDeclaration((CSS.VariableDeclarationSyntax)node);

            case CS.SyntaxKind.VariableDeclarator:
                return ConvertVariableDeclarator((CSS.VariableDeclaratorSyntax)node);

            case CS.SyntaxKind.LocalDeclarationStatement:
                return ((CSS.LocalDeclarationStatementSyntax)node).ConvertLocalDeclaration();

            case CS.SyntaxKind.EnumMemberDeclaration:
                return ((CSS.EnumMemberDeclarationSyntax)node).ConvertEnumMemberDeclaration();

            case CS.SyntaxKind.DelegateDeclaration:
                return ((CSS.DelegateDeclarationSyntax)node).ConvertDelegateDeclaration();

            case CS.SyntaxKind.OperatorDeclaration:
                return ((CSS.OperatorDeclarationSyntax)node).ConvertOperator();


            #endregion

            #endregion

            #region Flow
            case CS.SyntaxKind.IfStatement:
                return ((CSS.IfStatementSyntax)node).ConvertIfStatement();

            case CS.SyntaxKind.ElseClause:
                return ((CSS.ElseClauseSyntax)node).ConvertElseClauseStatement();

            case CS.SyntaxKind.SwitchStatement:
                return ((CSS.SwitchStatementSyntax)node).ConvertSwitchStatementAndRewriteGoto();

            case CS.SyntaxKind.SwitchSection:
                return ((CSS.SwitchSectionSyntax)node).ConvertSwitchSelection();

            case CS.SyntaxKind.CaseSwitchLabel:
                return ((CSS.CaseSwitchLabelSyntax)node).ConvertCaseSwitchLabel();

            case CS.SyntaxKind.DefaultSwitchLabel:
                return VB.SyntaxFactory.ElseCaseClause();

            case CS.SyntaxKind.GotoCaseStatement:
            case CS.SyntaxKind.GotoDefaultStatement:
                //Need call ConvertSwitchStatementAndRewriteGoto
                return null;

            case CS.SyntaxKind.GotoStatement:
                return ((CSS.GotoStatementSyntax)node).ConvertGoto();

            case CS.SyntaxKind.LabeledStatement:
                return ((CSS.LabeledStatementSyntax)node).ConvertLabel();

            case CS.SyntaxKind.BreakStatement:
                return ((CSS.BreakStatementSyntax)node).ConvertBreak();

            case CS.SyntaxKind.ContinueStatement:
                return ((CSS.ContinueStatementSyntax)node).ConvertContinue();

            case CS.SyntaxKind.ForStatement:
                return ((CSS.ForStatementSyntax)node).ConvertFor();

            case CS.SyntaxKind.ForEachStatement:
                return ((CSS.ForEachStatementSyntax)node).ConvertForEach();

            case CS.SyntaxKind.DoStatement:
                return ((CSS.DoStatementSyntax)node).ConvertDo();

            case CS.SyntaxKind.WhileStatement:
                return ((CSS.WhileStatementSyntax)node).ConvertWhile();

            case CS.SyntaxKind.ReturnStatement:
                return ((CSS.ReturnStatementSyntax)node).ConvertReturn();

            case CS.SyntaxKind.YieldBreakStatement:
                return VB.SyntaxFactory.ExitFunctionStatement();

            case CS.SyntaxKind.YieldReturnStatement:
                return ((CSS.YieldStatementSyntax)node).ConvertYield();


            #endregion

            #region  try-catch-finally
            case CS.SyntaxKind.ThrowStatement:
                return ((CSS.ThrowStatementSyntax)node).ConvertThrow();

            case CS.SyntaxKind.TryStatement:
                return ((CSS.TryStatementSyntax)node).ConvertTry();

            case CS.SyntaxKind.CatchClause:
                return ((CSS.CatchClauseSyntax)node).ConvertCatchClause();

            case CS.SyntaxKind.CatchDeclaration:
                return ((CSS.CatchDeclarationSyntax)node).ConvertCatchDeclaration();

            case CS.SyntaxKind.CatchFilterClause:
                return ((CSS.CatchFilterClauseSyntax)node).ConvertCatchFilter();

            case CS.SyntaxKind.FinallyClause:
                return ((CSS.FinallyClauseSyntax)node).ConvertFinally();

            #endregion

            #region Attribute

            case CS.SyntaxKind.AttributeList:
                {
                    var csAttributeList = (CSS.AttributeListSyntax)node;
                    var vbAttributes = csAttributeList.Attributes.ConvertSyntaxNodes<VBS.AttributeSyntax>().ToArray();

                    var vbTarget = (VBS.AttributeTargetSyntax)csAttributeList.Target.Convert();

                    if (vbAttributes != null && vbTarget != null)
                    {
                        for (int i = 0; i < vbAttributes.Length; i++)
                        {
                            vbAttributes[i] = vbAttributes[i].WithTarget(vbTarget);
                        }
                    }
                    return VB.SyntaxFactory.AttributeList().AddAttributes(vbAttributes);
                }
            case CS.SyntaxKind.AttributeTargetSpecifier:
                {
                    // https://msdn.microsoft.com/en-us/library/z0w1kczw.aspx
                    var csTarget = (CSS.AttributeTargetSpecifierSyntax)node;
                    var targetText = csTarget.Identifier.ValueText;

                    switch (targetText)
                    {
                    case "assembly":
                        return VB.SyntaxFactory.AttributeTarget(VB.SyntaxFactory.Token(VB.SyntaxKind.AssemblyKeyword));
                    case "module":
                        return VB.SyntaxFactory.AttributeTarget(VB.SyntaxFactory.Token(VB.SyntaxKind.ModuleKeyword));
                    case "field":
                        return VB.SyntaxFactory.AttributeTarget(VB.SyntaxFactory.Token(VB.SyntaxKind.FieldDeclaration));
                    case "event":
                    case "method":
                    case "param":
                    case "property":
                    case "return":
                    case "Type":
                        break;
                    }
                    return null;
                }
            case CS.SyntaxKind.Attribute:
                {
                    var csAttribute = (CSS.AttributeSyntax)node;
                    var vbName = (VBS.NameSyntax)csAttribute.Name.Convert();
                    var vbArgs = (VBS.ArgumentListSyntax)csAttribute.ArgumentList.Convert();
                    var vbAttribute = VB.SyntaxFactory.Attribute(vbName);
                    vbAttribute = vbAttribute.WithArgumentList(vbArgs);
                    return vbAttribute;
                }
            case CS.SyntaxKind.AttributeArgumentList:
                {
                    var csArguments = (CSS.AttributeArgumentListSyntax)node;
                    var vbArgs = csArguments.Arguments.Convert<CSS.AttributeArgumentSyntax, VBS.ArgumentSyntax>().ToArray();
                    return VB.SyntaxFactory.ArgumentList().AddArguments(vbArgs);

                }
            case CS.SyntaxKind.AttributeArgument:
                {
                    var csAttributeArgument = (CSS.AttributeArgumentSyntax)node;
                    var vbExpression = (VBS.ExpressionSyntax)csAttributeArgument.Expression.ConvertAssignRightExpression();
                    var vbNameEQ = (VBS.NameColonEqualsSyntax)csAttributeArgument.NameEquals.Convert();

                    var vbNameColon = (VBS.NameColonEqualsSyntax)csAttributeArgument.NameColon.Convert();
                    if (vbNameColon != null)
                    {
                    }
                    return VB.SyntaxFactory.SimpleArgument(vbExpression).WithNameColonEquals(vbNameEQ);
                }


            case CS.SyntaxKind.NameColon:
                return ((CSS.NameColonSyntax)node).ConvertNameCollon();

            #endregion

            #region Type
            case CS.SyntaxKind.TypeParameterList://genericの型
                return ((CSS.TypeParameterListSyntax)node).ConvertTypeParameterList();

            case CS.SyntaxKind.TypeParameter:
                return ((CSS.TypeParameterSyntax)node).ConvertTypeParameter();

            case CS.SyntaxKind.BaseList://継承の型一覧
                return ((CSS.BaseListSyntax)node).ConvertBaseList();

            case CS.SyntaxKind.SimpleBaseType://単純な型
                return ((CSS.SimpleBaseTypeSyntax)node).ConvertSimpleBaseType();

            case CS.SyntaxKind.TypeArgumentList://ジェネリックの型引数
                return ((CSS.TypeArgumentListSyntax)node).ConvertTypeArgumentList();

            case CS.SyntaxKind.PredefinedType://標準型？
                return ((CSS.PredefinedTypeSyntax)node).ConvertPredefinedTypeType();

            case CS.SyntaxKind.ArrayType://配列
                return ((CSS.ArrayTypeSyntax)node).ConvertArrayType();

            case CS.SyntaxKind.ArrayRankSpecifier://配列型の次元
                return ((CSS.ArrayRankSpecifierSyntax)node).ConvertArrayRank();

            case CS.SyntaxKind.NullableType://Null許容型
                return ((CSS.NullableTypeSyntax)node).ConvertNullableType();

            #endregion

            #region Parameter

            case CS.SyntaxKind.ParameterList://関数等の引数の一覧
                return ((CSS.ParameterListSyntax)node).ConvertParameterList();

            case CS.SyntaxKind.Parameter://関数等の引数
                return ConvertParameter((CSS.ParameterSyntax)node);

            case CS.SyntaxKind.TypeParameterConstraintClause:
                return ((CSS.TypeParameterConstraintClauseSyntax)node).ConvertTypeParameterConstraintClauseSyntax();

            case CS.SyntaxKind.ClassConstraint:
                return VB.SyntaxFactory.ClassConstraint(VB.SyntaxFactory.Token(VB.SyntaxKind.ClassKeyword));

            case CS.SyntaxKind.StructConstraint:
                return VB.SyntaxFactory.StructureConstraint(VB.SyntaxFactory.Token(VB.SyntaxKind.StructureKeyword));

            case CS.SyntaxKind.ConstructorConstraint:
                return VB.SyntaxFactory.NewConstraint(VB.SyntaxFactory.Token(VB.SyntaxKind.NewKeyword));

            case CS.SyntaxKind.TypeConstraint:
                {
                    var csTypeParameterConsraint = (CSS.TypeParameterConstraintSyntax)node;
                    var csTypeConstraint = (CSS.TypeConstraintSyntax)node;
                    var vbType = (VBS.TypeSyntax)csTypeConstraint.Type.Convert();
                    return VB.SyntaxFactory.TypeConstraint(vbType);
                }
            #endregion

            #region Name

            case CS.SyntaxKind.IdentifierName://ユニークな名前
                return ((CSS.IdentifierNameSyntax)node).ConvertIdentifierName();

            case CS.SyntaxKind.GenericName://ジェネリック型の型引数を除いた名前
                return ((CSS.GenericNameSyntax)node).ConvertGenericName();

            case CS.SyntaxKind.QualifiedName://NameSpaceや型名付の名前
                return ((CSS.QualifiedNameSyntax)node).ConvertQualifiedName();

            case CS.SyntaxKind.AliasQualifiedName:
                return ((CSS.AliasQualifiedNameSyntax)node).ConvertAliasQualifiedName();

            #endregion

            #region Expression
            case CS.SyntaxKind.ThisExpression:
                return VB.SyntaxFactory.MeExpression();

            case CS.SyntaxKind.BaseExpression:
                return VB.SyntaxFactory.MyBaseExpression();

            case CS.SyntaxKind.ExpressionStatement:
                return ((CSS.ExpressionStatementSyntax)node).ConvertExpressionStatement();

            case CS.SyntaxKind.DefaultExpression: //default(T)
                return ((CSS.DefaultExpressionSyntax)node).ConvertDefaultExpression();

            case CS.SyntaxKind.CastExpression:
                return ((CSS.CastExpressionSyntax)node).ConvertCast();

            case CS.SyntaxKind.AsExpression:
                return ((CSS.BinaryExpressionSyntax)node).ConvertAs();

            case CS.SyntaxKind.SimpleAssignmentExpression:
                return ((CSS.AssignmentExpressionSyntax)node).ConvertSimpleAssignment();

            case CS.SyntaxKind.AddAssignmentExpression: // +=
            case CS.SyntaxKind.SubtractAssignmentExpression: // -=
            case CS.SyntaxKind.MultiplyAssignmentExpression: // *=
            case CS.SyntaxKind.DivideAssignmentExpression: // /=
            case CS.SyntaxKind.LeftShiftAssignmentExpression: // <<=
            case CS.SyntaxKind.RightShiftAssignmentExpression: // >>=
            case CS.SyntaxKind.ModuloAssignmentExpression: // Mod
            case CS.SyntaxKind.AndAssignmentExpression: // &=
            case CS.SyntaxKind.OrAssignmentExpression: // |=
            case CS.SyntaxKind.ExclusiveOrAssignmentExpression: // ^=
                return ConvertAssignmentExpression((CSS.AssignmentExpressionSyntax)node);

            case CS.SyntaxKind.NameEquals:
                return ((CSS.NameEqualsSyntax)node).ConvertNameEquals();

            case CS.SyntaxKind.EqualsValueClause:
                return ((CSS.EqualsValueClauseSyntax)node).ConvertEqualsValue();

            case CS.SyntaxKind.ObjectCreationExpression:
                return ((CSS.ObjectCreationExpressionSyntax)node).ConvertObjectCreation();

            case CS.SyntaxKind.ObjectInitializerExpression:
                return ((CSS.InitializerExpressionSyntax)node).ConvertObjectCreationInitializer();

            case CS.SyntaxKind.ArrayInitializerExpression://int[] array ={1,2,3} 
                return ((CSS.InitializerExpressionSyntax)node).ConvertArrayInitializer();

            case CS.SyntaxKind.ArrayCreationExpression:
                return ((CSS.ArrayCreationExpressionSyntax)node).ConvertArrayCreation();

            case CS.SyntaxKind.ArgumentList://引数一覧
            case CS.SyntaxKind.BracketedArgumentList://accessing argument for array or indexer
                return ((CSS.BaseArgumentListSyntax)node).ConvertBaeArgumentList();

            case CS.SyntaxKind.BracketedParameterList:// [int a, int b]
                return ((CSS.BracketedParameterListSyntax)node).ConvertBracketedParameter();

            case CS.SyntaxKind.OmittedArraySizeExpression:
                return null;// VB.SyntaxFactory.OmittedArgument();

            case CS.SyntaxKind.Argument:
                return ((CSS.ArgumentSyntax)node).ConvertArgument();

            case CS.SyntaxKind.InvocationExpression:
                return ((CSS.InvocationExpressionSyntax)node).ConvertInvocationExpretion();

            case CS.SyntaxKind.SimpleMemberAccessExpression:
                return ((CSS.MemberAccessExpressionSyntax)node).ConvertMemberAccess();

            case CS.SyntaxKind.ElementAccessExpression:
                return ((CSS.ElementAccessExpressionSyntax)node).ConvertElementAccess();

            case CS.SyntaxKind.ParenthesizedExpression:
                return ((CSS.ParenthesizedExpressionSyntax)node).ConvertParenthesized();

            case CS.SyntaxKind.NullLiteralExpression://null
                return ConvertNullLiteral();

            case CS.SyntaxKind.TrueLiteralExpression:// true
                return ConvertTrueLiteral();

            case CS.SyntaxKind.FalseLiteralExpression:// false
                return ConvertFalseLiteral();

            case CS.SyntaxKind.UnaryPlusExpression:
                return ((CSS.PrefixUnaryExpressionSyntax)node).ConvertUnraryPlus();

            case CS.SyntaxKind.UnaryMinusExpression:
                return ((CSS.PrefixUnaryExpressionSyntax)node).ConvertUnraryMinus();

            case CS.SyntaxKind.NumericLiteralExpression:
                return ((CSS.LiteralExpressionSyntax)node).ConvertLiteral();
            case CS.SyntaxKind.CharacterLiteralExpression:
                return ((CSS.LiteralExpressionSyntax)node).ConvertLiteralChar();
            case CS.SyntaxKind.StringLiteralExpression:
                return ((CSS.LiteralExpressionSyntax)node).ConvertLiteralString();

            case CS.SyntaxKind.TypeOfExpression:
                return ((CSS.TypeOfExpressionSyntax)node).ConvertTypeOf();

            case CS.SyntaxKind.IsExpression: // Is
            case CS.SyntaxKind.AddExpression:// +
            case CS.SyntaxKind.SubtractExpression:// -
            case CS.SyntaxKind.MultiplyExpression:// *
            case CS.SyntaxKind.DivideExpression:// /
            case CS.SyntaxKind.ModuloExpression:// %
            case CS.SyntaxKind.LeftShiftExpression: // <<
            case CS.SyntaxKind.RightShiftExpression: // >>
            case CS.SyntaxKind.BitwiseAndExpression: //&
            case CS.SyntaxKind.BitwiseOrExpression:  //|
            case CS.SyntaxKind.ExclusiveOrExpression: // ^
            case CS.SyntaxKind.LogicalAndExpression: //&&
            case CS.SyntaxKind.LogicalOrExpression: //||
            case CS.SyntaxKind.EqualsExpression: // ==
            case CS.SyntaxKind.NotEqualsExpression: // !=
            case CS.SyntaxKind.GreaterThanExpression: // >
            case CS.SyntaxKind.GreaterThanOrEqualExpression: // >=
            case CS.SyntaxKind.LessThanExpression: // <
            case CS.SyntaxKind.LessThanOrEqualExpression: // <=
            case CS.SyntaxKind.CoalesceExpression: // ??
                return ConvertBinaryExpression((CSS.BinaryExpressionSyntax)node);

            case CS.SyntaxKind.BitwiseNotExpression: // !
            case CS.SyntaxKind.LogicalNotExpression: // ~
                return ((CSS.PrefixUnaryExpressionSyntax)node).ConvertNot();

            case CS.SyntaxKind.PreIncrementExpression: // ++A
                return ((CSS.PrefixUnaryExpressionSyntax)node).ConvertPreIncrement();
            case CS.SyntaxKind.PreDecrementExpression: // --A
                return ((CSS.PrefixUnaryExpressionSyntax)node).ConvertPreDecrement();
            case CS.SyntaxKind.PostIncrementExpression: // A++
                return ((CSS.PostfixUnaryExpressionSyntax)node).ConvertPostIncrement();
            case CS.SyntaxKind.PostDecrementExpression: // A--
                return ((CSS.PostfixUnaryExpressionSyntax)node).ConvertPostDecrement();

            case CS.SyntaxKind.ConditionalExpression: // ?:
                return ((CSS.ConditionalExpressionSyntax)node).ConvertConditional();


            case CS.SyntaxKind.AnonymousObjectCreationExpression:
                return ((CSS.AnonymousObjectCreationExpressionSyntax)node).ConvertAnonymousObjectCreationExpressionSyntax();
            case CS.SyntaxKind.AnonymousObjectMemberDeclarator:
                return ((CSS.AnonymousObjectMemberDeclaratorSyntax)node).ConvertAnonymousObjectMemberDeclaratorSyntax();

            #endregion

            case CS.SyntaxKind.ExplicitInterfaceSpecifier:
                return ((CSS.ExplicitInterfaceSpecifierSyntax)node).ConvertExplicitInterfaceSpecifier();

            case CS.SyntaxKind.UsingStatement:
                return ((CSS.UsingStatementSyntax)node).ConvertUsingBlock();

            case CS.SyntaxKind.LockStatement:
                return ((CSS.LockStatementSyntax)node).ConvertLock();

            case CS.SyntaxKind.EmptyStatement:
                return VB.SyntaxFactory.EmptyStatement();

            #region Lambda

            case CS.SyntaxKind.ConversionOperatorDeclaration:
                return ((CSS.ConversionOperatorDeclarationSyntax)node).ConvertConversionOperator();

            case CS.SyntaxKind.ParenthesizedLambdaExpression:
            case CS.SyntaxKind.SimpleLambdaExpression:
                return ((CSS.LambdaExpressionSyntax)node).ConvertLambdaExpression();

            #endregion

            case CS.SyntaxKind.InterpolatedStringExpression:
                if (true)
                {
                    //Convert to flat Interpolate 
                    return ((CSS.InterpolatedStringExpressionSyntax)node).ConvertInterpolatedStringExpression();
                }
                else
                {
                    //Convert to nested Interpolate
                    var nodex = (CSS.InterpolatedStringExpressionSyntax)node;
                    var vbContents = nodex.Contents.ConvertSyntaxNodes<VBS.InterpolatedStringContentSyntax>();
                    return VB.SyntaxFactory.InterpolatedStringExpression().AddContents(vbContents.ToArray());
                }
            case CS.SyntaxKind.InterpolationAlignmentClause:
                return ((CSS.InterpolationAlignmentClauseSyntax)node).ConvertInterpolationAlignmentClause();

            case CS.SyntaxKind.InterpolatedStringText:
                return ((CSS.InterpolatedStringTextSyntax)node).ConvertInterpolatedStringText();

            case CS.SyntaxKind.Interpolation:
                return ((CSS.InterpolationSyntax)node).ConvertInterpolation();

            case CS.SyntaxKind.InterpolationFormatClause:
                return ((CSS.InterpolationFormatClauseSyntax)node).ConvertInterpolationFormatClause();


            case CS.SyntaxKind.AnonymousMethodExpression:
                {
                    var xx=((CSS.AnonymousMethodExpressionSyntax)node);
                    //public event EventHandler EV = delegate{};
                    var y=xx.Body.Convert() as VBS.WithBlockSyntax;
                    if (y != null)
                    {
                        var end=VB.SyntaxFactory.EndBlockStatement(VB.SyntaxKind.EndFunctionStatement, VB.SyntaxFactory.Token(VB.SyntaxKind.FunctionKeyword));
                        return VB.SyntaxFactory.MultiLineFunctionLambdaExpression(VB.SyntaxFactory.FunctionLambdaHeader(), end)
                            .WithStatements(new SyntaxList<VBS.StatementSyntax>().Add(y));
                    }
                }
                break;
            default:
                System.Diagnostics.Debug.WriteLine(node.Kind());
                break;

            }
            return null;
        }

        public static void ResetCounter()
        {
            ContinueForRewriter.ResetCounter();
            GotoCaseRewriter.ResetCounter();
        }
    }

}
