﻿using Microsoft.CodeAnalysis.Operations;
using Pchp.CodeAnalysis.FlowAnalysis;
using Ast = Devsense.PHP.Syntax.Ast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace Pchp.CodeAnalysis.Semantics
{
    public interface IPhpOperation : IOperation
    {
        /// <summary>
        /// Corresponding syntax node.
        /// </summary>
        Ast.LangElement PhpSyntax { get; set; }

        /// <summary>
        /// Visitor implementation.
        /// </summary>
        /// <param name="visitor">A reference to <see cref="PhpOperationVisitor"/> instance.</param>
        void Accept(PhpOperationVisitor visitor);
    }

    /// <summary>
    /// Abstract PHP expression semantic.
    /// </summary>
    public interface IPhpExpression : IPhpOperation
    {
        /// <summary>
        /// Analysed type information.
        /// The type is bound to a <see cref="TypeRefContext"/> associated with containing routine.
        /// </summary>
        TypeRefMask TypeRefMask { get; set; }

        /// <summary>
        /// Expression access information, whether it is being read, written to and what is the expected result type.
        /// </summary>
        BoundAccess Access { get; }

        /// <summary>
        /// Whether the expression needs current <c>Context</c> to be evaluated.
        /// If not, the expression can be evaluated in compile time or in app context.
        /// </summary>
        bool RequiresContext { get; }
    }

    public interface IPhpStatement : IPhpOperation
    {

    }
}
