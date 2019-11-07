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
        class SplitInheritResult
        {
            public SyntaxList<VBS.InheritsStatementSyntax> Inherits = new SyntaxList<VBS.InheritsStatementSyntax>();
            public SyntaxList<VBS.ImplementsStatementSyntax> Implements = new SyntaxList<VBS.ImplementsStatementSyntax>();
        }
    }
}
