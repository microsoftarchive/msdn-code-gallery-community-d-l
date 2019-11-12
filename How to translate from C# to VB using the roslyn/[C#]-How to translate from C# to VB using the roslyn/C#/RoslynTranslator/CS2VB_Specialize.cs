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
    partial class CS2VB
    {
        #region Declaration


        static VBS.CompilationUnitSyntax ConvertCompilationUnit(this CSS.CompilationUnitSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csCompilationUnit = (CSS.CompilationUnitSyntax)node;

            var vbImports = csCompilationUnit.Usings.ConvertSyntaxNodes<VBS.ImportsStatementSyntax>();
            var vbAttributes = csCompilationUnit.AttributeLists.ConvertAttributes();
            var vbAttributeStatement = VB.SyntaxFactory.AttributesStatement(vbAttributes);
            var vbmembers = csCompilationUnit.Members.ConvertMembers();

            var vbCompilationUnit = VB.SyntaxFactory.CompilationUnit();
            vbCompilationUnit = vbCompilationUnit.AddImports(vbImports.ToArray());
            vbCompilationUnit = vbCompilationUnit.AddAttributes(vbAttributeStatement);
            vbCompilationUnit = vbCompilationUnit.AddMembers(vbmembers.ToArray());

            var csLast = node.ChildNodesAndTokens().Last();
            var vbLast = vbCompilationUnit.ChildNodesAndTokens().Last();
            if (csLast.IsKind(CS.SyntaxKind.EndOfFileToken) && vbLast.IsKind(VB.SyntaxKind.EndOfFileToken))
            {
                var vbEndOfFile = VB.SyntaxFactory.Token(VB.SyntaxKind.EndOfFileToken)
                    .WithLeadingTrivia(ConvertTriviaList(csLast.GetLeadingTrivia()))
                    .WithTrailingTrivia(ConvertTriviaList(csLast.GetTrailingTrivia()));

                vbCompilationUnit = vbCompilationUnit.ReplaceToken((SyntaxToken)vbLast, vbEndOfFile);
            }


            vbCompilationUnit = vbCompilationUnit.WithConvertTrivia(node);

            return vbCompilationUnit;
        }

        static VBS.ImportsStatementSyntax ConvertUsingDirective(this CSS.UsingDirectiveSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csUsing = (CSS.UsingDirectiveSyntax)node;

            var vbAlias = (VBS.ImportAliasClauseSyntax)csUsing.Alias.Convert();
            var vbName = (VBS.NameSyntax)csUsing.Name.Convert();
            var vbImportsClause = VB.SyntaxFactory.SimpleImportsClause(vbAlias, vbName);

            var vbImports = VB.SyntaxFactory.ImportsStatement();
            return vbImports.AddImportsClauses(vbImportsClause);
        }

        static VBS.NamespaceBlockSyntax ConvertNamespaceDeclaration(this CSS.NamespaceDeclarationSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csNamespace = (CSS.NamespaceDeclarationSyntax)node;

            var vbName = (VBS.NameSyntax)csNamespace.Name.Convert();
            var vbNamespaceStatement = VB.SyntaxFactory.NamespaceStatement(vbName);//Namespace ***
            var vbmembers = csNamespace.Members.ConvertMembers().ConvertToSyntaxList();//Namespace
            return VB.SyntaxFactory.NamespaceBlock(vbNamespaceStatement, vbmembers.ConvertToSyntaxList()).WithConvertTrivia(node);
        }

        #region TypeDeclaration

        static VBS.EnumBlockSyntax ConvertEnumDeclaration(this CSS.EnumDeclarationSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csEnum = (CSS.EnumDeclarationSyntax)node;

            var vbAttributes = csEnum.AttributeLists.ConvertAttributes();
            var vbInheritTypes = (VBS.InheritsStatementSyntax)csEnum.BaseList.Convert();
            var vbInheritsAndImplements = vbInheritTypes.SplitInherit(true);
            var vbMembers = csEnum.Members.ConvertMembers();

            SyntaxToken vbDefaultModifier;
            if (csEnum.Parent == null || csEnum.Parent.IsKind(CS.SyntaxKind.CompilationUnit) || csEnum.Parent.IsKind(CS.SyntaxKind.NamespaceDeclaration))
            {
                vbDefaultModifier = VB.SyntaxFactory.Token(VB.SyntaxKind.FriendKeyword);
            }
            else
            {
                vbDefaultModifier = VB.SyntaxFactory.Token(VB.SyntaxKind.PrivateKeyword);
            }

            var vbModifiers = ConvertModifiersWithDefault(csEnum.Modifiers, vbDefaultModifier);
            var vbIdentifier = VB.SyntaxFactory.Identifier(csEnum.Identifier.Text);
            VBS.AsClauseSyntax vbAsClause = null;
            if (vbInheritTypes != null)
            {
                vbAsClause = VB.SyntaxFactory.SimpleAsClause(vbInheritTypes.Types[0]);
            }

            var vbEnumStatement = VB.SyntaxFactory.EnumStatement(vbAttributes, vbModifiers, vbIdentifier, vbAsClause);
            return VB.SyntaxFactory.EnumBlock(vbEnumStatement, vbMembers).WithConvertTrivia(node); ;
        }

        static VBS.TypeBlockSyntax ConvertTypeDeclaration(this CSS.BaseTypeDeclarationSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csType = (CSS.TypeDeclarationSyntax)node;

            var vbAttributes = csType.AttributeLists.ConvertAttributes();
            var vbInhritTypes = (VBS.InheritsStatementSyntax)csType.BaseList.Convert();
            var vbInheritsAndImplements = vbInhritTypes.SplitInherit(true);
            var vbModifiers = ConvertModifiersWithDefault(csType.Modifiers, GetDefaultModifiers(node));
            var vbIdentifier = VB.SyntaxFactory.Identifier(csType.Identifier.Text);
            var vbTypeParameterList = ConvertTypeParameters(csType.TypeParameterList, csType.ConstraintClauses);
            var vbMembers = new SyntaxList<VBS.StatementSyntax>();


            switch (node.Kind())
            {
            case CS.SyntaxKind.ClassDeclaration:
                {
                    vbMembers = vbMembers.AddRange(((CSS.ClassDeclarationSyntax)csType).ConvertClassMembers());

                    bool isModule = false;
                    string strShared = VB.SyntaxFactory.Token(VB.SyntaxKind.SharedKeyword).ToFullString();
                    var shareds = vbModifiers.Where(_ => string.Equals(_.ValueText, strShared, StringComparison.InvariantCultureIgnoreCase)).ToArray();

                    if (shareds.Length > 0)
                    {
                        var extensionAttributeParts = typeof(System.Runtime.CompilerServices.ExtensionAttribute).FullName.Split('.');
                        foreach (VBS.StatementSyntax statement in vbMembers)
                        {
                            if (statement.Kind() == VB.SyntaxKind.FunctionBlock || statement.Kind() == VB.SyntaxKind.SubBlock)
                            {
                                var method = (VBS.MethodBlockSyntax)statement;
                                foreach (VBS.AttributeListSyntax attrs in method.BlockStatement.AttributeLists)
                                {
                                    foreach (VBS.AttributeSyntax attr in attrs.Attributes)
                                    {
                                        var s = attr.ToFullString();
                                        if (!s.EndsWith("Attribute"))
                                        {
                                            s = s + "Attribute";
                                        }
                                        var ss = s.Split('.');
                                        var parts = extensionAttributeParts.Reverse().Take(ss.Length).Reverse();
                                        if (ss.SequenceEqual(ss))
                                        {
                                            isModule = true;
                                            break;
                                        }
                                    }
                                    if (isModule) break;
                                }
                            }
                            if (isModule) break;
                        }
                    }

                    if (isModule)
                    {
                        Func<SyntaxTokenList, SyntaxTokenList> removeShared = (mods) =>
                        {
                            var removed = mods.Where(_ => !string.Equals(_.ValueText, strShared, StringComparison.InvariantCultureIgnoreCase)).ToArray();
                            return new SyntaxTokenList().AddRange(removed);
                        };

                        vbModifiers = removeShared(vbModifiers);

                        SyntaxList<VBS.StatementSyntax> newMembers = new SyntaxList<VBS.StatementSyntax>();
                        foreach (VBS.StatementSyntax statement in vbMembers)
                        {
                            var statementTemp = statement;
                            switch (statement.Kind())
                            {
                            case VB.SyntaxKind.FunctionBlock:
                            case VB.SyntaxKind.SubBlock:
                                var methodBlock = (VBS.MethodBlockSyntax)statement;
                                statementTemp = methodBlock.WithSubOrFunctionStatement(methodBlock.SubOrFunctionStatement.WithModifiers(removeShared(methodBlock.BlockStatement.Modifiers)));
                                break;

                            case VB.SyntaxKind.EventStatement:
                                var es = (VBS.EventStatementSyntax)statement;
                                statementTemp = es.WithModifiers(removeShared(es.Modifiers));

                                break;
                            case VB.SyntaxKind.FieldDeclaration:
                                var field = (VBS.FieldDeclarationSyntax)statement;
                                statementTemp = field.WithModifiers(removeShared(field.Modifiers));
                                break;
                            case VB.SyntaxKind.PropertyStatement:
                                var prop = (VBS.PropertyStatementSyntax)statement;
                                statementTemp = prop.WithModifiers(removeShared(prop.Modifiers));
                                break;
                            case VB.SyntaxKind.PropertyBlock:
                                var propBlock = (VBS.PropertyBlockSyntax)statement;
                                statementTemp = propBlock.WithPropertyStatement(propBlock.PropertyStatement.WithModifiers(propBlock.PropertyStatement.Modifiers));
                                break;
                            default:
                                break;
                            }
                            newMembers = newMembers.Add(statementTemp);
                        }
                        vbMembers = newMembers;




                        return VB.SyntaxFactory.ModuleBlock
                                    (VB.SyntaxFactory.ModuleStatement(vbAttributes, vbModifiers, vbIdentifier, vbTypeParameterList)
                                    , vbInheritsAndImplements.Inherits.ConvertToSyntaxList()
                                    , vbInheritsAndImplements.Implements.ConvertToSyntaxList()
                                    , vbMembers).WithConvertTrivia(node); ;
                    }
                    else
                    {
                        return VB.SyntaxFactory.ClassBlock
                                    (VB.SyntaxFactory.ClassStatement(vbAttributes, vbModifiers, vbIdentifier, vbTypeParameterList)
                                    , vbInheritsAndImplements.Inherits.ConvertToSyntaxList()
                                    , vbInheritsAndImplements.Implements.ConvertToSyntaxList()
                                    , vbMembers).WithConvertTrivia(node); ;
                    }
                }
            case CS.SyntaxKind.InterfaceDeclaration:
                {
                    //remove member's body block
                    //Interfaceは宣言のみなので宣言以外の要素を消す
                    vbMembers = csType.Members.ConvertMembers().ConvertToInterfaceMembers();
                    return VB.SyntaxFactory.InterfaceBlock
                                (VB.SyntaxFactory.InterfaceStatement(vbAttributes, vbModifiers, vbIdentifier, vbTypeParameterList)
                                , vbInheritsAndImplements.Inherits.ConvertToSyntaxList()
                                , vbInheritsAndImplements.Implements.ConvertToSyntaxList()
                                , vbMembers).WithConvertTrivia(node); ;
                }
            case CS.SyntaxKind.StructDeclaration:
                {
                    vbMembers = vbMembers.AddRange(csType.Members.ConvertMembers());
                    return VB.SyntaxFactory.StructureBlock
                                (VB.SyntaxFactory.StructureStatement(vbAttributes, vbModifiers, vbIdentifier, vbTypeParameterList)
                                , vbInheritsAndImplements.Inherits.ConvertToSyntaxList()
                                , vbInheritsAndImplements.Implements.ConvertToSyntaxList()
                                , vbMembers).WithConvertTrivia(node); ;
                }
            default:
                System.Diagnostics.Debug.Assert(false, "ConvertTypeDeclaration");
                return null;
            }
        }

        private static SyntaxList<VBS.StatementSyntax> ConvertToInterfaceMembers(this SyntaxList<VBS.StatementSyntax> vbMembers)
        {
            //Remove Modifiers
            //Remove Method Block (End ***)
            var noModifiers = new SyntaxTokenList();
            var vbMembersCopy = new SyntaxList<VBS.StatementSyntax>();
            foreach (VBS.StatementSyntax vbMember in vbMembers)
            {

                if (vbMember.IsKind(VB.SyntaxKind.SubBlock) || vbMember.IsKind(VB.SyntaxKind.FunctionBlock))
                {
                    var block = (VBS.MethodBlockSyntax)vbMember;
                    var vbStatement = block.SubOrFunctionStatement;
                    vbStatement = vbStatement.WithModifiers(noModifiers);
                    vbMembersCopy = vbMembersCopy.Add(vbStatement);
                }
                else if (vbMember.IsKind(VB.SyntaxKind.PropertyStatement) || vbMember.IsKind(VB.SyntaxKind.PropertyBlock))
                {
                    VBS.PropertyStatementSyntax vbProperty;
                    if (vbMember.IsKind(VB.SyntaxKind.PropertyBlock))
                    {
                        vbProperty = ((VBS.PropertyBlockSyntax)vbMember).PropertyStatement;
                    }
                    else
                    {
                        vbProperty = (VBS.PropertyStatementSyntax)vbMember;
                    }

                    SyntaxToken readOnly = vbProperty.Modifiers.FirstOrDefault(_ => _.IsKind(VB.SyntaxKind.ReadOnlyKeyword));
                    SyntaxToken writeOnly = vbProperty.Modifiers.FirstOrDefault(_ => _.IsKind(VB.SyntaxKind.WriteOnlyKeyword));

                    vbProperty = vbProperty.WithModifiers(noModifiers);
                    if (readOnly.IsKind(VB.SyntaxKind.ReadOnlyKeyword))
                    {
                        vbProperty = vbProperty.AddModifiers(readOnly);
                    }
                    if (writeOnly.IsKind(VB.SyntaxKind.WriteOnlyKeyword))
                    {
                        vbProperty = vbProperty.AddModifiers(writeOnly);
                    }
                    vbMembersCopy = vbMembersCopy.Add(vbProperty);
                }
                else if (vbMember.IsKind(VB.SyntaxKind.EventStatement))
                {
                    var vbEvent = (VBS.EventStatementSyntax)vbMember;
                    vbEvent = vbEvent.WithModifiers(noModifiers);
                    vbMembersCopy = vbMembersCopy.Add(vbEvent);
                }
            }
            return vbMembersCopy;
        }

        private static VBS.TypeParameterListSyntax ConvertTypeParameters
            (CSS.TypeParameterListSyntax csTypeParameterList
            , IEnumerable<CSS.TypeParameterConstraintClauseSyntax> csConstraintClauses)
        {
            var vbTypeParameterList = (VBS.TypeParameterListSyntax)csTypeParameterList.Convert();//ジェネリックの型
            foreach (CSS.TypeParameterConstraintClauseSyntax csConstraintClause in csConstraintClauses)
            {
                var vbConstraint = (VBS.TypeParameterConstraintClauseSyntax)csConstraintClause.Convert();
                CSS.IdentifierNameSyntax genericTypeName = csConstraintClause.Name;

                foreach (VBS.TypeParameterSyntax vbTypeParameter in vbTypeParameterList.Parameters)
                {
                    if (vbTypeParameter.Identifier.Text == csConstraintClause.Name.Identifier.Text)
                    {
                        var vbTypeParameterNew = vbTypeParameter.WithTypeParameterConstraintClause(vbConstraint);
                        var vbTypeParametersNew = vbTypeParameterList.Parameters.Replace(vbTypeParameter, vbTypeParameterNew);
                        vbTypeParameterList = vbTypeParameterList.WithParameters(vbTypeParametersNew);
                        break;
                    }
                }
            }
            return vbTypeParameterList;
        }


        static VBS.ConstructorBlockSyntax ConvertConstructor(this CSS.ConstructorDeclarationSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csConstructor = (CSS.ConstructorDeclarationSyntax)node;
            var vbAttributes = csConstructor.AttributeLists.ConvertAttributes().ConvertToSyntaxList();
            var vbStatements = csConstructor.Body.ConvertBlockOrStatements();
            //var vbID = csConstructor.Identifier.ConvertID();
            var vbInitializer = csConstructor.Initializer.ConvertConstructorInitializer();
            var vbModifiers = ConvertModifiers(csConstructor.Modifiers);
            var vbParameters = (VBS.ParameterListSyntax)csConstructor.ParameterList.Convert();
            if (vbInitializer != null)
            {
                vbStatements = vbStatements.Insert(0, vbInitializer);
            }
            var vbSubNewStatement = VB.SyntaxFactory.SubNewStatement(vbAttributes, vbModifiers, vbParameters);
            var vbNew = VB.SyntaxFactory.ConstructorBlock(vbSubNewStatement, vbStatements);
            return vbNew.WithConvertTrivia(node);
        }

        static VBS.ExpressionStatementSyntax ConvertConstructorInitializer(this CSS.ConstructorInitializerSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csConstructorInitializer = (CSS.ConstructorInitializerSyntax)node;
            var vbArguments = (VBS.ArgumentListSyntax)csConstructorInitializer.ArgumentList.Convert();
            VBS.ExpressionSyntax vbTarget;
            if (node.Kind() == CS.SyntaxKind.BaseConstructorInitializer)
            {
                vbTarget = VB.SyntaxFactory.MyBaseExpression();
            }
            else
            {
                vbTarget = VB.SyntaxFactory.MeExpression();
            }
            var vbMember = VB.SyntaxFactory.IdentifierName(VB.SyntaxFactory.Token(VB.SyntaxKind.NewKeyword).ToFullString());
            var vbExpression = VB.SyntaxFactory.SimpleMemberAccessExpression(vbTarget, vbMember);
            vbTarget = VB.SyntaxFactory.InvocationExpression(vbExpression, vbArguments);
            return VB.SyntaxFactory.ExpressionStatement(vbTarget);
        }

        static VBS.MethodBlockSyntax ConvertDestructor(this CSS.DestructorDeclarationSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csDestructor = (CSS.DestructorDeclarationSyntax)node;
            var vbAttributes = csDestructor.AttributeLists.ConvertAttributes();
            var vbModifiers = new SyntaxTokenList();
            vbModifiers = vbModifiers.Add(VB.SyntaxFactory.Token(VB.SyntaxKind.ProtectedKeyword));
            vbModifiers = vbModifiers.Add(VB.SyntaxFactory.Token(VB.SyntaxKind.OverridesKeyword));

            var vbParameters = (VBS.ParameterListSyntax)csDestructor.ParameterList.Convert();
            var vbStatements = csDestructor.Body.ConvertBlockOrStatements();
            var vbID = VB.SyntaxFactory.IdentifierName("Finalize");//FinalizeKeyword Token not found?
            var vbSubStatement = VB.SyntaxFactory.SubStatement("Finalize")
                                .AddAttributeLists(vbAttributes.ToArray())
                                .AddModifiers(vbModifiers.ToArray())
                                .AddParameterListParameters(vbParameters.Parameters.ToArray());
            return VB.SyntaxFactory.SubBlock(vbSubStatement, vbStatements).WithConvertTrivia(node);
        }

        static VB.VisualBasicSyntaxNode ConvertMethodDeclaration(this CSS.MethodDeclarationSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csMethod = (CSS.MethodDeclarationSyntax)node;

            bool isInterfaceMethod = csMethod.ExplicitInterfaceSpecifier != null;
            bool isSub = (csMethod.ReturnType is CSS.PredefinedTypeSyntax)
                            && ((CSS.PredefinedTypeSyntax)csMethod.ReturnType).Keyword.IsKind(CS.SyntaxKind.VoidKeyword);

            var vbImplements = (VBS.ImplementsClauseSyntax)csMethod.ExplicitInterfaceSpecifier.ConvertExplicitInterfaceSpecifier();

            var vbAttributeListSplit = csMethod.AttributeLists.ConvertAttributesSplit();
            var vbModifiers = ConvertModifiersWithDefault(csMethod.Modifiers);
            var vbIdentifier = VB.SyntaxFactory.Identifier(csMethod.Identifier.Text);
            var vbTypeParameterList = ConvertTypeParameters(csMethod.TypeParameterList, csMethod.ConstraintClauses);

            var vbParameters = (VBS.ParameterListSyntax)csMethod.ParameterList.Convert();
            if (csMethod.ParameterList.Parameters.Count > 0)
            {
                var csParameter = csMethod.ParameterList.Parameters.First();
                if (csParameter.Modifiers.Count(_ => _.IsKind(CS.SyntaxKind.ThisKeyword)) > 0)
                {
                    var name = CreateNameSyntax(typeof(System.Runtime.CompilerServices.ExtensionAttribute));
                    var attribute = VB.SyntaxFactory.Attribute(name);
                    var list = VB.SyntaxFactory.AttributeList().AddAttributes(attribute);
                    vbAttributeListSplit.Others = vbAttributeListSplit.Others.Add(list);
                }
            }


            var vbStatements = csMethod.Body.ConvertBlockStatements();

            if (vbModifiers.Count == 0 && !isInterfaceMethod)
            {
                if (csMethod.Parent.IsKind(CS.SyntaxKind.InterfaceDeclaration))
                {
                    vbModifiers = vbModifiers.Add(VB.SyntaxFactory.Token(VB.SyntaxKind.PublicKeyword));
                }
                else
                {
                    vbModifiers = vbModifiers.Add(VB.SyntaxFactory.Token(VB.SyntaxKind.PrivateKeyword));
                }
            }

            foreach (VBS.StatementSyntax vbStatement in vbStatements)
            {
                if (HasKindChildNode(vbStatement, VB.SyntaxKind.YieldStatement))
                {
                    vbModifiers = vbModifiers.Add(VB.SyntaxFactory.Token(VB.SyntaxKind.IteratorKeyword));
                    break;
                }
            }



            VBS.MethodBlockSyntax vbMethodBlock;
            if (isSub)
            {
                var vbSubStatement = VB.SyntaxFactory.SubStatement(vbAttributeListSplit.Others, vbModifiers, vbIdentifier, vbTypeParameterList, vbParameters, null, null, vbImplements);
                vbMethodBlock = VB.SyntaxFactory.SubBlock(vbSubStatement);
            }
            else
            {
                var vbReturnType = (VBS.TypeSyntax)csMethod.ReturnType.Convert();
                var vbReturnAs = VB.SyntaxFactory.SimpleAsClause(vbAttributeListSplit.Return, vbReturnType);

                var vbFunctionStatement = VB.SyntaxFactory.FunctionStatement(vbAttributeListSplit.Others, vbModifiers, vbIdentifier, vbTypeParameterList, vbParameters, null, null, vbImplements);
                vbFunctionStatement = vbFunctionStatement.WithAsClause(vbReturnAs);
                vbMethodBlock = VB.SyntaxFactory.FunctionBlock(vbFunctionStatement);
            }

            if (csMethod.Modifiers.Count(_ => _.IsKind(CS.SyntaxKind.AbstractKeyword)) > 0)
            {
                return vbMethodBlock.BlockStatement;
            }

            vbMethodBlock = vbMethodBlock.AddStatements(vbStatements.ToArray());
            return vbMethodBlock.WithConvertTrivia(node);
        }

        static VBS.OperatorBlockSyntax ConvertOperator(this CSS.OperatorDeclarationSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csOperator = (CSS.OperatorDeclarationSyntax)node;

            var vbAttributeListSplit = csOperator.AttributeLists.ConvertAttributesSplit();
            var vbModifiers = ConvertModifiersWithDefault(csOperator.Modifiers);
            var vbParameters = (VBS.ParameterListSyntax)csOperator.ParameterList.Convert();
            var vbStatements = csOperator.Body.ConvertBlockStatements();
            var vbExpressinBody = csOperator.ExpressionBody.Convert();

            var vbOperatorKind = Keyword.OperatorPairs.First(_ => csOperator.OperatorToken.IsKind(_.CS)).VB;
            var vbOperatorToken = VB.SyntaxFactory.Token(vbOperatorKind);

            if (vbModifiers.Count == 0)
            {
                vbModifiers = vbModifiers.Add(GetDefaultModifiers(node));
            }
            foreach (VBS.StatementSyntax vbStatement in vbStatements)
            {
                if (HasKindChildNode(vbStatement, VB.SyntaxKind.YieldStatement))
                {
                    vbModifiers = vbModifiers.Add(VB.SyntaxFactory.Token(VB.SyntaxKind.IteratorKeyword));
                    break;
                }
            }

            var vbReturnType = (VBS.TypeSyntax)csOperator.ReturnType.Convert();
            var vbReturnAs = VB.SyntaxFactory.SimpleAsClause(vbAttributeListSplit.Return, vbReturnType);

            var vbOperatorStatement = VB.SyntaxFactory.OperatorStatement(vbAttributeListSplit.Others, vbModifiers, vbOperatorToken, vbParameters, vbReturnAs);
            vbOperatorStatement = vbOperatorStatement.WithAsClause(vbReturnAs);
            var vbOperatorBlock = VB.SyntaxFactory.OperatorBlock(vbOperatorStatement);
            vbOperatorBlock = vbOperatorBlock.AddStatements(vbStatements.ToArray());
            return vbOperatorBlock;
        }

        static VB.VisualBasicSyntaxNode ConvertConversionOperator(this CSS.ConversionOperatorDeclarationSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csConversion = (CSS.ConversionOperatorDeclarationSyntax)node;
            var vbAttributeListSplit = csConversion.AttributeLists.ConvertAttributesSplit();
            var vbModifiers = ConvertModifiersWithDefault(csConversion.Modifiers);
            var vbParameters = (VBS.ParameterListSyntax)csConversion.ParameterList.Convert();
            var vbStatements = csConversion.Body.ConvertBlockStatements();
            var vbExpressinBody = csConversion.ExpressionBody.Convert();

            var vbToken = VB.SyntaxFactory.Token(VB.SyntaxKind.CTypeKeyword);
            vbModifiers = vbModifiers.Add(ConvertModifier(csConversion.ImplicitOrExplicitKeyword));

            var vbReturnType = (VBS.TypeSyntax)csConversion.Type.Convert();
            var vbReturnAs = VB.SyntaxFactory.SimpleAsClause(vbAttributeListSplit.Return, vbReturnType);

            var vbOperatorStatement = VB.SyntaxFactory.OperatorStatement(vbAttributeListSplit.Others, vbModifiers, vbToken, vbParameters, vbReturnAs);
            vbOperatorStatement = vbOperatorStatement.WithAsClause(vbReturnAs);
            var vbOperatorBlock = VB.SyntaxFactory.OperatorBlock(vbOperatorStatement);
            vbOperatorBlock = vbOperatorBlock.AddStatements(vbStatements.ToArray());
            return vbOperatorBlock;
        }

        static VB.VisualBasicSyntaxNode ConvertLambdaExpression(this CSS.LambdaExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csLambda = (CSS.LambdaExpressionSyntax)node;
            List<VBS.ParameterSyntax> vbParameters = new List<VBS.ParameterSyntax>();

            if (csLambda is CSS.ParenthesizedLambdaExpressionSyntax)
            {
                var csLambdaParenthesized = (CSS.ParenthesizedLambdaExpressionSyntax)node;
                var vbParameterList = (VBS.ParameterListSyntax)csLambdaParenthesized.ParameterList.Convert();
                vbParameters.AddRange(vbParameterList.Parameters);
            }
            else if (csLambda is CSS.SimpleLambdaExpressionSyntax)
            {
                var csLambdaSimple = (CSS.SimpleLambdaExpressionSyntax)node;
                vbParameters.Add(csLambdaSimple.Parameter.ConvertParameter());
            }


            bool isFunction = true;// false;
            bool isSingleLine = false;
            SyntaxList<VBS.StatementSyntax> statements = new SyntaxList<VBS.StatementSyntax>();
            if (csLambda.Body.Kind() == CS.SyntaxKind.Block)
            {
                var csBlock = (CSS.BlockSyntax)csLambda.Body;
                var x = csBlock.ChildNodesAndTokens().Last();
                var vbStatements = csBlock.Statements.ConvertSyntaxNodes<VBS.StatementSyntax>();
                statements = statements.AddRange(vbStatements.ToArray()).WithConvertedTrivia(csBlock);
            }
            else
            {

                var vbNode = (VB.VisualBasicSyntaxNode)csLambda.Body.Convert();

                if (vbNode is VBS.ExpressionSyntax)
                {
                    switch (vbNode.Kind())
                    {
                    case VB.SyntaxKind.NumericLiteralExpression:
                        {
                            var vbStatement = VB.SyntaxFactory.ReturnStatement((VBS.ExpressionSyntax)vbNode);
                            statements = statements.Add(vbStatement);
                            isFunction = true;
                        }
                        break;
                    default:
                        {
                            var vbStatement = VB.SyntaxFactory.ExpressionStatement((VBS.ExpressionSyntax)vbNode);
                            statements = statements.Add(vbStatement);
                            break;
                        }
                    }
                    isSingleLine = true;
                }
                else
                {
                    var vbStatement = (VBS.StatementSyntax)csLambda.Body.Convert();
                    statements = statements.Add(vbStatement);
                }
            }

            if (!isFunction)
            {
                isFunction = IsFunctionLambda(csLambda);
            }

            if (isFunction)
            {
                var x = VB.SyntaxFactory.FunctionLambdaHeader().AddParameterListParameters(vbParameters.ToArray());
                if (isSingleLine)
                {
                    var z = VB.SyntaxFactory.SingleLineFunctionLambdaExpression(x, statements[0] as VBS.StatementSyntax);
                    return z;
                }
                else
                {
                    //var x = VB.SyntaxFactory.FunctionLambdaHeader().AddParameterListParameters(vbParameters.ToArray());
                    var y = VB.SyntaxFactory.EndFunctionStatement();
                    var z = VB.SyntaxFactory.MultiLineFunctionLambdaExpression(x, y);
                    z = z.AddStatements(statements.ToArray());
                    return z;
                }
            }
            else
            {
                var x = VB.SyntaxFactory.SubLambdaHeader().AddParameterListParameters(vbParameters.ToArray());
                var y = VB.SyntaxFactory.EndSubStatement();
                var z = VB.SyntaxFactory.MultiLineSubLambdaExpression(x, y);
                z = z.AddStatements(statements.ToArray());
                return z;
            }
        }

        static bool IsFunctionLambda(CS.CSharpSyntaxNode node)
        {
            SearchReturnWalker searcher = new SearchReturnWalker();
            searcher.parentNoe = node;
            searcher.Visit(node);
            return searcher.found;
        }



        //static bool HasYield(CS.CSharpSyntaxNode node)
        //{
        //	SearchYieldWalker searcher = new SearchYieldWalker();
        //	searcher.parentNoe = node;
        //	searcher.Visit(node);
        //	return searcher.found;
        //}
        //class SearchYieldWalker : CS.CSharpSyntaxWalker
        //{
        //	public CS.CSharpSyntaxNode parentNoe;
        //	public bool found = false;
        //	public override void VisitReturnStatement(CSS.ReturnStatementSyntax node)
        //	{
        //		if (!found && node.Expression != null)
        //		{
        //			if (node.Ancestors().FirstOrDefault(_ => _.IsKind(CS.SyntaxKind.YieldBreakStatement)  || _.IsKind(CS.SyntaxKind.YieldReturnStatement) ) == parentNoe)
        //			{
        //				found = true;
        //			}
        //		}

        //		base.VisitReturnStatement(node);
        //	}
        //}

        #endregion

        static VBS.WithBlockSyntax ConvertBlock(CSS.BlockSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csBlock = (CSS.BlockSyntax)node;
            if (csBlock.Parent.IsKind(CS.SyntaxKind.Block) || csBlock.Parent.IsKind(CS.SyntaxKind.SwitchSection) || csBlock.Parent.IsKind(CS.SyntaxKind.AnonymousMethodExpression))
            {
                return CreateWithNothing(csBlock.OpenBraceToken.TrailingTrivia.ConvertTriviaList())
                        .AddStatements(csBlock.ConvertBlockStatements().ToArray())
                        .WithConvertTrivia(node);
            }
            else
            {
                System.Diagnostics.Debug.Assert(false, "Please use ConvertBlock() or Block.Statements.Convert<V,C>");
                return null;
            }
        }

        #region Flow
        #region IF
        static VBS.MultiLineIfBlockSyntax ConvertIfStatement(this CSS.IfStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csIf = (CSS.IfStatementSyntax)node;

            var vbCondition = (VBS.ExpressionSyntax)csIf.Condition.Convert();
            var vbStatements = csIf.Statement.ConvertBlockOrStatements();
            var csBlock = csIf.ChildNodes().FirstOrDefault(_ => _ is CSS.BlockSyntax) as CSS.BlockSyntax;

            var vbIfThen = VB.SyntaxFactory.IfStatement(vbCondition)
                            .WithThenKeyword(VB.SyntaxFactory.Token(VB.SyntaxKind.ThenKeyword))
                            .WithTrailingTrivia(csIf.CloseParenToken.TrailingTrivia.ConvertTriviaList());
            var vbIfBlock = VB.SyntaxFactory.MultiLineIfBlock(vbIfThen);
            vbIfBlock = vbIfBlock.AddStatements(vbStatements.ToArray());
            if (csIf.Else != null)
            {
                var vbElse = (VBS.ElseBlockSyntax)csIf.Else.Convert();
                if (vbElse != null && csIf.Else is CSS.ElseClauseSyntax)
                {
                    var csElseClause = (CSS.ElseClauseSyntax)csIf.Else;
                    if (csElseClause.Statement is CSS.BlockSyntax)
                    {
                        var x = ((CSS.BlockSyntax)csElseClause.Statement).CloseBraceToken.LeadingTrivia.ConvertTriviaList();
                        vbIfBlock = vbIfBlock.WithEndIfStatement(vbIfBlock.EndIfStatement.WithLeadingTrivia(x));
                    }
                }

                var vbElseIfBlocksAndElseBlock = MergeElseIf(vbElse);
                if (csBlock != null)
                {
                    var vbElseLeadingTriviaList = csBlock.CloseBraceToken.LeadingTrivia.ConvertTriviaList();

                    if (vbElseIfBlocksAndElseBlock.ElseIfBlocks == null || vbElseIfBlocksAndElseBlock.ElseIfBlocks.Count == 0)
                    {
                        vbElseIfBlocksAndElseBlock.ElseBlock
                            = vbElseIfBlocksAndElseBlock.ElseBlock.WithLeadingTrivia(vbElseLeadingTriviaList);
                    }
                    else
                    {
                        vbElseIfBlocksAndElseBlock.ElseIfBlocks[0]
                            = vbElseIfBlocksAndElseBlock.ElseIfBlocks[0].WithLeadingTrivia(vbElseLeadingTriviaList);
                    }

                }
                vbIfBlock = vbIfBlock.AddElseIfBlocks(vbElseIfBlocksAndElseBlock.ElseIfBlocks.ToArray())
                                    .WithElseBlock(vbElseIfBlocksAndElseBlock.ElseBlock);
                if (vbElseIfBlocksAndElseBlock.End != null)
                {
                    vbIfBlock = vbIfBlock.WithEndIfStatement(vbElseIfBlocksAndElseBlock.End);
                }

            }
            //else if (csBlock != null)
            //{
            //    var csCloseBrace = csBlock.ChildNodesAndTokens().Last(_ => _.IsKind(CS.SyntaxKind.CloseBraceToken));
            //}
            return vbIfBlock.WithConvertTrivia(node);
        }

        static VBS.ElseBlockSyntax ConvertElseClauseStatement(this CSS.ElseClauseSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csElse = (CSS.ElseClauseSyntax)node;
            var vbStatements = csElse.Statement.ConvertBlockOrStatements();
            var vbElse = VB.SyntaxFactory.ElseBlock();
            return vbElse.AddStatements(vbStatements.ToArray());
        }
        #endregion endif

        #region  switch
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        /// <remarks>
        /// <code lang="CS">
        /// switch(x)
        /// {
        /// case 1:
        ///     goto case 2;
        /// case 2;
        ///     goto default;
        /// default:
        ///     break;
        /// }
        /// <code>
        /// <code lang="VB">
        /// With Nothing
        ///     Dim __SELECT_VALUE_ = x
        ///     __RETRY_SELECT_n:
        ///     Select case(__SELECT_VALUE_n)
        ///     case 1
        ///         temp = 2
        ///         Goto __RETRY_SELECT_n
        ///     case 2
        ///         Goto __GOTO_DEFAULT_n
        ///     case else
        ///     __GOTODEFAULT_n
        ///     End Select 
        /// End With 
        /// </code>
        /// </remarks>
        static VB.VisualBasicSyntaxNode ConvertSwitchStatementAndRewriteGoto(this CSS.SwitchStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csSwitch = (CSS.SwitchStatementSyntax)node;

            GotoCaseRewriter rewriter = new GotoCaseRewriter(csSwitch);
            csSwitch = (CSS.SwitchStatementSyntax)rewriter.Visit(csSwitch);
            if (rewriter.HasGotoDefault)
            {
                SyntaxList<CSS.SwitchSectionSyntax> list = new SyntaxList<CSS.SwitchSectionSyntax>();
                foreach (CSS.SwitchSectionSyntax csCase in csSwitch.Sections)
                {
                    CSS.SwitchSectionSyntax csCaseTemp = csCase;

                    foreach (CSS.SwitchLabelSyntax csLabel in csCase.Labels)
                    {
                        if (csLabel.IsKind(CS.SyntaxKind.DefaultSwitchLabel))
                        {
                            var csDefaultLabelStatement = CS.SyntaxFactory.LabeledStatement(rewriter.LabelDefault, csCase.Statements[0]);
                            var csStatements = csCase.Statements.RemoveAt(0);
                            csStatements = csStatements.Insert(0, csDefaultLabelStatement);
                            csCaseTemp = csCase.WithStatements(csStatements);
                            break;
                        }
                    }
                    list = list.Add(csCaseTemp);
                }

                csSwitch = csSwitch.WithSections(list);
            }

            var vbSelectBlock = ConvertSwitchStatementNoRewrite(csSwitch);

            if (rewriter.HasGotoTop)
            {
                var vbID = VB.SyntaxFactory.ModifiedIdentifier(rewriter.VariantName);
                var vbEqual = VB.SyntaxFactory.EqualsValue(vbSelectBlock.SelectStatement.Expression);
                var vbVariable = VB.SyntaxFactory.VariableDeclarator().AddNames(vbID).WithInitializer(vbEqual);
                SeparatedSyntaxList<VBS.VariableDeclaratorSyntax> vbDeclarators
                    = new SeparatedSyntaxList<VBS.VariableDeclaratorSyntax>().Add(vbVariable);
                SyntaxTokenList vbModifiers = new SyntaxTokenList().Add(VB.SyntaxFactory.Token(VB.SyntaxKind.DimKeyword));
                var vbDim = VB.SyntaxFactory.LocalDeclarationStatement(vbModifiers, vbDeclarators);

                var vbLabel = VB.SyntaxFactory.LabelStatement(rewriter.LabelTop);

                var vbSelectStatement = vbSelectBlock.SelectStatement;
                vbSelectStatement = vbSelectStatement.WithExpression(VB.SyntaxFactory.IdentifierName(rewriter.VariantName));
                vbSelectBlock = vbSelectBlock.WithSelectStatement(vbSelectStatement);

                var vbWithNothing = CreateWithNothing();
                vbWithNothing = vbWithNothing.AddStatements(vbDim);
                vbWithNothing = vbWithNothing.AddStatements(vbLabel);
                return vbWithNothing.AddStatements(vbSelectBlock);
            }
            else
            {
                return vbSelectBlock;
            }

        }

        static VBS.SelectBlockSyntax ConvertSwitchStatementNoRewrite(this CSS.SwitchStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csSwitch = (CSS.SwitchStatementSyntax)node;
            var vbExpression = (VBS.ExpressionSyntax)csSwitch.Expression.ConvertAssignRightExpression();
            var vbCases = csSwitch.Sections.ConvertSyntaxNodes<VBS.CaseBlockSyntax>();

            var vbSelect = VB.SyntaxFactory.SelectStatement(vbExpression);
            var vbSelectBlock = VB.SyntaxFactory.SelectBlock(vbSelect);
            return vbSelectBlock.AddCaseBlocks(vbCases.ToArray());
        }

        static VBS.CaseBlockSyntax ConvertSwitchSelection(this CSS.SwitchSectionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csSwitchCase = (CSS.SwitchSectionSyntax)node;

            var vbClauses = csSwitchCase.Labels.Convert<CSS.SwitchLabelSyntax, VBS.CaseClauseSyntax>();
            VBS.CaseStatementSyntax vbCaseElse = null;
            if (vbClauses.Count >= 2)
            {
                foreach (VBS.CaseClauseSyntax vbClause in vbClauses)
                {
                    if (vbClause.IsKind(VB.SyntaxKind.ElseCaseClause))
                    {
                        vbClauses = vbClauses.Remove(vbClause);
                        vbCaseElse = VB.SyntaxFactory.CaseStatement(vbClause);
                        break;
                    }
                }
            }

            var vbCase = VB.SyntaxFactory.CaseStatement();
            vbCase = vbCase.AddCases(vbClauses.ToArray()).WithLeadingTrivia(node.GetLeadingTrivia().ConvertTriviaList());

            var vbStatements = csSwitchCase.Statements.ConvertStatements<VBS.StatementSyntax>();

            var vbCaseBlock = VB.SyntaxFactory.CaseBlock(vbCase);
            if (vbCaseElse != null)
            {
                vbCaseBlock = vbCaseBlock.AddStatements(vbCaseElse);
            }
            return vbCaseBlock.AddStatements(vbStatements.ToArray()).WithConvertTrivia(node);
        }

        static VBS.SimpleCaseClauseSyntax ConvertCaseSwitchLabel(this CSS.CaseSwitchLabelSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csCaseLabel = (CSS.CaseSwitchLabelSyntax)node;
            var vbCaseLabel = (VBS.ExpressionSyntax)csCaseLabel.Value.Convert();
            return VB.SyntaxFactory.SimpleCaseClause(vbCaseLabel)
                .WithTrailingTrivia(node.GetTrailingTrivia().ConvertTriviaList());//.WithConvertTrivia(node);
        }


        #endregion

        static VBS.ExitStatementSyntax ConvertBreak(this CSS.BreakStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csBreak = (CSS.BreakStatementSyntax)node;

            SyntaxNode parentNode = node.Parent;
            while (parentNode != null)
            {
                var pair = Keyword.BreakPairs.FirstOrDefault(_ => parentNode.IsKind(_.CS));
                if (pair != null)
                {
                    if (pair.VB == VB.SyntaxKind.None)
                    {
                        return null;
                    }
                    bool flag = (VB.SyntaxFacts.IsExitStatement(pair.VB));
                    return VB.SyntaxFactory.ExitStatement(pair.VB, VB.SyntaxFactory.Token(pair.ExitTargetKeyword))
                        .WithConvertTrivia(node);
                }
                parentNode = parentNode.Parent;
            }
            System.Diagnostics.Debug.Assert(false, "break");
            return null;
        }

        static VBS.ContinueStatementSyntax ConvertContinue(this CSS.ContinueStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csBreak = (CSS.ContinueStatementSyntax)node;

            SyntaxNode parentNode = node.Parent;
            while (parentNode != null)
            {
                var pair = Keyword.ContinuePairs.FirstOrDefault(_ => parentNode.IsKind(_.CS));
                if (pair != null)
                {
                    if (pair.VB == VB.SyntaxKind.None)
                    {
                        return null;
                    }
                    bool flag = (VB.SyntaxFacts.IsExitStatement(pair.VB));
                    return VB.SyntaxFactory.ContinueStatement(pair.VB, VB.SyntaxFactory.Token(pair.ExitTargetKeyword))
                                    .WithConvertTrivia(node);

                }
                parentNode = parentNode.Parent;
            }
            System.Diagnostics.Debug.Assert(false, "Continue");
            return null;

        }

        #region for
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        /// <remarks>
        /// <code lang="CS">
        /// for(int i=0 ; i &lt; 10; i+=1)
        /// {
        ///     statementsA;
        ///     continue;
        ///     statementsB;
        /// }
        /// <code>
        /// <code lang="VB">
        /// With Nothing
        ///     Dim i=0
        ///     FOR _F_nnn As Integer = 0 TO 1 Step 0
        ///         If Not(i &lt; 10) Then
        ///             Exit For
        ///         End If
        ///         statementsA
        ///         Goto CONTINUE_FOR_nnn
        ///         statementsB
        ///     CONTINUE_FOR_nnn:
        ///         i+=1
        ///     Next
        /// End With  
        /// </code>
        /// </remarks>
        static VBS.WithBlockSyntax ConvertFor(this CSS.ForStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csFor = (CSS.ForStatementSyntax)node;
            var vbDeclaration = (VBS.DeclarationStatementSyntax)csFor.Declaration.Convert();
            var vbInitializers = csFor.Initializers.ConvertSyntaxNodes<VB.VisualBasicSyntaxNode>(); //?
            var vbCondition = (VBS.ExpressionSyntax)csFor.Condition.Convert();
            var vbIncrementors = csFor.Incrementors.ConvertSyntaxNodes<VB.VisualBasicSyntaxNode>().ToArray();
            var vbStatements = csFor.Statement.ConvertBlockOrStatements();

            uint number = ContinueForRewriter.CreateNumber();
            string forName = "_F_" + number.ToString();
            string gotoLabel = "CONTINUE_FOR_" + number.ToString();

            //Create For block //manual generating for this block is tiresome work...
            //手作業で作ると面倒なので
            var vbForBlock = (VBS.ForBlockSyntax)VB.SyntaxFactory.ParseExecutableStatement("For " + forName + " As Integer =0 To 1 Step 0");
            vbForBlock = vbForBlock.Update(vbForBlock.ForStatement, vbForBlock.Statements, VB.SyntaxFactory.NextStatement());

            //Insert loop end condition checker
            if (vbCondition != null)
            {
                vbCondition = VB.SyntaxFactory.NotExpression(VB.SyntaxFactory.ParenthesizedExpression(vbCondition));
                var vbIfStatement = VB.SyntaxFactory.IfStatement(vbCondition)
                                    .WithThenKeyword(VB.SyntaxFactory.Token(VB.SyntaxKind.ThenKeyword));
                var vbIfBlock = VB.SyntaxFactory.MultiLineIfBlock(vbIfStatement);
                vbIfBlock = vbIfBlock.AddStatements(VB.SyntaxFactory.ExitForStatement());
                vbForBlock = vbForBlock.AddStatements(vbIfBlock);

            }
            //Add main statements
            vbForBlock = vbForBlock.AddStatements(vbStatements.ToArray());

            //'Continue For' will be replaced to jump to the end of block.
            ContinueForRewriter rewriter = new ContinueForRewriter(vbForBlock, gotoLabel);
            vbForBlock = (VBS.ForBlockSyntax)rewriter.Visit(vbForBlock);
            if (rewriter.HasContinueFor)
            {
                vbForBlock = vbForBlock.AddStatements(VB.SyntaxFactory.LabelStatement(rewriter.Label));
            }

            //Insert Post Incrementor Statements
            foreach (VB.VisualBasicSyntaxNode vbNode in vbIncrementors)
            {
                if (vbNode is VBS.ExpressionSyntax)
                {
                    var vbExp = (VBS.ExpressionSyntax)vbNode;
                    vbForBlock = vbForBlock.AddStatements(VB.SyntaxFactory.ExpressionStatement(vbExp));
                }
                else if (vbNode is VBS.StatementSyntax)
                {
                    vbForBlock = vbForBlock.AddStatements((VBS.StatementSyntax)vbNode);
                }
                else
                {
                    System.Diagnostics.Debug.Assert(false, "ConvertFor");
                }
            }

            var vbWithNothing = CreateWithNothing(csFor.CloseParenToken.TrailingTrivia.ConvertTriviaList());
            if (vbDeclaration != null)
            {
                //Insert Pre Declaration Statements
                if (vbDeclaration.Kind() == VB.SyntaxKind.FieldDeclaration)
                {
                    vbDeclaration = ((VBS.FieldDeclarationSyntax)vbDeclaration).AddModifiers(VB.SyntaxFactory.Token(VB.SyntaxKind.DimKeyword));
                }
                vbWithNothing = vbWithNothing.AddStatements(vbDeclaration);
            }
            vbWithNothing = vbWithNothing.AddStatements(vbForBlock);
            return vbWithNothing.WithConvertTrivia(node); ;
        }


        #endregion //for

        static VBS.ForEachBlockSyntax ConvertForEach(this CSS.ForEachStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csForeach = (CSS.ForEachStatementSyntax)node;
            var vbID = csForeach.Identifier.ConvertID();

            VBS.SimpleAsClauseSyntax vbAsClause = null;
            if (!csForeach.Type.IsVar)
            {
                var vbType = (VBS.TypeSyntax)csForeach.Type.Convert();
                vbAsClause = VB.SyntaxFactory.SimpleAsClause(vbType);
            }
            var vbExpression = (VBS.ExpressionSyntax)csForeach.Expression.ConvertAssignRightExpression();
            var vbStatements = csForeach.Statement.ConvertBlockOrStatements();
            var vbMID = VB.SyntaxFactory.ModifiedIdentifier(vbID);


            var vbVariable = (VB.VisualBasicSyntaxNode)VB.SyntaxFactory.VariableDeclarator(vbMID).WithAsClause(vbAsClause);
            var vbForEachStatement = VB.SyntaxFactory.ForEachStatement(vbVariable, vbExpression)
                                     .WithTrailingTrivia(csForeach.CloseParenToken.TrailingTrivia.ConvertTriviaList());

            var vbForEach = VB.SyntaxFactory.ForEachBlock(vbForEachStatement)
                                .AddStatements(vbStatements.ToArray())
                                .WithNextStatement(VB.SyntaxFactory.NextStatement());

            return vbForEach.WithConvertTrivia(node);
        }

        static VBS.DoLoopBlockSyntax ConvertDo(this CSS.DoStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csDo = (CSS.DoStatementSyntax)node;
            var vbStatements = csDo.Statement.ConvertBlockOrStatements();
            var vbCondition = (VBS.ExpressionSyntax)csDo.Condition.Convert();

            var vbWhileClause = VB.SyntaxFactory.WhileClause(vbCondition);
            var vbDoStatements = VB.SyntaxFactory.DoStatement(VB.SyntaxKind.SimpleDoStatement)
                                    .WithTrailingTrivia(csDo.DoKeyword.TrailingTrivia.ConvertTriviaList());
            var vbLoopStatement = VB.SyntaxFactory.LoopWhileStatement(vbWhileClause)
                .WithLeadingTrivia(csDo.SemicolonToken.TrailingTrivia.ConvertTriviaList());

            var vbDo = VB.SyntaxFactory.DoLoopBlock(VB.SyntaxKind.DoLoopWhileBlock, vbDoStatements, vbLoopStatement);
            return vbDo.WithStatements(vbStatements).WithConvertTrivia(node);
        }

        static VBS.WhileBlockSyntax ConvertWhile(this CSS.WhileStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csWhile = (CSS.WhileStatementSyntax)node;
            var vbCondition = (VBS.ExpressionSyntax)csWhile.Condition.Convert();
            var vbStatements = csWhile.Statement.ConvertBlockOrStatements();

            var vbWhileStatements = VB.SyntaxFactory.WhileStatement(vbCondition)
                        .WithTrailingTrivia(csWhile.CloseParenToken.TrailingTrivia.ConvertTriviaList());
            return VB.SyntaxFactory.WhileBlock(vbWhileStatements, vbStatements)
                        .WithConvertTrivia(node);
        }

        static VBS.GoToStatementSyntax ConvertGoto(this CSS.GotoStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csGoto = (CSS.GotoStatementSyntax)node;
            var vbID = (VBS.IdentifierNameSyntax)csGoto.Expression.ConvertAssignRightExpression();
            var vbLabel = VB.SyntaxFactory.IdentifierLabel(vbID.Identifier.ToFullString());
            return VB.SyntaxFactory.GoToStatement(vbLabel).WithConvertTrivia(node);
        }

        static VBS.LabelStatementSyntax ConvertLabel(this CSS.LabeledStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csLabel = (CSS.LabeledStatementSyntax)node;
            var vbID = csLabel.Identifier.ConvertID();
            return VB.SyntaxFactory.LabelStatement(vbID.ToFullString()).WithConvertTrivia(node);
        }

        static VBS.ReturnStatementSyntax ConvertReturn(this CSS.ReturnStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csReturn = (CSS.ReturnStatementSyntax)node;
            var vbExpression = (VBS.ExpressionSyntax)csReturn.Expression.ConvertAssignRightExpression();
            return VB.SyntaxFactory.ReturnStatement(vbExpression).WithConvertTrivia(node);
        }

        static VBS.YieldStatementSyntax ConvertYield(this CSS.YieldStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csYieldReturn = (CSS.YieldStatementSyntax)node;
            var vbExpression = (VBS.ExpressionSyntax)csYieldReturn.Expression.ConvertAssignRightExpression();
            return VB.SyntaxFactory.YieldStatement(vbExpression).WithConvertTrivia(node);
        }


        #endregion

        #region try-catch-finally

        static VBS.ThrowStatementSyntax ConvertThrow(this CSS.ThrowStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csThrow = (CSS.ThrowStatementSyntax)node;
            var vbExpression = (VBS.ExpressionSyntax)csThrow.Expression.ConvertAssignRightExpression();
            return VB.SyntaxFactory.ThrowStatement(vbExpression);
        }

        static VBS.TryBlockSyntax ConvertTry(this CSS.TryStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csTry = (CSS.TryStatementSyntax)node;
            var vbStatements = csTry.Block.Statements.ConvertSyntaxNodes<VBS.StatementSyntax>();
            var vbCatches = csTry.Catches.ConvertSyntaxNodes<VBS.CatchBlockSyntax>();
            var vbFinally = (VBS.FinallyBlockSyntax)csTry.Finally.Convert();

            var vbTry = VB.SyntaxFactory.TryBlock();
            vbTry = vbTry.WithStatements(vbStatements);
            vbTry = vbTry.AddCatchBlocks(vbCatches.ToArray());
            vbTry = vbTry.WithFinallyBlock(vbFinally);
            return vbTry;
        }
        static VBS.CatchBlockSyntax ConvertCatchClause(this CSS.CatchClauseSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csCatch = (CSS.CatchClauseSyntax)node;
            var vbFilter = (VBS.CatchFilterClauseSyntax)csCatch.Filter.Convert();
            var vbCatchStatement = (VBS.CatchStatementSyntax)csCatch.Declaration.Convert();
            var vbStatements = csCatch.Block.ConvertBlockOrStatements();
            if (vbFilter != null)
            {
                vbCatchStatement = vbCatchStatement.WithWhenClause(vbFilter);
            }
            if (vbCatchStatement == null)
            {
                vbCatchStatement = VB.SyntaxFactory.CatchStatement();
            }
            var vbCatchBlock = VB.SyntaxFactory.CatchBlock(vbCatchStatement);
            vbCatchBlock = vbCatchBlock.WithStatements(vbStatements);

            return vbCatchBlock;
        }
        static VBS.CatchStatementSyntax ConvertCatchDeclaration(this CSS.CatchDeclarationSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csCatchDeclaration = (CSS.CatchDeclarationSyntax)node;
            var vbType = (VBS.TypeSyntax)csCatchDeclaration.Type.Convert();
            var vbId = csCatchDeclaration.Identifier.ConvertID();
            var vbAsClause = VB.SyntaxFactory.SimpleAsClause(vbType);

            var vbCatchStatement = VB.SyntaxFactory.CatchStatement().WithAsClause(vbAsClause);
            if (vbId != null && !vbId.IsKind(VB.SyntaxKind.None))
            {
                var vbName = VB.SyntaxFactory.IdentifierName(vbId);
                vbCatchStatement = vbCatchStatement.WithIdentifierName(vbName);
            }
            else
            {
                var vbName = VB.SyntaxFactory.IdentifierName("ex");
                vbCatchStatement = vbCatchStatement.WithIdentifierName(vbName);
            }
            return vbCatchStatement;
        }
        static VBS.CatchFilterClauseSyntax ConvertCatchFilter(this CSS.CatchFilterClauseSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csCatchFilter = (CSS.CatchFilterClauseSyntax)node;
            var vbFilterExp = (VBS.ExpressionSyntax)csCatchFilter.FilterExpression.ConvertAssignRightExpression();
            return VB.SyntaxFactory.CatchFilterClause(vbFilterExp);
        }
        static VBS.FinallyBlockSyntax ConvertFinally(this CSS.FinallyClauseSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csFinally = (CSS.FinallyClauseSyntax)node;
            var vbStatemetns = csFinally.Block.ConvertBlockOrStatements();
            return VB.SyntaxFactory.FinallyBlock(vbStatemetns);
        }

        #endregion

        #region field , variable

        static VBS.FieldDeclarationSyntax ConvertFieldDeclaration(this CSS.FieldDeclarationSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csField = (CSS.FieldDeclarationSyntax)node;
            var vbAttribute = csField.AttributeLists.ConvertAttributes();
            var vbModifiers = ConvertModifiersWithDefault(csField.Modifiers, VB.SyntaxFactory.Token(VB.SyntaxKind.PrivateKeyword));

            var vbField = (VBS.FieldDeclarationSyntax)csField.Declaration.Convert();
            return vbField.AddAttributeLists(vbAttribute.ToArray()).AddModifiers(vbModifiers.ToArray())
                    .WithConvertTrivia(node);
        }

        static VBS.FieldDeclarationSyntax ConvertVariableDeclaration(this CSS.VariableDeclarationSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csDeclaration = (CSS.VariableDeclarationSyntax)node;
            var vbField = VB.SyntaxFactory.FieldDeclaration();
            var vbAsClause = csDeclaration.Type.ConvertToAsClause();

            foreach (CSS.VariableDeclaratorSyntax csv in csDeclaration.Variables)
            {
                var vbVariable = (VBS.VariableDeclaratorSyntax)csv.Convert();
                vbField = vbField.AddDeclarators(vbVariable.WithAsClause(vbAsClause));
            }

            return vbField;
        }

        static VBS.VariableDeclaratorSyntax ConvertVariableDeclarator(this CSS.VariableDeclaratorSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csDeclarator = (CSS.VariableDeclaratorSyntax)node;
            var vbID = VB.SyntaxFactory.ModifiedIdentifier(csDeclarator.Identifier.ConvertID());
            var vbDeclarator = VB.SyntaxFactory.VariableDeclarator(vbID);
            var vbInitializer = (VBS.EqualsValueSyntax)csDeclarator.Initializer.Convert();

            return vbDeclarator.WithInitializer(vbInitializer);
        }

        static VBS.EnumMemberDeclarationSyntax ConvertEnumMemberDeclaration(this CSS.EnumMemberDeclarationSyntax node)
        {
            var csEnumDeclaration = (CSS.EnumMemberDeclarationSyntax)node;
            var vbAttributes = csEnumDeclaration.AttributeLists.ConvertAttributes();
            var vbEqualsValue = (VBS.EqualsValueSyntax)csEnumDeclaration.EqualsValue.Convert();
            var vbID = csEnumDeclaration.Identifier.ConvertID();

            return VB.SyntaxFactory.EnumMemberDeclaration(vbAttributes, vbID, vbEqualsValue).WithConvertTrivia(node);

        }

        static VBS.DelegateStatementSyntax ConvertDelegateDeclaration(this CSS.DelegateDeclarationSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csDelegate = (CSS.DelegateDeclarationSyntax)node;

            var vbAttributeListSplit = csDelegate.AttributeLists.ConvertAttributesSplit();
            var vbModifiers = ConvertModifiersWithDefault(csDelegate.Modifiers, GetDefaultModifiers(node));
            var vbIdentifier = csDelegate.Identifier.ConvertID();
            var vbTypeParameter = ConvertTypeParameters(csDelegate.TypeParameterList, csDelegate.ConstraintClauses);
            var vbParameters = (VBS.ParameterListSyntax)csDelegate.ParameterList.Convert();
            var vbReturn = (VBS.TypeSyntax)csDelegate.ReturnType.Convert();

            bool isSub = vbReturn == null;

            VB.SyntaxKind stateSubOrFunc = isSub ? VB.SyntaxKind.DelegateSubStatement : VB.SyntaxKind.DelegateFunctionStatement;
            VB.SyntaxKind keySubOrFunc = isSub ? VB.SyntaxKind.SubKeyword : VB.SyntaxKind.FunctionKeyword;
            var vbASClause = isSub ? null : VB.SyntaxFactory.SimpleAsClause(vbAttributeListSplit.Return, vbReturn);

            return VB.SyntaxFactory.DelegateStatement
                        (stateSubOrFunc
                        , vbAttributeListSplit.Others
                        , vbModifiers
                        , VB.SyntaxFactory.Token(keySubOrFunc)
                        , vbIdentifier
                        , vbTypeParameter
                        , vbParameters
                        , vbASClause).WithConvertTrivia(node);
        }

        static VBS.FieldDeclarationSyntax ConvertLocalDeclaration(this CSS.LocalDeclarationStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csLocal = (CSS.LocalDeclarationStatementSyntax)node;
            var vbModifiers = ConvertModifiersWithDefault(csLocal.Modifiers, VB.SyntaxFactory.Token(VB.SyntaxKind.DimKeyword));
            var vbDeclaration = csLocal.Declaration.ConvertVariableDeclaration();
            return vbDeclaration.AddModifiers(vbModifiers.ToArray()).WithConvertTrivia(node);
        }

        #endregion

        #region Event

        static VBS.EventStatementSyntax ConvertEventFieldDeclaration(this CSS.EventFieldDeclarationSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csEvent = (CSS.EventFieldDeclarationSyntax)node;
            var vbAttributes = csEvent.AttributeLists.ConvertAttributes();
            var vbDeclaration = (VBS.FieldDeclarationSyntax)csEvent.Declaration.ConvertVariableDeclaration();
            var vbDeclarator = (VBS.VariableDeclaratorSyntax)vbDeclaration.Declarators[0];
            var vbModifiers = ConvertModifiersWithDefault(csEvent.Modifiers);

            var vbEvent = VB.SyntaxFactory.EventStatement(vbDeclarator.Names[0].Identifier)
                               .WithAttributeLists(vbAttributes)
                               .WithModifiers(vbModifiers)
                               .WithAsClause((VBS.SimpleAsClauseSyntax)vbDeclarator.AsClause);
            return vbEvent.WithConvertTrivia(node);
        }

        static VBS.EventBlockSyntax ConvertEventBlock(this CSS.EventDeclarationSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csEvent = (CSS.EventDeclarationSyntax)node;
            var vbAccessorList = csEvent.AccessorList.ConvertAccessorList();
            var vbAttributes = csEvent.AttributeLists.ConvertAttributes();
            var vbExplicit = (VBS.ImplementsClauseSyntax)csEvent.ExplicitInterfaceSpecifier.Convert();
            var vbID = csEvent.Identifier.ConvertID();
            var vbModifiers = ConvertModifiersWithDefault(csEvent.Modifiers);
            var vbAsClause = csEvent.Type.ConvertToAsClause();

            var vbRaiseArguments = CreateRaiseEventArguments(csEvent);
            var vbRaiseStatement = VB.SyntaxFactory.RaiseEventAccessorStatement();
            vbRaiseStatement = vbRaiseStatement.AddParameterListParameters(vbRaiseArguments.Parameters.ToArray());
            var vbRaiseAccessor = VB.SyntaxFactory.RaiseEventAccessorBlock(vbRaiseStatement);

            vbAccessorList = vbAccessorList.Add(vbRaiseAccessor);

            var vbEventStatement = VB.SyntaxFactory.EventStatement(vbID)
                                        .WithAttributeLists(vbAttributes)
                                        .WithCustomKeyword(VB.SyntaxFactory.Token(VB.SyntaxKind.CustomKeyword))
                                        .WithModifiers(vbModifiers)
                                        .WithAsClause(vbAsClause)
                                        .WithImplementsClause(vbExplicit);
            return VB.SyntaxFactory.EventBlock(vbEventStatement, vbAccessorList);
        }

        static VBS.AccessorBlockSyntax ConvertEventAccessor(this CSS.AccessorDeclarationSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csAddRemove = (CSS.AccessorDeclarationSyntax)node;
            var vbAttributes = csAddRemove.AttributeLists.ConvertAttributes();
            var vbModifiers = ConvertModifiersWithDefault(csAddRemove.Modifiers);
            var vbStatements = csAddRemove.Body.Statements.ConvertSyntaxNodes<VBS.StatementSyntax>();

            var csEvent = csAddRemove.Parent.Parent as CSS.EventDeclarationSyntax;

            var vbParameter = VB.SyntaxFactory.Parameter(VB.SyntaxFactory.ModifiedIdentifier("value"));
            vbParameter = vbParameter.AddModifiers(VB.SyntaxFactory.Token(VB.SyntaxKind.ByValKeyword));
            vbParameter = vbParameter.WithAsClause(csEvent.Type.ConvertToAsClause());
            var vbParameters = VB.SyntaxFactory.ParameterList().AddParameters(vbParameter);


            if (node.Kind() == CS.SyntaxKind.AddAccessorDeclaration)
            {
                var vbStatement = VB.SyntaxFactory.AddHandlerAccessorStatement(vbAttributes, vbModifiers, vbParameters);
                return VB.SyntaxFactory.AddHandlerAccessorBlock(vbStatement).WithStatements(vbStatements);
            }
            else
            {
                var vbStatement = VB.SyntaxFactory.RemoveHandlerAccessorStatement(vbAttributes, vbModifiers, vbParameters);
                return VB.SyntaxFactory.RemoveHandlerAccessorBlock(vbStatement).WithStatements(vbStatements);
            }
        }

        private static VBS.ParameterListSyntax CreateRaiseEventArguments(CSS.EventDeclarationSyntax csEvent)
        {

            var vbRaiseArguments = VB.SyntaxFactory.ParameterList();
            string handlerTypeName = "";
            if (csEvent.Type.Kind() == CS.SyntaxKind.IdentifierName)
            {
                var csType = (CSS.IdentifierNameSyntax)csEvent.Type;
                handlerTypeName = csType.Identifier.Text;

                if (handlerTypeName == "EventHandler")
                {
                    vbRaiseArguments = vbRaiseArguments.AddParameters(CreateRaiseParameter("sender", "Object"));
                    vbRaiseArguments = vbRaiseArguments.AddParameters(CreateRaiseParameter("e", "EventArgs"));
                }
                else if (handlerTypeName != "Action")
                {
                    //not support Custom delegate;
                    //I don't know how to get the arguments of unknown delegate.
                    //未知のデリゲートの引数の調べ方が不明です
                }
            }
            else if (csEvent.Type.Kind() == CS.SyntaxKind.GenericName)
            {
                var csGeneric = ((CSS.GenericNameSyntax)csEvent.Type);
                handlerTypeName = csGeneric.Identifier.Text;
                if (handlerTypeName == "Action"
                    || (handlerTypeName == "EventHandler" && csGeneric.TypeArgumentList.Arguments.Count == 1))
                {
                    if (handlerTypeName == "EventHandler")
                    {
                        vbRaiseArguments = vbRaiseArguments.AddParameters(CreateRaiseParameter("sender", "Object"));
                    }
                    int i = 0;
                    foreach (CSS.TypeSyntax csType in csGeneric.TypeArgumentList.Arguments)
                    {
                        var vbParameterAsClause = csType.ConvertToAsClause();
                        var vbParameter = VB.SyntaxFactory.Parameter(VB.SyntaxFactory.ModifiedIdentifier("arg" + i.ToString()));
                        vbParameter = vbParameter.AddModifiers(VB.SyntaxFactory.Token(VB.SyntaxKind.ByValKeyword));
                        vbParameter = vbParameter.WithAsClause(vbParameterAsClause);
                        vbRaiseArguments = vbRaiseArguments.AddParameters(vbParameter);
                    }
                }
                else
                {
                    //not suppoort Custom delegate;
                    //I don't know how to get the arguments of unknown delegate.
                    //未知のデリゲートの引数の調べ方が不明です
                }
            }
            else //if (csEvent.Type.Kind() == CS.SyntaxKind.QualifiedName)
            {
                System.Diagnostics.Debug.Assert(false, "CreateRaiseEventArguments");
            }
            return vbRaiseArguments;
        }
        private static VBS.ParameterSyntax CreateRaiseParameter(string argumentName, string typename)
        {
            var vbEventArgs = VB.SyntaxFactory.IdentifierName(typename);
            var vbAsEventArgs = VB.SyntaxFactory.SimpleAsClause(vbEventArgs);
            var vbParameter = VB.SyntaxFactory.Parameter(VB.SyntaxFactory.ModifiedIdentifier(argumentName));
            vbParameter = vbParameter.AddModifiers(VB.SyntaxFactory.Token(VB.SyntaxKind.ByValKeyword));
            return vbParameter.WithAsClause(vbAsEventArgs);
        }

        #endregion
        //class IndexerImplementTest
        //{
        //    [System.Runtime.CompilerServices.IndexerNameAttribute("Indexer" + "B")]
        //    public int this[int index]
        //    {
        //        get { return index; }
        //    }
        //}
        #region Property
        private static SyntaxToken GetIndexerName(SyntaxList<CSS.AttributeListSyntax> vbAttributes)
        {
            string fullName = typeof(System.Runtime.CompilerServices.IndexerNameAttribute).FullName;
            foreach (CSS.AttributeListSyntax attrs in vbAttributes)
            {
                foreach (CSS.AttributeSyntax attr in attrs.Attributes)
                {

                    //if (attr.Name.IsKind(CS.SyntaxKind.QualifiedName))
                    {
                        bool isIndexer = false;
                        var name = attr.Name.ToFullString();
                        if (!name.EndsWith("Attribute"))
                        {
                            name += "Attribute";
                        }
                        if (fullName.Length == name.Length)
                        {
                            isIndexer = fullName == name;
                        }
                        else
                        {
                            name = "." + name;
                            isIndexer = fullName.EndsWith(name);
                        }
                        if (isIndexer)
                        {
                            foreach (CSS.AttributeArgumentSyntax arg in attr.ArgumentList.Arguments)
                            {
                                if (arg.Expression.IsKind(CS.SyntaxKind.StringLiteralExpression))
                                {
                                    var literal = (CSS.LiteralExpressionSyntax)arg.Expression;

                                    return VB.SyntaxFactory.Identifier(literal.Token.ValueText.Trim('"'));
                                }


                            }


                        }

                    }
                }
            }
            return VB.SyntaxFactory.Identifier("Item");
        }
        static VBS.PropertyBlockSyntax ConvertIndexer(this CSS.IndexerDeclarationSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csIndexer = (CSS.IndexerDeclarationSyntax)node;
            var vbAttributes = csIndexer.AttributeLists.ConvertAttributes();
            var vbExplicitInterface = csIndexer.ExplicitInterfaceSpecifier.ConvertExplicitInterfaceSpecifier();
            var vbExpression = csIndexer.ExpressionBody.Convert();

            var vbModifiers = ConvertModifiers(csIndexer.Modifiers);
            var vbAsClause = csIndexer.Type.ConvertToAsClause();
            var vbAccessors = csIndexer.AccessorList.ConvertAccessorList();
            VBS.AccessorBlockSyntax vbGetBlock = vbAccessors.FirstOrDefault(_ => _.IsKind(VB.SyntaxKind.GetAccessorBlock));
            VBS.AccessorBlockSyntax vbSetBlock = vbAccessors.FirstOrDefault(_ => _.IsKind(VB.SyntaxKind.SetAccessorBlock));

            var vbParameters = (VBS.ParameterListSyntax)csIndexer.ParameterList.Convert();
            SyntaxToken vbID = GetIndexerName(csIndexer.AttributeLists); //VB.SyntaxFactory.Identifier(CS.SyntaxFactory.Token(CS.SyntaxKind.ThisKeyword).ToFullString());
            VBS.EqualsValueSyntax vbInitializer = null;
            bool isReadOnly = vbGetBlock != null && vbSetBlock == null;
            bool isWriteOnly = vbGetBlock == null && vbSetBlock != null;
            if (isReadOnly)
            {
                vbModifiers = vbModifiers.Add(VB.SyntaxFactory.Token(VB.SyntaxKind.ReadOnlyKeyword));
            }
            else if (isWriteOnly)
            {
                vbModifiers = vbModifiers.Add(VB.SyntaxFactory.Token(VB.SyntaxKind.WriteOnlyKeyword));
            }
            vbModifiers = vbModifiers.Add(VB.SyntaxFactory.Token(VB.SyntaxKind.DefaultKeyword));
            var vbPropertyStatement = VB.SyntaxFactory.PropertyStatement(vbAttributes, vbModifiers, vbID, vbParameters, vbAsClause, vbInitializer, vbExplicitInterface);

            return VB.SyntaxFactory.PropertyBlock(vbPropertyStatement, vbAccessors);
        }

        static VB.VisualBasicSyntaxNode ConvertProperty(this CSS.PropertyDeclarationSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csPropertyDeclaration = (CSS.PropertyDeclarationSyntax)node;

            var vbAttributes = csPropertyDeclaration.AttributeLists.ConvertAttributes();
            var vbExplicitInterface = csPropertyDeclaration.ExplicitInterfaceSpecifier.ConvertExplicitInterfaceSpecifier();
            var vbExpression = csPropertyDeclaration.ExpressionBody.Convert();
            var vbID = csPropertyDeclaration.Identifier.ConvertID();
            var vbInitializer = (VBS.EqualsValueSyntax)csPropertyDeclaration.Initializer.Convert();
            var vbModifiers = ConvertModifiers(csPropertyDeclaration.Modifiers);
            var vbAsClause = csPropertyDeclaration.Type.ConvertToAsClause();
            var vbAccessors = csPropertyDeclaration.AccessorList.ConvertAccessorList();
            VBS.AccessorBlockSyntax vbGetBlock = vbAccessors.FirstOrDefault(_ => _.IsKind(VB.SyntaxKind.GetAccessorBlock));
            VBS.AccessorBlockSyntax vbSetBlock = vbAccessors.FirstOrDefault(_ => _.IsKind(VB.SyntaxKind.SetAccessorBlock));

            bool isReadOnly = vbGetBlock != null && vbSetBlock == null;
            bool isWriteOnly = vbGetBlock == null && vbSetBlock != null;
            if (isReadOnly)
            {
                vbModifiers = vbModifiers.Add(VB.SyntaxFactory.Token(VB.SyntaxKind.ReadOnlyKeyword));
            }
            else if (isWriteOnly)
            {
                vbModifiers = vbModifiers.Add(VB.SyntaxFactory.Token(VB.SyntaxKind.WriteOnlyKeyword));
            }

            bool isAutoProperty = null != csPropertyDeclaration.AccessorList.Accessors.FirstOrDefault(_ => _.Body == null);
            bool isNeedBackingField = isAutoProperty & vbAccessors.Count(_ => _.AccessorStatement.Modifiers.Count != 0) != 0;
            isAutoProperty &= !isNeedBackingField;

            var vbPropertyStatement = VB.SyntaxFactory.PropertyStatement(vbAttributes, vbModifiers, vbID, null, vbAsClause, vbInitializer, vbExplicitInterface);

            if (csPropertyDeclaration.Modifiers.Count(_ => _.IsKind(CS.SyntaxKind.AbstractKeyword)) > 0)
            {
                return vbPropertyStatement.WithConvertTrivia(node);
            }

            if (isAutoProperty)
            {
                return vbPropertyStatement.WithConvertTrivia(node);
            }
            else
            {
                return VB.SyntaxFactory.PropertyBlock(vbPropertyStatement, vbAccessors).WithConvertTrivia(node); ;
            }
        }

        static VBS.AccessorBlockSyntax ConvertGetSet(this CSS.AccessorDeclarationSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csAccessor = (CSS.AccessorDeclarationSyntax)node;
            var vbAttributes = csAccessor.AttributeLists.ConvertAttributes();
            var vbModifiers = ConvertModifiers(csAccessor.Modifiers);
            var vbStatements = csAccessor.Body.ConvertBlockOrStatements();
            if (csAccessor.Kind() == CS.SyntaxKind.GetAccessorDeclaration)
            {
                var vbAccessorStatement = VB.SyntaxFactory.GetAccessorStatement(vbAttributes, vbModifiers, null);
                return VB.SyntaxFactory.GetAccessorBlock(vbAccessorStatement, vbStatements);
            }
            else
            {
                var vbAccessorStatement = VB.SyntaxFactory.SetAccessorStatement(vbAttributes, vbModifiers, null);
                return VB.SyntaxFactory.SetAccessorBlock(vbAccessorStatement, vbStatements);
            }
        }

        #endregion

        #endregion

        #region Attribute

        static SyntaxList<VBS.AttributeListSyntax> ConvertAttributes(this SyntaxList<CSS.AttributeListSyntax> attributes)
        {
            return attributes.Convert<CSS.AttributeListSyntax, VBS.AttributeListSyntax>();
        }

        static AttributeSplitResult ConvertAttributesSplit(this SyntaxList<CSS.AttributeListSyntax> attributes)
        {
            AttributeSplitResult ret = new AttributeSplitResult();

            foreach (CSS.AttributeListSyntax csAttributeList in attributes)
            {
                var vbAttributeList = (VBS.AttributeListSyntax)csAttributeList.Convert();

                bool isReturnTarget = csAttributeList.Target != null && csAttributeList.Target.Identifier.ValueText == "return";
                if (isReturnTarget)
                {
                    ret.Return = ret.Return.Add(vbAttributeList);
                }
                else
                {
                    ret.Others = ret.Others.Add(vbAttributeList);
                }
            }
            return ret;
        }



        static SyntaxList<VBS.AttributeSyntax> ConvertAttributes(this SeparatedSyntaxList<CSS.AttributeSyntax> attributes)
        {
            return attributes.Convert<CSS.AttributeSyntax, VBS.AttributeSyntax>();
        }

        static SyntaxList<VBS.AccessorBlockSyntax> ConvertAccessorList(this CSS.AccessorListSyntax csAccessors)
        {
            return csAccessors.Accessors.ConvertSyntaxNodes<VBS.AccessorBlockSyntax>();
        }

        #endregion

        #region Type

        static VBS.TypeParameterListSyntax ConvertTypeParameterList(this CSS.TypeParameterListSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csTypeParameterList = (CSS.TypeParameterListSyntax)node;
            var vbTypeParameters = csTypeParameterList.Parameters.ConvertSyntaxNodes<VBS.TypeParameterSyntax>();
            return VB.SyntaxFactory.TypeParameterList(vbTypeParameters.ToArray());
        }

        static VBS.TypeParameterSyntax ConvertTypeParameter(this CSS.TypeParameterSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csTypeParameter = (CSS.TypeParameterSyntax)node;
            return VB.SyntaxFactory.TypeParameter(csTypeParameter.Identifier.ValueText); ;
        }

        static VBS.InheritsStatementSyntax ConvertBaseList(this CSS.BaseListSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csBaseList = (CSS.BaseListSyntax)node;
            var vbTypes = csBaseList.Types.ConvertSyntaxNodes<VBS.TypeSyntax>();
            return VB.SyntaxFactory.InheritsStatement(vbTypes.ToArray());
        }

        static VBS.TypeSyntax ConvertSimpleBaseType(this CSS.SimpleBaseTypeSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csType = (CSS.SimpleBaseTypeSyntax)node;
            return (VBS.TypeSyntax)csType.Type.Convert();
        }

        static VBS.TypeArgumentListSyntax ConvertTypeArgumentList(this CSS.TypeArgumentListSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csTypeArgumentList = (CSS.TypeArgumentListSyntax)node;
            var vbTypes = csTypeArgumentList.Arguments.ConvertSyntaxNodes<VBS.TypeSyntax>();
            return VB.SyntaxFactory.TypeArgumentList(vbTypes.ToArray());
        }

        static VBS.PredefinedTypeSyntax ConvertPredefinedTypeType(this CSS.PredefinedTypeSyntax csType)
        {
            foreach (KeywordPair pair in Keyword.TypePairs)
            {
                if (csType.Keyword.IsKind(pair.CS))
                {
                    return VB.SyntaxFactory.PredefinedType(VB.SyntaxFactory.Token(pair.VB));
                }
            }
            return null;
        }

        static VBS.ArrayTypeSyntax ConvertArrayType(this CSS.ArrayTypeSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csArray = (CSS.ArrayTypeSyntax)node;
            var vbElementType = (VBS.TypeSyntax)csArray.ElementType.Convert();
            var vbRanks = csArray.RankSpecifiers.ConvertSyntaxNodes<VBS.ArrayRankSpecifierSyntax>();
            return VB.SyntaxFactory.ArrayType(vbElementType, vbRanks);
        }

        static VBS.ArrayRankSpecifierSyntax ConvertArrayRank(this CSS.ArrayRankSpecifierSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csArrayRank = (CSS.ArrayRankSpecifierSyntax)node;

            int length = csArrayRank.Rank - 1;
            List<SyntaxToken> tokens = new List<SyntaxToken>();
            for (int i = 0; i < length; i++)
            {
                tokens.Add(VB.SyntaxFactory.Token(VB.SyntaxKind.CommaToken));
            }
            var vbArrayRank = VB.SyntaxFactory.ArrayRankSpecifier();
            return vbArrayRank.AddCommaTokens(tokens.ToArray());
        }

        static VBS.NullableTypeSyntax ConvertNullableType(this CSS.NullableTypeSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csNullType = (CSS.NullableTypeSyntax)node;
            var vbElementType = (VBS.TypeSyntax)csNullType.ElementType.Convert();
            return VB.SyntaxFactory.NullableType(vbElementType);
        }

        #endregion

        #region Parameter

        static VBS.ParameterListSyntax ConvertParameterList(this CSS.ParameterListSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csParameters = (CSS.ParameterListSyntax)node;
            var vbParameters = csParameters.Parameters.ConvertSyntaxNodes<VBS.ParameterSyntax>();
            return VB.SyntaxFactory.ParameterList().AddParameters(vbParameters.ToArray());
        }

        static VBS.ParameterSyntax ConvertParameter(this CSS.ParameterSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csParameter = (CSS.ParameterSyntax)node;
            var vbParamName = VB.SyntaxFactory.ModifiedIdentifier(csParameter.Identifier.ConvertID());
            var vbParameter = VB.SyntaxFactory.Parameter(vbParamName);

            SyntaxTokenList mods = new SyntaxTokenList();
            if (csParameter.Default != null)
            {
                mods = mods.Add(VB.SyntaxFactory.Token(VB.SyntaxKind.OptionalKeyword));
            }
            if (csParameter.Modifiers.Count == 0)
            {
                mods = mods.Add(VB.SyntaxFactory.Token(Microsoft.CodeAnalysis.VisualBasic.SyntaxKind.ByValKeyword));
            }
            else
            {
                bool hasByref = false;
                bool hasParams = false;

                if (csParameter.Default != null)
                {
                    mods = mods.Add(VB.SyntaxFactory.Token(VB.SyntaxKind.OptionalKeyword));
                }

                foreach (SyntaxToken token in csParameter.Modifiers)
                {
                    if (!hasByref && (token.IsKind(CS.SyntaxKind.RefKeyword) || token.IsKind(CS.SyntaxKind.OutKeyword)))
                    {
                        mods = mods.Add(VB.SyntaxFactory.Token(VB.SyntaxKind.ByRefKeyword));
                        hasByref = true;
                    }
                    else if (!hasParams && token.IsKind(CS.SyntaxKind.ParamsKeyword))
                    {
                        mods = mods.Add(VB.SyntaxFactory.Token(VB.SyntaxKind.ParamArrayKeyword));
                        hasParams = true;
                    }
                }
                if (!hasByref)
                {
                    mods = mods.Add(VB.SyntaxFactory.Token(Microsoft.CodeAnalysis.VisualBasic.SyntaxKind.ByValKeyword));
                }
            }

            if (mods.Count > 0)
            {
                vbParameter = vbParameter.WithModifiers(mods);
            }

            var vbAsClause = csParameter.Type.ConvertToAsClause();
            vbParameter = vbParameter.WithAsClause(vbAsClause);

            if (csParameter.Default != null)
            {
                var vbExpSyntax = (VBS.ExpressionSyntax)csParameter.Default.Value.Convert();
                var vbEQValue = VB.SyntaxFactory.EqualsValue(vbExpSyntax);

                vbParameter = vbParameter.WithDefault(vbEQValue);
            }
            return vbParameter;
        }

        static VBS.TypeParameterConstraintClauseSyntax ConvertTypeParameterConstraintClauseSyntax(this CSS.TypeParameterConstraintClauseSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csTypeParameterConstraintClause = (CSS.TypeParameterConstraintClauseSyntax)node;
            var vbTypeParameterConstraints = csTypeParameterConstraintClause.Constraints.ConvertSyntaxNodes<VBS.ConstraintSyntax>();// <VB.VisualBasicSyntaxNode>();
            if (vbTypeParameterConstraints.Count == 1)
            {
                return VB.SyntaxFactory.TypeParameterSingleConstraintClause(vbTypeParameterConstraints.First());
            }
            else
            {
                return VB.SyntaxFactory.TypeParameterMultipleConstraintClause(vbTypeParameterConstraints.ToArray());
            }
        }
        //case CS.SyntaxKind.ClassConstraint:
        //    return VB.SyntaxFactory.ClassConstraint(VB.SyntaxFactory.Token(VB.SyntaxKind.ClassKeyword));
        //case CS.SyntaxKind.StructConstraint:
        //    return VB.SyntaxFactory.StructureConstraint(VB.SyntaxFactory.Token(VB.SyntaxKind.StructureKeyword));
        //case CS.SyntaxKind.ConstructorConstraint:
        //    return VB.SyntaxFactory.NewConstraint(VB.SyntaxFactory.Token(VB.SyntaxKind.NewKeyword));

        static VBS.TypeConstraintSyntax ConvertTypeParameterConstraint(this CSS.TypeParameterConstraintSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csTypeParameterConsraint = (CSS.TypeParameterConstraintSyntax)node;
            var csTypeConstraint = (CSS.TypeConstraintSyntax)node;
            var vbType = (VBS.TypeSyntax)csTypeConstraint.Type.Convert();
            return VB.SyntaxFactory.TypeConstraint(vbType);
        }

        #endregion

        #region Name

        static VBS.TypeSyntax ConvertIdentifierName(this CSS.IdentifierNameSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            CSS.IdentifierNameSyntax csID = (CSS.IdentifierNameSyntax)node;
            if (csID.Identifier.ValueText == "dynamic")
            {
                return VB.SyntaxFactory.PredefinedType(VB.SyntaxFactory.Token(VB.SyntaxKind.ObjectKeyword));
            }
            return VB.SyntaxFactory.IdentifierName(csID.Identifier.ValueText);
        }

        static VBS.GenericNameSyntax ConvertGenericName(this CSS.GenericNameSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csGenericName = (CSS.GenericNameSyntax)node;
            var vbID = csGenericName.Identifier.ConvertID();
            var vbTypeArgumentList = (VBS.TypeArgumentListSyntax)csGenericName.TypeArgumentList.Convert();
            return VB.SyntaxFactory.GenericName(vbID, vbTypeArgumentList);
        }
        static VBS.QualifiedNameSyntax ConvertQualifiedName(this CSS.QualifiedNameSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csQualified = (CSS.QualifiedNameSyntax)node;
            var vbNameLeft = (VBS.NameSyntax)csQualified.Left.Convert();
            var vbNameRight = (VBS.SimpleNameSyntax)csQualified.Right.Convert();
            return VB.SyntaxFactory.QualifiedName(vbNameLeft, vbNameRight);
        }

        static VBS.QualifiedNameSyntax ConvertAliasQualifiedName(this CSS.AliasQualifiedNameSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csAliasQualified = (CSS.AliasQualifiedNameSyntax)node;
            var vbAlias = (VBS.IdentifierNameSyntax)csAliasQualified.Alias.Convert();
            var vbName = (VBS.SimpleNameSyntax)csAliasQualified.Name.Convert();
            return VB.SyntaxFactory.QualifiedName(vbAlias, vbName);
        }


        #endregion

        #region Field,Literal

        static SyntaxToken ConvertID(this SyntaxToken csID)
        {
            if (csID.IsKind(CS.SyntaxKind.IdentifierToken))
            {
                string id = csID.ValueText;
                if (!(csID.Parent is CSS.MethodDeclarationSyntax) && Keyword.IsVBKeyword(id))
                {
                    return VB.SyntaxFactory.BracketedIdentifier(id);

                }
                else
                {
                    return VB.SyntaxFactory.Identifier(id);
                }
            }
            return default(SyntaxToken);
        }

        static VBS.SimpleAsClauseSyntax ConvertToAsClause(this CSS.TypeSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csType = (CSS.TypeSyntax)node;
            if (csType == null || csType.IsVar)
            {
                return null;
            }
            else
            {
                var vbType = (VBS.TypeSyntax)csType.Convert();
                if (vbType == null)
                {
                    return null;
                }
                return VB.SyntaxFactory.SimpleAsClause(vbType);
            }
        }

        static VBS.LiteralExpressionSyntax ConvertLiteral(this CSS.LiteralExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csLiteral = (CSS.LiteralExpressionSyntax)node;
            if (csLiteral.IsKind(CS.SyntaxKind.NullLiteralExpression))
            {
                return VB.SyntaxFactory.NothingLiteralExpression(VB.SyntaxFactory.Token(VB.SyntaxKind.NothingKeyword));
            }

            string sValue = csLiteral.Token.ValueText;
            SyntaxToken vbToken = default(SyntaxToken);
            if (csLiteral.IsKind(CS.SyntaxKind.StringLiteralExpression))
            {
                vbToken = VB.SyntaxFactory.Token(VB.SyntaxKind.StringKeyword, sValue);
                return VB.SyntaxFactory.LiteralExpression(VB.SyntaxKind.StringLiteralExpression, vbToken);
            }

            if (csLiteral.IsKind(CS.SyntaxKind.NumericLiteralExpression))
            {
                sValue = csLiteral.Token.Text;
                bool isHex = false;
                if (sValue.StartsWith("0x"))
                {
                    isHex = true;
                    sValue = sValue.Substring(2);
                }
                var matchSuffix = System.Text.RegularExpressions.Regex.Match(sValue, "[DFLMU]$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                if (matchSuffix.Success)
                {
                    string vbSuffix = string.Empty;
                    switch (matchSuffix.Value.ToUpper())
                    {
                    case "L": vbSuffix = "L"; break;
                    case "U":
                        {
                            if (csLiteral.Token.Value is uint)
                            {
                                vbSuffix = "UI"; break;
                            }
                            else
                            {
                                vbSuffix = "UL"; break;
                            }
                        }
                    case "LU":
                    case "UL": vbSuffix = "UL"; break;
                    case "F": if (!isHex) vbSuffix = "F"; break;
                    case "D": if (!isHex) vbSuffix = "R"; break;
                    case "M": vbSuffix = "D"; break;
                    }
                    if (vbSuffix != string.Empty)
                    {
                        sValue = sValue.Substring(0, sValue.Length - matchSuffix.Value.Length) + vbSuffix;
                    }
                }

                if (isHex)
                {
                    sValue = "&H" + sValue;
                }

                if (csLiteral.Token.Value is sbyte
                    || csLiteral.Token.Value is short
                    || csLiteral.Token.Value is int
                    || csLiteral.Token.Value is long)
                {
                    long l = ((System.IConvertible)csLiteral.Token.Value).ToInt64(null);
                    ulong ul = (ulong)Math.Abs(l);
                    vbToken = VB.SyntaxFactory.IntegerLiteralToken(sValue, VBS.LiteralBase.Decimal, VBS.TypeCharacter.Integer, ul);
                    if (l < 0)
                    {
                        vbToken = VB.SyntaxFactory.Token(VB.SyntaxKind.MinusToken, "-");
                    }
                    return VB.SyntaxFactory.LiteralExpression(VB.SyntaxKind.NumericLiteralExpression, vbToken);

                }
                else if (csLiteral.Token.Value is byte
                     || csLiteral.Token.Value is ushort
                     || csLiteral.Token.Value is uint
                     || csLiteral.Token.Value is ulong)
                {
                    ulong ul = ((System.IConvertible)csLiteral.Token.Value).ToUInt64(null);
                    vbToken = VB.SyntaxFactory.IntegerLiteralToken(sValue, VBS.LiteralBase.Decimal, VBS.TypeCharacter.Integer, ul);
                    return VB.SyntaxFactory.LiteralExpression(VB.SyntaxKind.NumericLiteralExpression, vbToken);
                }
                else if (csLiteral.Token.Value is float || csLiteral.Token.Value is double)
                {
                    var dbl = ((System.IConvertible)csLiteral.Token.Value).ToDouble(null);
                    vbToken = VB.SyntaxFactory.FloatingLiteralToken(sValue, VBS.TypeCharacter.Single, dbl);
                    return VB.SyntaxFactory.LiteralExpression(VB.SyntaxKind.NumericLiteralExpression, vbToken);
                }
                else if (csLiteral.Token.Value is Decimal)
                {
                    vbToken = VB.SyntaxFactory.DecimalLiteralToken(sValue, VBS.TypeCharacter.Decimal, (Decimal)csLiteral.Token.Value);
                    return VB.SyntaxFactory.LiteralExpression(VB.SyntaxKind.NumericLiteralExpression, vbToken);
                }
            }

            System.Diagnostics.Debug.Assert(false, "ConvertLiteral");
            return default(VBS.LiteralExpressionSyntax);
        }

        static VBS.ExpressionSyntax ConvertControlChar(char c)
        {
            if (Char.IsControl(c))
            {
                for (int i = 0; i < Keyword.ControlCharPairs.GetLength(0); i++)
                {
                    if (Keyword.ControlCharPairs[i, 0][0] == c)
                    {
                        var vbToken = VB.SyntaxFactory.CharacterLiteralToken(Keyword.ControlCharPairs[i, 1], c);
                        return VB.SyntaxFactory.LiteralExpression(VB.SyntaxKind.CharacterLiteralExpression, vbToken);
                    }
                }

                return VB.SyntaxFactory.ParseExpression("ChrW(" + ((int)c).ToString() + ")");
            }
            else
            {
                var vbToken = VB.SyntaxFactory.CharacterLiteralToken(c.ToString(), c);
                return VB.SyntaxFactory.LiteralExpression(VB.SyntaxKind.CharacterLiteralExpression, vbToken);
            }
        }

        static VBS.ExpressionSyntax ConvertLiteralChar(this CSS.LiteralExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csLiteral = (CSS.LiteralExpressionSyntax)node;
            char c = (char)csLiteral.Token.Value;
            string s = "\"" + c.ToString() + "\"c";
            if (Char.IsControl(c))
            {
                return ConvertControlChar(c);
            }
            else
            {
                var vbToken = VB.SyntaxFactory.CharacterLiteralToken(s, c);
                return VB.SyntaxFactory.LiteralExpression(VB.SyntaxKind.CharacterLiteralExpression, vbToken);
            }
        }

        static VBS.ExpressionSyntax ConvertLiteralString(string text, string value, bool appendBracket = true)
        {
            if (appendBracket)
            {
                text = "\"" + text + "\"";
            }
            var vbToken = VB.SyntaxFactory.Literal(text, value);
            return VB.SyntaxFactory.LiteralExpression(VB.SyntaxKind.StringLiteralExpression, vbToken);
        }

        static VBS.ExpressionSyntax ConvertLiteralString(this CSS.LiteralExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csLiteral = (CSS.LiteralExpressionSyntax)node;

            string text = (string)csLiteral.Token.Value;
            if (text == null)
            {
                return VB.SyntaxFactory.NothingLiteralExpression(VB.SyntaxFactory.Token(VB.SyntaxKind.NothingKeyword));
            }
            else if (text.Length == 0)
            {
                return ConvertLiteralString("", "");
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            List<VBS.ExpressionSyntax> list = new List<VBS.ExpressionSyntax>();
            bool isPreviewCR = false;
            foreach (char c in text)
            {
                if (Char.IsControl(c))
                {
                    if (sb.Length > 0)
                    {
                        string valueText = sb.ToString();
                        list.Add(ConvertLiteralString(valueText.Replace("\"", "\"\""), valueText));
                        sb.Clear();
                    }

                    if (isPreviewCR && c == '\n')
                    {
                        list[list.Count - 1] = ConvertLiteralString("vbCrlf", "\r\n", false);
                    }
                    else
                    {
                        list.Add(ConvertControlChar(c));
                    }
                    isPreviewCR = c == '\r';
                }
                else
                {
                    sb.Append(c);
                    isPreviewCR = false;
                }
            }
            if (sb.Length > 0)
            {
                string part = sb.ToString();
                list.Add(ConvertLiteralString(part.Replace("\"", "\"\""), part));
            }

            if (list.Count == 1)
            {
                return list[0];
            }
            else
            {
                //  expression[0] + expression[1] + expression[2] + ...
                var expression = VB.SyntaxFactory.AddExpression(list[0], list[1]);
                for (int i = 2; i < list.Count; i++)
                {
                    expression = VB.SyntaxFactory.AddExpression(expression, list[i]);
                }
                return expression;
            }

        }

        static VBS.AnonymousObjectCreationExpressionSyntax ConvertAnonymousObjectCreationExpressionSyntax(this CSS.AnonymousObjectCreationExpressionSyntax node)
        {
            var fields = node.Initializers.Select(d => d.ConvertAnonymousObjectMemberDeclaratorSyntax()).ToArray();
            var initializer = VB.SyntaxFactory.ObjectMemberInitializer(fields);
            return VB.SyntaxFactory.AnonymousObjectCreationExpression(initializer);

        }
        static VBS.FieldInitializerSyntax ConvertAnonymousObjectMemberDeclaratorSyntax(this CSS.AnonymousObjectMemberDeclaratorSyntax decl)
        {
            VBS.FieldInitializerSyntax field;
            if (decl.NameEquals != null)
            {
                var name = decl.NameEquals.Name.ConvertIdentifierName() as VBS.IdentifierNameSyntax;
                var exp = decl.Expression.ConvertAssignRightExpression();
                field = VB.SyntaxFactory.NamedFieldInitializer(name, exp);
            }
            else
            {
                var exp = decl.Expression.Convert() as VBS.ExpressionSyntax;
                field = VB.SyntaxFactory.InferredFieldInitializer(exp);

            }
            return field;
        }
        #endregion

        #region InterpolatedString
        static VBS.InterpolatedStringExpressionSyntax ConvertInterpolatedStringExpression(this CSS.InterpolatedStringExpressionSyntax node)
        {
            List<VBS.InterpolatedStringContentSyntax> list = new List<VBS.InterpolatedStringContentSyntax>();
            var csInterpolatedStringExpressinon = (CSS.InterpolatedStringExpressionSyntax)node;
            foreach (CSS.InterpolatedStringContentSyntax csInterpolatedString in csInterpolatedStringExpressinon.Contents)
            {
                if (csInterpolatedString.Kind() == CS.SyntaxKind.InterpolatedStringText)
                {
                    var csInterpolatedText = (CSS.InterpolatedStringTextSyntax)csInterpolatedString;
                    string valueText = csInterpolatedText.TextToken.ValueText;
                    list.AddRange(SplitInterpolatedStringText(valueText));
                }
                else
                {
                    list.Add((VBS.InterpolatedStringContentSyntax)csInterpolatedString.Convert());
                }
            }
            return VB.SyntaxFactory.InterpolatedStringExpression().AddContents(list.ToArray());
        }
        private static VBS.InterpolatedStringTextSyntax CreateVBInterpolatedString(string valueTextWithoutControlChar)
        {
            string text = valueTextWithoutControlChar.Replace("\"", "\"\"");
            var vbToken = VB.SyntaxFactory.InterpolatedStringTextToken(text, valueTextWithoutControlChar);
            return VB.SyntaxFactory.InterpolatedStringText(vbToken);
        }
        private static VBS.InterpolationSyntax GetVBCRInterpolation()
        {
            var vbCRLF = VB.SyntaxFactory.IdentifierName("vbCrLf");
            return VB.SyntaxFactory.Interpolation(vbCRLF);
        }
        private static VBS.InterpolationSyntax CreateControlCharInterpolation(char c)
        {
            var vbCharW = ConvertControlChar(c);
            return VB.SyntaxFactory.Interpolation(vbCharW);
        }

        static VBS.InterpolationAlignmentClauseSyntax ConvertInterpolationAlignmentClause(this CSS.InterpolationAlignmentClauseSyntax node)
        {
            var csAlignment = (CSS.InterpolationAlignmentClauseSyntax)node;
            var vbExprettion = (VBS.ExpressionSyntax)csAlignment.Value.Convert();
            return VB.SyntaxFactory.InterpolationAlignmentClause(vbExprettion);
        }

        static VBS.InterpolatedStringContentSyntax ConvertInterpolatedStringText(this CSS.InterpolatedStringTextSyntax node)
        {
            var csInterpolatedText = (CSS.InterpolatedStringTextSyntax)node;
            string text = csInterpolatedText.TextToken.Text;
            string valueText = csInterpolatedText.TextToken.ValueText;
            if (valueText.Count(c => Char.IsControl(c)) == 0)
            {
                var vbToken = VB.SyntaxFactory.InterpolatedStringTextToken(text, valueText);
                return VB.SyntaxFactory.InterpolatedStringText(vbToken);
            }
            else
            {
                var list = SplitInterpolatedStringText(valueText);
                var vbInterpolatedStringExpression = VB.SyntaxFactory.InterpolatedStringExpression().AddContents(list.ToArray());
                return VB.SyntaxFactory.Interpolation(vbInterpolatedStringExpression);
            }
        }

        private static List<VBS.InterpolatedStringContentSyntax> SplitInterpolatedStringText(string valueText)
        {
            List<VBS.InterpolatedStringContentSyntax> list = new List<VBS.InterpolatedStringContentSyntax>();
            bool isPreviewCR = false;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (char c in valueText)
            {
                if (Char.IsControl(c))
                {
                    if (sb.Length > 0)
                    {
                        list.Add(CreateVBInterpolatedString(sb.ToString()));
                        sb.Clear();
                    }

                    if (isPreviewCR && c == '\n')
                    {
                        list[list.Count - 1] = GetVBCRInterpolation();
                    }
                    else
                    {
                        list.Add(CreateControlCharInterpolation(c));
                    }
                    isPreviewCR = c == '\r';
                }
                else
                {
                    sb.Append(c);
                    isPreviewCR = false;
                }
            }
            if (sb.Length > 0)
            {
                list.Add(CreateVBInterpolatedString(sb.ToString()));
                sb.Clear();
            }
            return list;
        }

        static VBS.InterpolationSyntax ConvertInterpolation(this CSS.InterpolationSyntax node)
        {
            var csInterpolation = (CSS.InterpolationSyntax)node;
            var vbAlignment = (VBS.InterpolationAlignmentClauseSyntax)csInterpolation.AlignmentClause.Convert();
            var vbExpression = (VBS.ExpressionSyntax)csInterpolation.Expression.ConvertAssignRightExpression();
            var vbFormat = (VBS.InterpolationFormatClauseSyntax)csInterpolation.FormatClause.Convert();

            return VB.SyntaxFactory.Interpolation(vbExpression, vbAlignment).WithFormatClause(vbFormat); ;
        }

        static VBS.InterpolationFormatClauseSyntax ConvertInterpolationFormatClause(this CSS.InterpolationFormatClauseSyntax node)
        {
            var csInterpolationFormat = (CSS.InterpolationFormatClauseSyntax)node;
            var vbToken = VB.SyntaxFactory.InterpolatedStringTextToken(csInterpolationFormat.FormatStringToken.Text, csInterpolationFormat.FormatStringToken.ValueText);
            return VB.SyntaxFactory.InterpolationFormatClause(VB.SyntaxFactory.Token(VB.SyntaxKind.ColonToken), vbToken);
        }

        #endregion


        #region Expression

        static VBS.ExpressionSyntax ConvertExpression(this CSS.ExpressionSyntax node)
        {
            return (VBS.ExpressionSyntax)node.Convert();
        }

        static VBS.StatementSyntax ConvertExpressionStatement(this CSS.ExpressionStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csExpS = (CSS.ExpressionStatementSyntax)node;
            VBS.StatementSyntax vbStatement;
            object vb = csExpS.Expression.Convert();
            if (vb == null)
            {
                return null;
            }
            else if (vb is VBS.ExpressionSyntax)
            {
                var vbSyntax = (VBS.ExpressionSyntax)vb;
                vbStatement = VB.SyntaxFactory.ExpressionStatement(vbSyntax);
            }
            else
            {
                vbStatement = vb as VBS.StatementSyntax;
            }

            return vbStatement;
        }

        static VBS.CTypeExpressionSyntax ConvertDefaultExpression(this CSS.DefaultExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csDefault = (CSS.DefaultExpressionSyntax)node;
            var vbType = (VBS.TypeSyntax)csDefault.Type.Convert();
            var vbNothing = VB.SyntaxFactory.NothingLiteralExpression(VB.SyntaxFactory.Token(VB.SyntaxKind.NothingKeyword));
            return VB.SyntaxFactory.CTypeExpression(vbNothing, vbType);
        }

        static VBS.DirectCastExpressionSyntax ConvertCast(this CSS.CastExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csCast = (CSS.CastExpressionSyntax)node;
            var vbExpression = (VBS.ExpressionSyntax)csCast.Expression.ConvertAssignRightExpression();
            var vbType = (VBS.TypeSyntax)csCast.Type.Convert();
            return VB.SyntaxFactory.DirectCastExpression(vbExpression, vbType);
        }

        static VBS.TryCastExpressionSyntax ConvertAs(this CSS.BinaryExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csBinaryExp = (CSS.BinaryExpressionSyntax)node;
            var vbLeft = (VBS.ExpressionSyntax)csBinaryExp.Left.Convert();
            var vbRight = (VBS.ExpressionSyntax)csBinaryExp.Right.Convert();
            return VB.SyntaxFactory.TryCastExpression(vbLeft, (VBS.TypeSyntax)vbRight);
        }

        private static VBS.ExpressionSyntax ConvertAssignRightExpression(this CSS.ExpressionSyntax csRight)
        {
            if (csRight is CSS.AssignmentExpressionSyntax)
            {
                //C#
                //  int a; int b;
                //  a = b = 1;
                //     ^^^^^^^ AssignmentExpressionSyntax
                //
                //VB
                //  Dim a as Integer
                //  Dim b as Integer 
                //  a = Func()
                //         b = 1
                //         return b  
                //      End Function()
                var vbFunctionHeader = VB.SyntaxFactory.FunctionLambdaHeader().WithParameterList(VB.SyntaxFactory.ParameterList());
                var vbRight = (VBS.AssignmentStatementSyntax)csRight.Convert();
                var vbReturn = VB.SyntaxFactory.ReturnStatement(vbRight.Left);
                var vbEndFunction = VB.SyntaxFactory.EndFunctionStatement();
                var vbFunction = VB.SyntaxFactory.MultiLineFunctionLambdaExpression(vbFunctionHeader, vbEndFunction);

                vbFunction = vbFunction.AddStatements(vbRight).AddStatements(vbReturn);
                var vbBlankArgument = VB.SyntaxFactory.ArgumentList();
                return VB.SyntaxFactory.InvocationExpression(vbFunction, vbBlankArgument);
            }
            else
            {
                return (VBS.ExpressionSyntax)csRight.Convert();
            }
        }

        static VBS.StatementSyntax ConvertSimpleAssignment(this CSS.AssignmentExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csAssignment = (CSS.AssignmentExpressionSyntax)node;
            var vbLeft = (VBS.ExpressionSyntax)csAssignment.Left.Convert();
            var vbRight = (VBS.ExpressionSyntax)csAssignment.Right.ConvertAssignRightExpression();
            return VB.SyntaxFactory.SimpleAssignmentStatement(vbLeft, vbRight);
        }



        static VBS.AssignmentStatementSyntax ConvertAssignmentExpression(CSS.AssignmentExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csAssignmentExpression = (CSS.AssignmentExpressionSyntax)node;
            var vbLeft = (VBS.ExpressionSyntax)csAssignmentExpression.Left.Convert();
            var vbRight = (VBS.ExpressionSyntax)csAssignmentExpression.Right.ConvertAssignRightExpression();

            switch (csAssignmentExpression.Kind())
            {
            case CS.SyntaxKind.AddAssignmentExpression:// +=
                //Event Assign is Not Support
                return VB.SyntaxFactory.AddAssignmentStatement(vbLeft, vbRight);
            case CS.SyntaxKind.SubtractAssignmentExpression: // -=
                //Event Assign is Not Support
                return VB.SyntaxFactory.SubtractAssignmentStatement(vbLeft, vbRight);
            case CS.SyntaxKind.MultiplyAssignmentExpression: // *=
                return VB.SyntaxFactory.MultiplyAssignmentStatement(vbLeft, vbRight);
            case CS.SyntaxKind.DivideAssignmentExpression: // /=
                return VB.SyntaxFactory.DivideAssignmentStatement(vbLeft, vbRight);
            case CS.SyntaxKind.LeftShiftAssignmentExpression: // <<=
                return VB.SyntaxFactory.LeftShiftAssignmentStatement(vbLeft, vbRight);
            case CS.SyntaxKind.RightShiftAssignmentExpression: // >>=
                return VB.SyntaxFactory.RightShiftAssignmentStatement(vbLeft, vbRight);

            case CS.SyntaxKind.ModuloAssignmentExpression:// ^=
                vbRight = VB.SyntaxFactory.ModuloExpression(vbLeft, vbRight);
                return VB.SyntaxFactory.SimpleAssignmentStatement(vbLeft, vbRight);
            case CS.SyntaxKind.AndAssignmentExpression:// &=
                vbRight = VB.SyntaxFactory.AndExpression(vbLeft, vbRight);
                return VB.SyntaxFactory.SimpleAssignmentStatement(vbLeft, vbRight);
            case CS.SyntaxKind.OrAssignmentExpression:// |=
                vbRight = VB.SyntaxFactory.OrExpression(vbLeft, vbRight);
                return VB.SyntaxFactory.SimpleAssignmentStatement(vbLeft, vbRight);
            case CS.SyntaxKind.ExclusiveOrAssignmentExpression:// ^=
                vbRight = VB.SyntaxFactory.ExclusiveOrExpression(vbLeft, vbRight);
                return VB.SyntaxFactory.SimpleAssignmentStatement(vbLeft, vbRight);
            }
            return null;
        }

        static VB.VisualBasicSyntaxNode ConvertNameEquals(this CSS.NameEqualsSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csNameEqual = (CSS.NameEqualsSyntax)node;
            var vbName = (VBS.IdentifierNameSyntax)csNameEqual.Name.Convert();
            if (csNameEqual.Parent.IsKind(CS.SyntaxKind.UsingDirective))
            {//Using ***=###; alias
                return VB.SyntaxFactory.ImportAliasClause(vbName.ToFullString());
            }
            else if (csNameEqual.Parent.IsKind(CS.SyntaxKind.AttributeArgument))
            {//[DllImport("user32.dll", CharSet = CharSet.Auto)]
                return VB.SyntaxFactory.NameColonEquals(vbName);
            }
            else
            {
                System.Diagnostics.Debug.Assert(false, node.Kind().ToString());
            }
            return null;
        }

        static VBS.EqualsValueSyntax ConvertEqualsValue(this CSS.EqualsValueClauseSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csEqualsValue = (CSS.EqualsValueClauseSyntax)node;
            var vbValue = (VBS.ExpressionSyntax)csEqualsValue.Value.Convert();
            return VB.SyntaxFactory.EqualsValue(vbValue);
        }

        static VBS.ObjectCreationExpressionSyntax ConvertObjectCreation(this CSS.ObjectCreationExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csCreation = (CSS.ObjectCreationExpressionSyntax)node;
            var vbType = (VBS.TypeSyntax)csCreation.Type.Convert();
            var vbArgument = (VBS.ArgumentListSyntax)csCreation.ArgumentList.Convert();
            var vbCreation = VB.SyntaxFactory.ObjectCreationExpression(vbType);

            var vbInitializer = csCreation.Initializer.ConvertObjectCreationInitializer();

            vbCreation = vbCreation.AddArgumentListArguments(vbArgument.Arguments.ToArray())
                .WithInitializer(vbInitializer);
            return vbCreation;
        }

        static VBS.ObjectMemberInitializerSyntax ConvertObjectCreationInitializer(this CSS.InitializerExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            };
            var x = node.Expressions.Select(csExp => csExp.Convert()).ToArray();
            List<VBS.FieldInitializerSyntax> vbInisializers = new List<VBS.FieldInitializerSyntax>();
            foreach (CSS.ExpressionSyntax csExp in node.Expressions)
            {
                switch (csExp.Kind())
                {
                case CS.SyntaxKind.SimpleAssignmentExpression:
                    if (csExp is CSS.AssignmentExpressionSyntax)
                    {
                        var assign = (CSS.AssignmentExpressionSyntax)csExp;
                        if (assign.Left is CSS.IdentifierNameSyntax)
                        {
                            var xx = (CSS.IdentifierNameSyntax)assign.Left;
                            var left = assign.Left.Convert() as VBS.IdentifierNameSyntax;
                            var right = assign.Right.ConvertAssignRightExpression();
                            var initializer = VB.SyntaxFactory.NamedFieldInitializer(left, right);
                            vbInisializers.Add(initializer);
                        }
                    }
                    break;
                }
            }
            return VB.SyntaxFactory.ObjectMemberInitializer(vbInisializers.ToArray());
        }


        static VBS.CollectionInitializerSyntax ConvertArrayInitializer(this CSS.InitializerExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csInitializer = (CSS.InitializerExpressionSyntax)node;
            var vbInitializer = VB.SyntaxFactory.CollectionInitializer();
            foreach (CSS.ExpressionSyntax e in csInitializer.Expressions)
            {
                var vbExpression = (VBS.ExpressionSyntax)e.Convert();
                if (vbExpression.Kind() == VB.SyntaxKind.CollectionInitializer)
                {
                    SyntaxNode parent = node.Parent;
                    VBS.TypeSyntax vbType = null;
                    while (parent != null)
                    {
                        if (parent.IsKind(CS.SyntaxKind.ArrayCreationExpression))
                        {
                            var csArrayCreation = (CSS.ArrayCreationExpressionSyntax)parent;
                            vbType = (VBS.TypeSyntax)csArrayCreation.Type.Convert();
                            break;
                        }
                        else if (parent.IsKind(CS.SyntaxKind.VariableDeclaration))
                        {
                            var csVariable = (CSS.VariableDeclarationSyntax)parent;
                            vbType = (VBS.TypeSyntax)csVariable.Type.Convert();
                            break;
                        }
                        parent = parent.Parent;
                    }
                    if (vbType != null && vbType.Kind() == VB.SyntaxKind.ArrayType)
                    {
                        var vbAtype = (VBS.ArrayTypeSyntax)vbType;

                        if (vbAtype.RankSpecifiers.Count >= 2)
                        {
                            //Jagged Array
                            vbType = ((VBS.ArrayTypeSyntax)vbType).ElementType;
                            vbExpression = VB.SyntaxFactory.ArrayCreationExpression(vbType, (VBS.CollectionInitializerSyntax)vbExpression)
                                                .WithArrayBounds(VB.SyntaxFactory.ArgumentList());
                        }

                    }
                }
                vbInitializer = vbInitializer.AddInitializers(vbExpression);
            }
            return vbInitializer;
        }

        static VBS.ArrayCreationExpressionSyntax ConvertArrayCreation(this CSS.ArrayCreationExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csArrayCreation = (CSS.ArrayCreationExpressionSyntax)node;
            var csAType = (CSS.ArrayTypeSyntax)csArrayCreation.Type;
            var vbAType = (VBS.ArrayTypeSyntax)csAType.Convert();
            var vbInitializer = (VBS.CollectionInitializerSyntax)csArrayCreation.Initializer.Convert();
            if (vbInitializer == null)
            {
                vbInitializer = VB.SyntaxFactory.CollectionInitializer();
            }

            var vbArgs = new SyntaxList<VBS.ArgumentSyntax>();
            if (csAType.RankSpecifiers.Count > 0 && csAType.RankSpecifiers[0].Sizes != null)
            {
                bool hasInitializer = vbInitializer.Initializers.Count > 0;
                foreach (CSS.ExpressionSyntax csExp in csAType.RankSpecifiers[0].Sizes)
                {
                    if (hasInitializer || csExp.Kind() == CS.SyntaxKind.OmittedArraySizeExpression)
                    {
                        vbArgs = vbArgs.Add(VB.SyntaxFactory.OmittedArgument());
                    }
                    else
                    {
                        var vbExp = (VBS.ExpressionSyntax)csExp.Convert();
                        vbArgs = vbArgs.Add(VB.SyntaxFactory.SimpleArgument(vbExp));
                    }
                }
            }

            var vbArray = VB.SyntaxFactory.ArrayCreationExpression(vbAType.ElementType, vbInitializer)
                                .AddArrayBoundsArguments(vbArgs.ToArray());

            for (int i = 1; i < vbAType.RankSpecifiers.Count; i++)
            {//Jagged Array
                vbArray = vbArray.AddRankSpecifiers(VB.SyntaxFactory.ArrayRankSpecifier());
            }
            return vbArray;
        }

        static VBS.ArgumentListSyntax ConvertBaeArgumentList(this CSS.BaseArgumentListSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csArguments = (CSS.BaseArgumentListSyntax)node;
            var vbArgs = csArguments.Arguments.ConvertSyntaxNodes<VBS.ArgumentSyntax>();
            return VB.SyntaxFactory.ArgumentList().AddArguments(vbArgs.ToArray());
        }


        static VBS.ParameterListSyntax ConvertBracketedParameter(this CSS.BracketedParameterListSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csArguments = (CSS.BracketedParameterListSyntax)node;
            var vbParameters = csArguments.Parameters.ConvertSyntaxNodes<VBS.ParameterSyntax>();
            return VB.SyntaxFactory.ParameterList().AddParameters(vbParameters.ToArray());
        }

        static VBS.SimpleArgumentSyntax ConvertArgument(this CSS.ArgumentSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csArg = (CSS.ArgumentSyntax)node;
            var vbExp = (VBS.ExpressionSyntax)csArg.Expression.ConvertAssignRightExpression();
            var vbCollon = csArg.NameColon.ConvertNameCollon();
            var vbArg = VB.SyntaxFactory.SimpleArgument(vbExp).WithNameColonEquals(vbCollon);
            return vbArg;
        }
        static VBS.NameColonEqualsSyntax ConvertNameCollon(this CSS.NameColonSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csNameColon = (CSS.NameColonSyntax)node;
            var vbName = (VBS.IdentifierNameSyntax)csNameColon.Name.Convert();
            return VB.SyntaxFactory.NameColonEquals(vbName);
        }
        static VBS.InvocationExpressionSyntax ConvertInvocationExpretion(this CSS.InvocationExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csInvocation = (CSS.InvocationExpressionSyntax)node;
            var vbExp = (VBS.ExpressionSyntax)csInvocation.Expression.ConvertAssignRightExpression();
            var vbArguments = (VBS.ArgumentListSyntax)csInvocation.ArgumentList.Convert();

            return VB.SyntaxFactory.InvocationExpression(vbExp, vbArguments);
        }

        static VBS.MemberAccessExpressionSyntax ConvertMemberAccess(this CSS.MemberAccessExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csMemberAccess = (CSS.MemberAccessExpressionSyntax)node;

            var vbExp = (VBS.ExpressionSyntax)csMemberAccess.Expression.ConvertAssignRightExpression();
            var vbName = (VBS.SimpleNameSyntax)csMemberAccess.Name.Convert();
            SyntaxToken vbOperator = default(SyntaxToken);
            if (csMemberAccess.OperatorToken.IsKind(CS.SyntaxKind.DotToken))
            {
                vbOperator = VB.SyntaxFactory.Token(VB.SyntaxKind.DotToken);
            }
            else if (csMemberAccess.OperatorToken.IsKind(CS.SyntaxKind.ColonColonToken))
            {
                vbOperator = VB.SyntaxFactory.Token(VB.SyntaxKind.DotToken);
            }
            else
            {
                System.Diagnostics.Debug.Assert(false, "SimpleMemberAccessExpression");
            }

            var vbMemberAccess = VB.SyntaxFactory.MemberAccessExpression(VB.SyntaxKind.SimpleMemberAccessExpression, vbOperator, vbName);
            vbMemberAccess = vbMemberAccess.WithExpression(vbExp);

            return vbMemberAccess;
        }

        static VBS.InvocationExpressionSyntax ConvertElementAccess(this CSS.ElementAccessExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csElementAccess = (CSS.ElementAccessExpressionSyntax)node;
            var vbExp = (VBS.ExpressionSyntax)csElementAccess.Expression.ConvertAssignRightExpression();
            var vbArgs = (VBS.ArgumentListSyntax)csElementAccess.ArgumentList.Convert();
            var vbElementAccess = VB.SyntaxFactory.InvocationExpression(vbExp, vbArgs);
            return vbElementAccess;
        }

        static VBS.ParenthesizedExpressionSyntax ConvertParenthesized(this CSS.ParenthesizedExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csParenthesized = (CSS.ParenthesizedExpressionSyntax)node;
            var vbExp = (VBS.ExpressionSyntax)csParenthesized.Expression.ConvertAssignRightExpression();
            return VB.SyntaxFactory.ParenthesizedExpression(vbExp);
        }


        static VBS.LiteralExpressionSyntax ConvertNullLiteral()
        {
            var nothing = VB.SyntaxFactory.Token(VB.SyntaxKind.NothingKeyword);
            return VB.SyntaxFactory.NothingLiteralExpression(nothing);
        }
        static VBS.LiteralExpressionSyntax ConvertTrueLiteral()
        {
            return VB.SyntaxFactory.TrueLiteralExpression(VB.SyntaxFactory.Token(VB.SyntaxKind.TrueKeyword));
        }
        static VBS.LiteralExpressionSyntax ConvertFalseLiteral()
        {
            return VB.SyntaxFactory.FalseLiteralExpression(VB.SyntaxFactory.Token(VB.SyntaxKind.FalseKeyword));
        }

        static VBS.UnaryExpressionSyntax ConvertUnraryPlus(this CSS.PrefixUnaryExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csUnary = (CSS.PrefixUnaryExpressionSyntax)node;
            var vbExpression = (VBS.ExpressionSyntax)csUnary.Operand.Convert();
            return VB.SyntaxFactory.UnaryPlusExpression(vbExpression);
        }
        static VBS.UnaryExpressionSyntax ConvertUnraryMinus(this CSS.PrefixUnaryExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csUnary = (CSS.PrefixUnaryExpressionSyntax)node;
            var vbExpression = (VBS.ExpressionSyntax)csUnary.Operand.Convert();
            return VB.SyntaxFactory.UnaryMinusExpression(vbExpression);
        }

        static VBS.GetTypeExpressionSyntax ConvertTypeOf(this CSS.TypeOfExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csTypeExp = (CSS.TypeOfExpressionSyntax)node;
            return VB.SyntaxFactory.GetTypeExpression((VBS.TypeSyntax)csTypeExp.Type.Convert());
        }

        static VB.VisualBasicSyntaxNode ConvertBinaryExpression(CSS.BinaryExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csBinaryExp = (CSS.BinaryExpressionSyntax)node;
            var vbLeft = (VBS.ExpressionSyntax)csBinaryExp.Left.Convert();
            var vbRight = (VBS.ExpressionSyntax)csBinaryExp.Right.Convert();

            switch (node.Kind())
            {
            case CS.SyntaxKind.IsExpression:
                if (vbRight is VBS.TypeSyntax)
                {
                    return VB.SyntaxFactory.TypeOfIsExpression(vbLeft, (VBS.TypeSyntax)vbRight);
                }
                else
                {
                    return VB.SyntaxFactory.IsExpression(vbLeft, vbRight);
                }

            case CS.SyntaxKind.AddExpression:// +
                return VB.SyntaxFactory.AddExpression(vbLeft, vbRight);
            case CS.SyntaxKind.SubtractExpression:// -
                return VB.SyntaxFactory.SubtractExpression(vbLeft, vbRight);
            case CS.SyntaxKind.MultiplyExpression:// *
                return VB.SyntaxFactory.MultiplyExpression(vbLeft, vbRight);
            case CS.SyntaxKind.DivideExpression:// /
                return VB.SyntaxFactory.DivideExpression(vbLeft, vbRight);
            case CS.SyntaxKind.ModuloExpression:// %
                return VB.SyntaxFactory.ModuloExpression(vbLeft, vbRight);

            case CS.SyntaxKind.LeftShiftExpression: // <<
                return VB.SyntaxFactory.LeftShiftExpression(vbLeft, vbRight);
            case CS.SyntaxKind.RightShiftExpression: // >>
                return VB.SyntaxFactory.RightShiftExpression(vbLeft, vbRight);

            case CS.SyntaxKind.BitwiseAndExpression: // &
                return VB.SyntaxFactory.AndExpression(vbLeft, vbRight);
            case CS.SyntaxKind.BitwiseOrExpression: // |
                return VB.SyntaxFactory.OrExpression(vbLeft, vbRight);
            case CS.SyntaxKind.ExclusiveOrExpression: // ^
                return VB.SyntaxFactory.ExclusiveOrExpression(vbLeft, vbRight);

            case CS.SyntaxKind.LogicalAndExpression: // &&
                return VB.SyntaxFactory.AndAlsoExpression(vbLeft, vbRight);
            case CS.SyntaxKind.LogicalOrExpression: // ||
                return VB.SyntaxFactory.OrElseExpression(vbLeft, vbRight);

            case CS.SyntaxKind.EqualsExpression: // == 
                if (vbRight.IsKind(VB.SyntaxKind.NothingLiteralExpression))
                {
                    return VB.SyntaxFactory.IsExpression(vbLeft, vbRight);
                }
                else
                {
                    return VB.SyntaxFactory.EqualsExpression(vbLeft, vbRight);
                }

            case CS.SyntaxKind.NotEqualsExpression: // != 
                if (vbRight.IsKind(VB.SyntaxKind.NothingLiteralExpression))
                {
                    return VB.SyntaxFactory.IsNotExpression(vbLeft, vbRight);
                }
                else
                {
                    return VB.SyntaxFactory.NotEqualsExpression(vbLeft, vbRight);
                }

            case CS.SyntaxKind.GreaterThanExpression: // >
                return VB.SyntaxFactory.GreaterThanExpression(vbLeft, vbRight);
            case CS.SyntaxKind.GreaterThanOrEqualExpression: // >
                return VB.SyntaxFactory.GreaterThanOrEqualExpression(vbLeft, vbRight);
            case CS.SyntaxKind.LessThanExpression: // <
                return VB.SyntaxFactory.LessThanExpression(vbLeft, vbRight);
            case CS.SyntaxKind.LessThanOrEqualExpression: // <=
                return VB.SyntaxFactory.LessThanOrEqualExpression(vbLeft, vbRight);

            case CS.SyntaxKind.CoalesceExpression: // ??
                return VB.SyntaxFactory.BinaryConditionalExpression(vbLeft, vbRight);
            }

            System.Diagnostics.Debug.Assert(false, "Operator Expression");
            return null;
        }

        static VBS.UnaryExpressionSyntax ConvertNot(this CSS.PrefixUnaryExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var cs = (CSS.PrefixUnaryExpressionSyntax)node;
            var vbExp = (VBS.ExpressionSyntax)cs.Operand.Convert();
            var vbParenthesizedExpression = VB.SyntaxFactory.ParenthesizedExpression(vbExp);
            return VB.SyntaxFactory.NotExpression(vbParenthesizedExpression);
        }

        private static VBS.ExpressionSyntax CreateInvocation(string methodName, CSS.ExpressionSyntax csArg)
        {
            var vbExpression = (VBS.ExpressionSyntax)csArg.Convert();
            var vbArg = VB.SyntaxFactory.SimpleArgument(vbExpression);
            var vbArgs = VB.SyntaxFactory.ArgumentList().AddArguments(vbArg);
            var vbID = VB.SyntaxFactory.IdentifierName(methodName);
            return VB.SyntaxFactory.InvocationExpression(vbID, vbArgs);
        }

        static VBS.ExpressionSyntax ConvertPreIncrement(this CSS.PrefixUnaryExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            return CreateInvocation("__PreIncrement__", ((CSS.PrefixUnaryExpressionSyntax)node).Operand);
        }
        static VBS.ExpressionSyntax ConvertPreDecrement(this CSS.PrefixUnaryExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            return CreateInvocation("__PreDecrement__", ((CSS.PrefixUnaryExpressionSyntax)node).Operand);
        }
        static VBS.ExpressionSyntax ConvertPostIncrement(this CSS.PostfixUnaryExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            return CreateInvocation("__PostIncrement__", ((CSS.PostfixUnaryExpressionSyntax)node).Operand);
        }
        static VBS.ExpressionSyntax ConvertPostDecrement(this CSS.PostfixUnaryExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            return CreateInvocation("__PostDecrement__", ((CSS.PostfixUnaryExpressionSyntax)node).Operand);
        }

        static VBS.TernaryConditionalExpressionSyntax ConvertConditional(this CSS.ConditionalExpressionSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csConditional = (CSS.ConditionalExpressionSyntax)node;
            var vbCondition = (VBS.ExpressionSyntax)csConditional.Condition.Convert();
            var vbLeftValue = (VBS.ExpressionSyntax)csConditional.WhenTrue.Convert();
            var vbRightValue = (VBS.ExpressionSyntax)csConditional.WhenFalse.Convert();

            return VB.SyntaxFactory.TernaryConditionalExpression(vbCondition, vbLeftValue, vbRightValue);
        }

        //static SeparatedSyntaxList<VBS.StatementSyntax> ConvertExpressions(this SeparatedSyntaxList<CSS.ExpressionSyntax> csExps)
        //{

        //	SeparatedSyntaxList<VBS.StatementSyntax> retval = new SeparatedSyntaxList<VBS.StatementSyntax>();
        //	var x = csExps.Select(csExp => csExp.Convert()).ToArray();
        //	var vbExps = csExps.Select(csExp => csExp.Convert() as VBS.StatementSyntax).Where(vbExp => vbExp != null);
        //	return retval.AddRange(vbExps);
        //}

        #endregion



        #region Other

        static VBS.ImplementsClauseSyntax ConvertExplicitInterfaceSpecifier(this CSS.ExplicitInterfaceSpecifierSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csExplicitInterface = (CSS.ExplicitInterfaceSpecifierSyntax)node;

            var csParent = (CSS.MemberDeclarationSyntax)csExplicitInterface.Parent;
            SyntaxToken csID;
            if (csExplicitInterface.Parent.IsKind(CS.SyntaxKind.MethodDeclaration))
            {
                var csMethod = (CSS.MethodDeclarationSyntax)csExplicitInterface.Parent;
                csID = csMethod.Identifier;
            }
            else if (csExplicitInterface.Parent.IsKind(CS.SyntaxKind.PropertyDeclaration))
            {
                var csProperty = (CSS.PropertyDeclarationSyntax)csExplicitInterface.Parent;
                csID = csProperty.Identifier;
            }
            else if (csExplicitInterface.Parent.IsKind(CS.SyntaxKind.EventDeclaration))
            {
                var csEvent = (CSS.EventDeclarationSyntax)csExplicitInterface.Parent;
                csID = csEvent.Identifier;
            }
            else if (csExplicitInterface.Parent.IsKind(CS.SyntaxKind.IndexerDeclaration))
            {
                var csIndexer = (CSS.IndexerDeclarationSyntax)csExplicitInterface.Parent;
                var vbID = VB.SyntaxFactory.IdentifierName("Item");
                var vbInterfaceName = (VBS.NameSyntax)csIndexer.ExplicitInterfaceSpecifier.Name.Convert();
                var vbInterfaceMemberName = VB.SyntaxFactory.QualifiedName(vbInterfaceName, vbID);
                return VB.SyntaxFactory.ImplementsClause(vbInterfaceMemberName);
            }
            else
            {
                System.Diagnostics.Debug.Assert(false, "ExplicitInterfaceSpecifier");
                return null;
            }

            {
                var vbMemberName = csID.ConvertID();
                var vbID = VB.SyntaxFactory.IdentifierName(csID.ValueText);
                var vbInterfaceName = (VBS.NameSyntax)csExplicitInterface.Name.Convert();
                var vbInterfaceMemberName = VB.SyntaxFactory.QualifiedName(vbInterfaceName, vbID);

                return VB.SyntaxFactory.ImplementsClause(vbInterfaceMemberName);
            }
        }

        static VBS.UsingBlockSyntax ConvertUsingBlock(this CSS.UsingStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csUsing = (CSS.UsingStatementSyntax)node;
            var vbDeclaration = (VBS.DeclarationStatementSyntax)csUsing.Declaration.Convert();
            var vbExpression = (VBS.ExpressionSyntax)csUsing.Expression.ConvertAssignRightExpression();
            var vbStatements = csUsing.Statement.ConvertBlockOrStatements();

            var vbUsingStatement = VB.SyntaxFactory.UsingStatement();
            if (vbDeclaration is VBS.FieldDeclarationSyntax)
            {
                var vbField = (VBS.FieldDeclarationSyntax)vbDeclaration;
                vbUsingStatement = vbUsingStatement.AddVariables(vbField.Declarators.ToArray());
            }
            else if (vbExpression != null)
            {
                vbUsingStatement = vbUsingStatement.WithExpression(vbExpression);

            }
            else
            {
                System.Diagnostics.Debug.Assert(false, "UsingStatement");
            }

            return VB.SyntaxFactory.UsingBlock(vbUsingStatement).AddStatements(vbStatements.ToArray());
        }

        static SyntaxList<VBS.StatementSyntax> ConvertBlockStatements(this CSS.BlockSyntax node)
        {
            if (node == null)
            {
                return new SyntaxList<VBS.StatementSyntax>();
            }
            return node.Statements.ConvertStatements<VBS.StatementSyntax>();// <CSS.StatementSyntax, VBS.StatementSyntax>();
        }

        static VBS.SyncLockBlockSyntax ConvertLock(this CSS.LockStatementSyntax node)
        {
            if (node == null)
            {
                return null;
            }
            var csLock = (CSS.LockStatementSyntax)node;
            var vbExpression = (VBS.ExpressionSyntax)csLock.Expression.ConvertAssignRightExpression();
            var vbStatements = csLock.Statement.ConvertBlockOrStatements();

            var vbSyncLockStatement = VB.SyntaxFactory.SyncLockStatement(vbExpression);
            return VB.SyntaxFactory.SyncLockBlock(vbSyncLockStatement).AddStatements(vbStatements.ToArray());
        }

        static SyntaxList<VBS.StatementSyntax> ConvertBlockOrStatements(this CSS.StatementSyntax node)
        {
            if (node == null)
            {
                return new SyntaxList<VBS.StatementSyntax>();
            }

            if (node is CSS.BlockSyntax)
            {
                var csBlock = (CSS.BlockSyntax)node;
                return csBlock.Statements.Convert<CSS.StatementSyntax, VBS.StatementSyntax>();
            }
            else if (node is CSS.StatementSyntax)
            {
                var vbStatement = (VBS.StatementSyntax)node.Convert();
                var vbStatements = new SyntaxList<VBS.StatementSyntax>();
                if (vbStatement == null)
                {
                    return vbStatements;
                }

                return vbStatements.Add(vbStatement);
            }
            else
            {
                System.Diagnostics.Debug.Assert(false, "ConvertBlockStatments");
                return new SyntaxList<VBS.StatementSyntax>(); ;
            }
        }

        static SyntaxList<VBS.StatementSyntax> ConvertMembers(this IEnumerable<CSS.MemberDeclarationSyntax> csMembers) //where T : CSS.MemberDeclarationSyntax
        {
            SyntaxList<VBS.StatementSyntax> retval = new SyntaxList<VBS.StatementSyntax>();
            var vbmembers = csMembers.Convert<CSS.MemberDeclarationSyntax, VBS.StatementSyntax>().Where(b => b != null);
            return retval.AddRange(vbmembers);
        }

        static SyntaxList<VBS.StatementSyntax> ConvertClassMembers(this CSS.ClassDeclarationSyntax csClass) //where T : CSS.MemberDeclarationSyntax
        {
            var csMembers = csClass.Members;
            SyntaxList<VBS.StatementSyntax> retval = new SyntaxList<VBS.StatementSyntax>();

            List<SyntaxToken> csIDs = GetCSMemberIdentifier(csMembers);
            List<string> vbIDs = csIDs.Select(_ => _.ConvertID().ToFullString()).ToList();

            foreach (CSS.MemberDeclarationSyntax csMember in csMembers)
            {
                if (csMember.Kind() == CS.SyntaxKind.PropertyDeclaration)
                {
                    var csProperty = (CSS.PropertyDeclarationSyntax)csMember;
                    bool hasGetter = false;
                    bool hasSetter = false;
                    CSS.AccessorDeclarationSyntax csGetter = null;
                    CSS.AccessorDeclarationSyntax csSetter = null;
                    foreach (CSS.AccessorDeclarationSyntax csAccessor in csProperty.AccessorList.Accessors)
                    {
                        if (csAccessor.Body == null)
                        {
                        }
                        if (csAccessor.Kind() == CS.SyntaxKind.GetAccessorDeclaration)
                        {
                            hasGetter = true;
                            csGetter = csAccessor;
                        }
                        else if (csAccessor.Kind() == CS.SyntaxKind.SetAccessorDeclaration)
                        {
                            hasSetter = true;
                            csSetter = csAccessor;
                        }
                    }
                    if ((hasGetter && csGetter.Body != null) || (hasSetter && csSetter.Body != null))
                    {
                        //Not Auto Property
                        retval = retval.Add((VBS.StatementSyntax)csMember.Convert());
                    }
                    else if (hasGetter && hasSetter && csGetter.Body == null && csSetter.Body == null && csGetter.Modifiers.Count == 0 && csSetter.Modifiers.Count == 0)
                    {
                        //Auto Property
                        retval = retval.Add((VBS.StatementSyntax)csMember.Convert());
                    }
                    else if ((hasGetter && csGetter.Body == null) || (hasSetter && csSetter.Body == null))
                    {
                        //Expand Backing field;

                        var vbIDString = "_" + ((CSS.PropertyDeclarationSyntax)csMember).Identifier.ConvertID().ToFullString();
                        int count = 2;
                        while (vbIDs.Contains(vbIDString) || Keyword.IsVBKeyword(vbIDString))
                        {
                            vbIDString = vbIDString + "_" + count.ToString();
                            count++;
                        }
                        vbIDs.Add(vbIDString);
                        var vbMID = VB.SyntaxFactory.ModifiedIdentifier(vbIDString);
                        var csID = CS.SyntaxFactory.IdentifierName(vbIDString);

                        var csInitializer = csProperty.Initializer;
                        csProperty = csProperty.WithInitializer(null);

                        var csAccessors = CS.SyntaxFactory.AccessorList();
                        if (hasGetter)
                        {
                            var csGetterBlock = CS.SyntaxFactory.Block();
                            csGetterBlock = csGetterBlock.AddStatements(CS.SyntaxFactory.ReturnStatement(csID));
                            csGetter = csGetter.WithBody(csGetterBlock);
                            csAccessors = csAccessors.AddAccessors(csGetter);
                        }

                        if (hasSetter)
                        {
                            var csSetterBlock = CS.SyntaxFactory.Block();
                            var csLeft = csID;
                            var csRight = CS.SyntaxFactory.IdentifierName("value");
                            var csAssign = CS.SyntaxFactory.AssignmentExpression(CS.SyntaxKind.SimpleAssignmentExpression, csLeft, csRight);
                            csSetterBlock = csSetterBlock.AddStatements(CS.SyntaxFactory.ExpressionStatement(csAssign));
                            csSetter = csSetter.WithBody(csSetterBlock);
                            csAccessors = csAccessors.AddAccessors(csSetter);
                        }
                        csProperty = csProperty.WithAccessorList(csAccessors);

                        VB.VisualBasicSyntaxNode vbPropety = csProperty.Convert();
                        VBS.PropertyStatementSyntax vbPropertyStatement;
                        if (vbPropety.IsKind(VB.SyntaxKind.PropertyStatement))
                        {
                            vbPropertyStatement = (VBS.PropertyStatementSyntax)vbPropety;
                            retval = retval.Add(vbPropertyStatement);
                        }
                        else
                        {
                            var vbPropertyBlock = (VBS.PropertyBlockSyntax)vbPropety;
                            vbPropertyStatement = vbPropertyBlock.PropertyStatement;

                            retval = retval.Add(vbPropertyBlock);
                        }

                        SyntaxTokenList vbModifiers = new SyntaxTokenList();
                        vbModifiers = vbModifiers.Add(VB.SyntaxFactory.Token(VB.SyntaxKind.PrivateKeyword));
                        if (vbPropertyStatement.Modifiers.Count(_ => _.IsKind(VB.SyntaxKind.SharedKeyword)) > 0)
                        {
                            vbModifiers = vbModifiers.Add(VB.SyntaxFactory.Token(VB.SyntaxKind.SharedKeyword));
                        }

                        var vbVariable = VB.SyntaxFactory.VariableDeclarator(vbMID);
                        vbVariable = vbVariable.WithAsClause(vbPropertyStatement.AsClause);
                        if (csInitializer != null)
                        {
                            var vbInitializer = (VBS.EqualsValueSyntax)csInitializer.Convert();
                            vbVariable = vbVariable.WithInitializer(vbInitializer);
                        }

                        var vbBackingField = VB.SyntaxFactory.FieldDeclaration(vbVariable).WithModifiers(vbModifiers);

                        retval = retval.Add(vbBackingField);
                    }
                }
                else
                {
                    var vbStatement = (VBS.StatementSyntax)csMember.Convert();
                    if (vbStatement == null)
                    {
                    }
                    else
                    {
                        retval = retval.Add((VBS.StatementSyntax)csMember.Convert());
                    }
                }
            }
            return retval;
        }

        private static List<SyntaxToken> GetCSMemberIdentifier(this IEnumerable<CSS.MemberDeclarationSyntax> csMembers)
        {
            List<SyntaxToken> ids = new List<SyntaxToken>();
            foreach (CSS.MemberDeclarationSyntax csMember in csMembers)
            {
                switch (csMember.Kind())
                {
                case CS.SyntaxKind.DelegateDeclaration:
                    break;
                case CS.SyntaxKind.EventDeclaration:
                    ids.Add(((CSS.EventDeclarationSyntax)csMember).Identifier);
                    break;
                case CS.SyntaxKind.EventFieldDeclaration:
                case CS.SyntaxKind.FieldDeclaration:
                    foreach (CSS.VariableDeclaratorSyntax csv in ((CSS.BaseFieldDeclarationSyntax)csMember).Declaration.Variables)
                    {
                        ids.Add(csv.Identifier);
                    }
                    break;
                case CS.SyntaxKind.MethodDeclaration:
                    ids.Add(((CSS.MethodDeclarationSyntax)csMember).Identifier);
                    break;
                case CS.SyntaxKind.PropertyDeclaration:
                    ids.Add(((CSS.PropertyDeclarationSyntax)csMember).Identifier);
                    break;
                case CS.SyntaxKind.EnumMemberDeclaration:
                    ids.Add(((CSS.EnumMemberDeclarationSyntax)csMember).Identifier);
                    break;
                case CS.SyntaxKind.EnumDeclaration:
                case CS.SyntaxKind.ClassDeclaration:
                case CS.SyntaxKind.StructDeclaration:
                case CS.SyntaxKind.InterfaceDeclaration:
                    ids.Add(((CSS.BaseTypeDeclarationSyntax)csMember).Identifier);
                    break;

                case CS.SyntaxKind.OperatorDeclaration:
                case CS.SyntaxKind.ConversionOperatorDeclaration:
                case CS.SyntaxKind.ConstructorDeclaration:
                case CS.SyntaxKind.DestructorDeclaration:
                case CS.SyntaxKind.IndexerDeclaration:
                    break;
                case CS.SyntaxKind.IncompleteMember:
                    //Because input is incomplete.
                    break;
                default:
                    System.Diagnostics.Debug.Assert(false, "GetCSMemberIdentifier");
                    break;
                }
            }
            return ids;
        }

        #endregion
    }


}
