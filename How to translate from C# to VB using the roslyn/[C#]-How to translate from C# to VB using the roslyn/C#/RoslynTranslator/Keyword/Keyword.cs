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
        class Keyword
        {
            public readonly static KeywordPair[] ModifirePairs =
            {
                new KeywordPair(CS.SyntaxKind.PrivateKeyword, VB.SyntaxKind.PrivateKeyword),
                new KeywordPair(CS.SyntaxKind.ProtectedKeyword, VB.SyntaxKind.ProtectedKeyword),
                new KeywordPair(CS.SyntaxKind.InternalKeyword, VB.SyntaxKind.FriendKeyword),
                new KeywordPair(CS.SyntaxKind.PublicKeyword, VB.SyntaxKind.PublicKeyword),
                new KeywordPair(CS.SyntaxKind.StaticKeyword, VB.SyntaxKind.SharedKeyword),
                new KeywordPair(CS.SyntaxKind.OverrideKeyword, VB.SyntaxKind.OverridesKeyword),
                new KeywordPair(CS.SyntaxKind.VirtualKeyword, VB.SyntaxKind.OverridableKeyword),
                //new KeywordPair(CS.SyntaxKind.None, VB.SyntaxKind.OverloadsKeyword),
                new KeywordPair(CS.SyntaxKind.AbstractKeyword, VB.SyntaxKind.MustInheritKeyword, AttributeTargets.Class),
                new KeywordPair(CS.SyntaxKind.AbstractKeyword, VB.SyntaxKind.MustOverrideKeyword, AttributeTargets.All & ~AttributeTargets.Class),
                new KeywordPair(CS.SyntaxKind.SealedKeyword, VB.SyntaxKind.NotInheritableKeyword , AttributeTargets.Class),
                new KeywordPair(CS.SyntaxKind.SealedKeyword, VB.SyntaxKind.NotOverridableKeyword,AttributeTargets.All & ~AttributeTargets.Class),
                new KeywordPair(CS.SyntaxKind.NewKeyword, VB.SyntaxKind.ShadowsKeyword , AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event),
                new KeywordPair(CS.SyntaxKind.ConstKeyword,VB.SyntaxKind.ConstKeyword, AttributeTargets.Field  ),
                new KeywordPair(CS.SyntaxKind.PartialKeyword,VB.SyntaxKind.PartialKeyword),

                new KeywordPair(CS.SyntaxKind.ImplicitKeyword,VB.SyntaxKind.WideningKeyword),
                new KeywordPair(CS.SyntaxKind.ExplicitKeyword,VB.SyntaxKind.NarrowingKeyword ),

                new KeywordPair(CS.SyntaxKind.AsyncKeyword,VB.SyntaxKind.AsyncKeyword ),
                new KeywordPair(CS.SyntaxKind.AwaitKeyword,VB.SyntaxKind.AwaitKeyword ),

                new KeywordPair(CS.SyntaxKind.VolatileKeyword, VB.SyntaxKind.None, (AttributeTargets)0)

            };
            public readonly static KeywordPair[] TypePairs =
            {
                new KeywordPair(CS.SyntaxKind.NullKeyword, VB.SyntaxKind.NothingKeyword),
                new KeywordPair(CS.SyntaxKind.StringKeyword, VB.SyntaxKind.StringKeyword),
                new KeywordPair(CS.SyntaxKind.CharKeyword, VB.SyntaxKind.CharKeyword),
                new KeywordPair(CS.SyntaxKind.ObjectKeyword, VB.SyntaxKind.ObjectKeyword),

                new KeywordPair(CS.SyntaxKind.BoolKeyword , VB.SyntaxKind.BooleanKeyword),
                new KeywordPair(CS.SyntaxKind.ByteKeyword, VB.SyntaxKind.ByteKeyword),
                new KeywordPair(CS.SyntaxKind.SByteKeyword, VB.SyntaxKind.SByteKeyword),
                new KeywordPair(CS.SyntaxKind.ShortKeyword, VB.SyntaxKind.ShortKeyword),
                new KeywordPair(CS.SyntaxKind.UShortKeyword, VB.SyntaxKind.UShortKeyword),
                new KeywordPair(CS.SyntaxKind.IntKeyword, VB.SyntaxKind.IntegerKeyword),
                new KeywordPair(CS.SyntaxKind.UIntKeyword, VB.SyntaxKind.UIntegerKeyword),
                new KeywordPair(CS.SyntaxKind.LongKeyword, VB.SyntaxKind.LongKeyword ),
                new KeywordPair(CS.SyntaxKind.ULongKeyword, VB.SyntaxKind.ULongKeyword),
                new KeywordPair(CS.SyntaxKind.FloatKeyword, VB.SyntaxKind.SingleKeyword),
                new KeywordPair(CS.SyntaxKind.DoubleKeyword, VB.SyntaxKind.DoubleKeyword),
                new KeywordPair(CS.SyntaxKind.DecimalKeyword, VB.SyntaxKind.DecimalKeyword),           
            };


            public readonly static BreakPair[] BreakPairs =
            {
                new BreakPair (CS.SyntaxKind.SwitchStatement,VB.SyntaxKind.ExitSelectStatement, VB.SyntaxKind.SelectKeyword),
                new BreakPair (CS.SyntaxKind.ForStatement,VB.SyntaxKind.ExitForStatement, VB.SyntaxKind.ForKeyword),
                new BreakPair (CS.SyntaxKind.ForEachStatement,VB.SyntaxKind.ExitForStatement, VB.SyntaxKind.ForKeyword),
                new BreakPair (CS.SyntaxKind.DoStatement,VB.SyntaxKind.ExitDoStatement, VB.SyntaxKind.DoKeyword),
                new BreakPair (CS.SyntaxKind.WhileStatement,VB.SyntaxKind.ExitWhileStatement, VB.SyntaxKind.WhileKeyword),

                //Blocking
                new BreakPair(CS.SyntaxKind.MethodDeclaration, VB.SyntaxKind.None, VB.SyntaxKind.None),
            };
                public readonly static BreakPair[] ContinuePairs =
            {
                //new BreakPair (CS.SyntaxKind.SwitchStatement,VB.SyntaxKind.ExitSelectStatement, VB.SyntaxKind.SelectKeyword),
                new BreakPair (CS.SyntaxKind.ForStatement,VB.SyntaxKind.ContinueForStatement, VB.SyntaxKind.ForKeyword),
                new BreakPair (CS.SyntaxKind.ForEachStatement,VB.SyntaxKind.ContinueForStatement, VB.SyntaxKind.ForKeyword),
                new BreakPair (CS.SyntaxKind.DoStatement,VB.SyntaxKind.ContinueDoStatement, VB.SyntaxKind.DoKeyword),
                new BreakPair (CS.SyntaxKind.WhileStatement,VB.SyntaxKind.ContinueWhileStatement, VB.SyntaxKind.WhileKeyword),

                //Blocking
                new BreakPair(CS.SyntaxKind.MethodDeclaration, VB.SyntaxKind.None, VB.SyntaxKind.None),
            };



            public readonly static string[,] ControlCharPairs =
                {
                    {"\0","vbNullChar"},
                    {"\t","vbTab"},
                    {"\b","vbBack"},
                    {"\n","vblf"},
                    {"\v","vbVerticalTab"},
                    {"\f","vbFormFeed"},
                    {"\r","vbCr"},
                };

            public readonly static KeywordPair[] OperatorPairs =
            {
                /* +  */ new KeywordPair(CS.SyntaxKind.PlusToken,VB.SyntaxKind.PlusToken),
                /* -  */ new KeywordPair(CS.SyntaxKind.MinusToken,VB.SyntaxKind.MinusToken),
                /* *  */ new KeywordPair(CS.SyntaxKind.AsteriskToken,VB.SyntaxKind.AsteriskToken ),
                /* /  */ new KeywordPair(CS.SyntaxKind.SlashToken,VB.SyntaxKind.SlashToken),
                /* %  */ new KeywordPair(CS.SyntaxKind.PercentToken,VB.SyntaxKind.ModKeyword),
                /* ~  */ new KeywordPair(CS.SyntaxKind.TildeToken,VB.SyntaxKind.NotKeyword),

                /* << */ new KeywordPair(CS.SyntaxKind.LessThanLessThanToken,VB.SyntaxKind.LessThanLessThanToken),
                /* >> */ new KeywordPair(CS.SyntaxKind.GreaterThanGreaterThanToken,VB.SyntaxKind.GreaterThanGreaterThanToken),

                /* !  */ new KeywordPair(CS.SyntaxKind.ExclamationToken,VB.SyntaxKind.NotKeyword),
                /* &  */ new KeywordPair(CS.SyntaxKind.AmpersandToken,VB.SyntaxKind.AmpersandToken),
                /* |  */ new KeywordPair(CS.SyntaxKind.BarToken,VB.SyntaxKind.OrKeyword),
                /* ^  */ new KeywordPair(CS.SyntaxKind.CaretToken,VB.SyntaxKind.XorKeyword),

                /* == */ new KeywordPair(CS.SyntaxKind.EqualsEqualsToken,VB.SyntaxKind.EqualsToken),
                /* != */ new KeywordPair(CS.SyntaxKind.ExclamationEqualsToken,VB.SyntaxKind.LessThanGreaterThanToken),

                /* <  */ new KeywordPair(CS.SyntaxKind.LessThanToken,VB.SyntaxKind.LessThanToken),
                /* <= */ new KeywordPair(CS.SyntaxKind.LessThanEqualsToken ,VB.SyntaxKind.LessThanEqualsToken ),
                /* > */ new KeywordPair(CS.SyntaxKind.GreaterThanToken,VB.SyntaxKind.GreaterThanToken),
                /* >= */ new KeywordPair(CS.SyntaxKind.GreaterThanEqualsToken ,VB.SyntaxKind.GreaterThanEqualsToken),
            };

            public static bool IsVBKeyword(string id)
            {
                if (_VBKeywordStrings == null)
                {
                    _VBKeywordStrings = new List<string>();
                    foreach (VB.SyntaxKind kind in VB.SyntaxFacts.GetKeywordKinds())
                    {
                        string s = VB.SyntaxFactory.Token(kind).ToString().ToLower();
                        if (!_VBKeywordStrings.Contains(s))
                        {
                            _VBKeywordStrings.Add(s);
                        }
                    }
                    if (!_VBKeywordStrings.Contains("finalize"))
                    {
                        _VBKeywordStrings.Add("finalize");
                    }
                }

                return _VBKeywordStrings.Contains(id.ToLower());
            }

            private static List<string> _VBKeywordStrings;


        }
    }
}
