using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Neo.VM.Types
{
    [DebuggerDisplay("Type={GetType().Name}, Value={value}")]
    public class Boolean : PrimitiveType
    {
        private static readonly ReadOnlyMemory<byte> TRUE = new byte[] { 1 };
        private static readonly ReadOnlyMemory<byte> FALSE = new byte[] { 0 };

        private readonly bool value;

        internal override ReadOnlyMemory<byte> Memory => value ? TRUE : FALSE;
        public override int Size => sizeof(bool);
        public override StackItemType Type => StackItemType.Boolean;

        public Boolean(bool value)
        {
            this.value = value;
        }

        public override bool Equals(PrimitiveType other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is Boolean b) return value == b.value;
            return base.Equals(other);
        }

        public override BigInteger ToBigInteger()
        {
            return value ? BigInteger.One : BigInteger.Zero;
        }

        public override bool ToBoolean()
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Boolean(bool value)
        {
            return new Boolean(value);
        }
    }
}
