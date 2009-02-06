/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Microsoft Public License. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the  Microsoft Public License, please send an email to 
 * dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Microsoft Public License.
 *
 * You must not remove this notice, or any other, from this software.
 *
 *
 * ***************************************************************************/

using System.Dynamic.Utils;

namespace System.Linq.Expressions {
    /// <summary>
    /// Represents the default value of a type or an empty expression.
    /// </summary>
    public sealed class DefaultExpression : Expression {
        internal static readonly DefaultExpression VoidInstance = new DefaultExpression(typeof(void));

        private readonly Type _type;

        internal DefaultExpression(Type type) {
            _type = type;
        }

        /// <summary>
        /// Gets the static type of the expression that this <see cref="Expression" /> represents.
        /// </summary>
        /// <returns>The <see cref="Type"/> that represents the static type of the expression.</returns>
        protected override Type TypeImpl() {
            return _type;
        }

        /// <summary>
        /// Returns the node type of this Expression. Extension nodes should return
        /// ExpressionType.Extension when overriding this method.
        /// </summary>
        /// <returns>The <see cref="ExpressionType"/> of the expression.</returns>
        protected override ExpressionType NodeTypeImpl() {
            return ExpressionType.Default;
        }

        internal override Expression Accept(ExpressionVisitor visitor) {
            return visitor.VisitDefault(this);
        }
    }

    public partial class Expression {
        /// <summary>
        /// Creates an empty expression that has <see cref="System.Void"/> type.
        /// </summary>
        /// <returns>
        /// A <see cref="DefaultExpression"/> that has the <see cref="P:Expression.NodeType"/> property equal to 
        /// <see cref="F:ExpressionType.Default"/> and the <see cref="P:Expression.Type"/> property set to <see cref="System.Void"/>.
        /// </returns>
        public static DefaultExpression Empty() {
            return DefaultExpression.VoidInstance;
        }

        /// <summary>
        /// Creates a <see cref="DefaultExpression"/> that has the <see cref="P:Expression.Type"/> property set to the specified type.
        /// </summary>
        /// <param name="type">A <see cref="System.Type"/> to set the <see cref="P:Expression.Type"/> property equal to.</param>
        /// <returns>
        /// A <see cref="DefaultExpression"/> that has the <see cref="P:Expression.NodeType"/> property equal to 
        /// <see cref="F:ExpressionType.Default"/> and the <see cref="P:Expression.Type"/> property set to the specified type.
        /// </returns>
        public static DefaultExpression Default(Type type) {
            if (type == typeof(void)) {
                return Empty();
            }
            return new DefaultExpression(type);
        }
    }
}
